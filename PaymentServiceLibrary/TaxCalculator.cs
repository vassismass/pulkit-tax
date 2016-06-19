using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SupplyChain.Care.PaymentModels;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary.Exceptions;
using System.Configuration.Provider;
using System.Xml.Serialization;
using System.Xml;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary.CP;

namespace Microsoft.SupplyChain.Care.Payment.ServiceLibrary
{
    public class TaxCalculator : ITaxCalculator
    {
        private const string ConfigErrorMsg = "Empty or missing '{0}'";
        private const string PartnerGuidKey = "partnerGuid";
        private const string ProductGuidKey = "productGuid";
        private const string IsZipCodeIncludedInCpComparisionKey = "isZipCodeIncludedInCpComparision";
        private const string ShipFromPathKey = "shipFromPath";
        private const string DatacenterCurrentKey = "datacenterCurrent";
        private CPServiceAgent serviceAgent;
        private CPAgentInfo info;
        private TaxRequest request;
        private IBillingService billingAgent;
        //TODO init in constructor from AppSettings;
        private Dictionary<string, string> Configuration = new Dictionary<string, string>();

        //Assuming constructor argument is passed from ConfigurationManager.AppSettings. Do we need to create a new class ConfigurationManager.AppSettings that
        //will return the list of Dictionary
        public TaxCalculator(IGetConfiguration Configuration, IBillingService billingAgent)
        {
            TaxCalculatorConfiguration taxconfig = Configuration.GetConfig();
            foreach (var c in taxconfig.Config)
            {
                this.Configuration.Add(c.Key,c.Value);
            }
            request = new TaxRequest();
            this.billingAgent = billingAgent;

        }

        private Guid PartnerGuid
        {
            get
            {
                string partnerGuid = this.Configuration[PartnerGuidKey];
                if (String.IsNullOrEmpty(partnerGuid))
                {
                    throw new ProviderException(string.Format(ConfigErrorMsg, PartnerGuidKey));
                }
                return new Guid(partnerGuid);
            }
        }



    private Guid ProductGuid
        {
            get
            {
                var productGuid = this.Configuration[ProductGuidKey];
                if (String.IsNullOrEmpty(productGuid))
                {
                    throw new ProviderException(string.Format(ConfigErrorMsg, ProductGuidKey));
                }
                return new Guid(productGuid);
            }
        }

        private string ShipFromPath
        {
            get
            {
                var shipFromPath = this.Configuration[ShipFromPathKey];
                if (String.IsNullOrEmpty(shipFromPath))
                {
                    throw new ProviderException(string.Format(ConfigErrorMsg, ShipFromPathKey));
                }
                return shipFromPath;
            }
        }

        private string geographyPath
        {
            get
            {
                var geographyPath = this.Configuration["geographyPath"];
                if (String.IsNullOrEmpty(geographyPath))
                {
                    throw new ProviderException(string.Format(ConfigErrorMsg, "geographyPath"));
                }
                return geographyPath;
            }
        }

        private string DatacenterCurrent
        {
            get
            {
                var datacenterCurrent = this.Configuration[DatacenterCurrentKey];
                if (String.IsNullOrEmpty(datacenterCurrent))
                {
                    throw new ProviderException(string.Format(ConfigErrorMsg, DatacenterCurrentKey));
                }
                return datacenterCurrent;
            }
        }

        private bool IsZipCodeIncludedInCpComparision
        {
            get
            {
                var isZipCodeIncludedInCpComparision = this.Configuration[IsZipCodeIncludedInCpComparisionKey];
                if (String.IsNullOrEmpty(isZipCodeIncludedInCpComparision))
                {
                    throw new ProviderException(string.Format(ConfigErrorMsg, IsZipCodeIncludedInCpComparisionKey));
                }
                return bool.Parse(isZipCodeIncludedInCpComparision);
            }
        }

        public TaxResponse CalculateTax(TaxRequest request)
        {
            ValidationException fault = null;
            var response = new TaxResponse();

            try
            {
                //validate Registration Info
                if (!CPServiceValidator.ValidateCalculateTax(request, this.geographyPath, out fault))
                    throw fault;
                this.request = request;
                var results = CalculateTax();
                
                response.TaxResults = results;

            }
            catch (Exception ex)
            {
                if (ex is PaymentIntegrationException)
                    throw ex;
                XmlSerializer XmlUtility = new XmlSerializer(typeof(TaxRequest));//new line
                StringWriter stringWriter = new StringWriter();//new line
                XmlWriter writer = XmlWriter.Create(stringWriter);//new line

                XmlUtility.Serialize(writer, request);


                var context = new Dictionary<string, string>();
                context["MethodName"] = "CalculateTax";
                context["CalculateTaxRequest"] = stringWriter.ToString(); //new line original : XmlUtility.SerializeObject(request);
                writer.Close();
                this.HandleException(ex, PaymentExceptioncode.PaymentProviderCalculateTaxException, context);
            }
            return response;
        }

        private const string PaymentProviderError = "Unhandled error occurred in PaymentProvider";
        protected void HandleException(Exception exception, PaymentExceptioncode exceptionCode, Dictionary<string, string> context)
        {
            PaymentServiceLibraryException derived = new PaymentProviderException(PaymentProviderError, exceptionCode, exception);

            derived.AddToExistingContext(context);
            throw derived;
        }

        private List<TaxInfo> CalculateTax()
        {
            var serviceAgent = GetServiceAgent();

            var addressId = serviceAgent.GetAddressId(request, billingAgent);

            return serviceAgent.CalculateTax(addressId, request);
        }
        private CPAgentInfo GetInfo()
        {
            CPAgentInfo inf = new CPAgentInfo();
            inf.productGuid = this.ProductGuid;
            inf.partnerGuid = this.PartnerGuid;
            inf.isZipCodeIncludedInCpComparision = this.IsZipCodeIncludedInCpComparision;
            inf.dataCenter = this.DatacenterCurrent;
            inf.shipFromPath = this.ShipFromPath;
            return inf;
        }
        private CPServiceAgent GetServiceAgent()
        {
            info = GetInfo();
            return new CPServiceAgent(info);
        }
    }
}
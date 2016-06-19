using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.SupplyChain.Care.PaymentModels;

namespace Microsoft.SupplyChain.Care.Payment.ServiceLibrary
{
    class GetConfiguration : IGetConfiguration
    {
        public TaxCalculatorConfiguration GetConfig()
        {
            TaxCalculatorConfiguration taxconfig = new TaxCalculatorConfiguration();
            taxconfig.Config.Add("partnerGuid",ConfigurationManager.AppSettings["partnerGuid"]);
            taxconfig.Config.Add("productGuid", ConfigurationManager.AppSettings["productGuid"]);
            taxconfig.Config.Add("isZipCodeIncludedInCpComparision", ConfigurationManager.AppSettings["isZipCodeIncludedInCpComparision"]);
            taxconfig.Config.Add("enableFraudDetection", ConfigurationManager.AppSettings["enableFraudDetection"]);
            taxconfig.Config.Add("shipFromPath", ConfigurationManager.AppSettings["shipFromPath"]);
            taxconfig.Config.Add("alreadySettledErrMsg", ConfigurationManager.AppSettings["alreadySettledErrMsg"]);
            taxconfig.Config.Add("datacenterCurrent", ConfigurationManager.AppSettings["datacenterCurrent"]);
            taxconfig.Config.Add("geographyPath", ConfigurationManager.AppSettings["geographyPath"]);
            return taxconfig;
        }
    }
}

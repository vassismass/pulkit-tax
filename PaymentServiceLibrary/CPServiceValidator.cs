using Microsoft.SupplyChain.Care.PaymentModels;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary.Exceptions;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary.Geography;
using System.Collections.Generic;
namespace Microsoft.SupplyChain.Care.Payment.ServiceLibrary
{
    #region Using

    #endregion

    /// <summary>
    /// This class is used to validate the incomming request to the service(s) 
    /// </summary>
    internal static class CPServiceValidator
    {
        /// <summary>
        /// Performs the CalculateTaxRequest request and updates the ValidationException for any deviances
        /// </summary>
        internal static bool ValidateCalculateTax(TaxRequest request, string geographyPath, out ValidationException fault)
        {
            fault = null;
            var countries = new List<Country>();
            try
            {
                countries = new GeoXmlDataProvider(geographyPath).GetCountries().Countries;
            }
            catch(System.IO.DirectoryNotFoundException ex)
            {
                fault = new ValidationException("Configuration parameter: Geography Path is NULL");
                fault.ExceptionCode = PaymentExceptioncode.GeographyXMLDataError;
                return false;

            }
                //Get it from the Cache
            //Validate CalculateTaxRequest object
            if (request == null)
            {
                fault = new ValidationException("Input parameter: CalculateTaxRequest is NULL");
                fault.ExceptionCode = PaymentExceptioncode.TaxRequestIsNull;
                return false;
            }
            //validate payment object
            if (request.paymentIdentityInfo == null)
            {
                fault = new ValidationException("Input parameter: PaymentIdentity is NULL");
                fault.ExceptionCode = PaymentExceptioncode.PaymentIdentityIsNull;
                return false;
            }
            
            //validate PaymentInstrumentId
            if (string.IsNullOrEmpty(request.paymentIdentityInfo.PaymentInstrumentId))
            {
                fault = new ValidationException("Input parameter: PaymentInstrumentId is invalid");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestPaymentInstrumentIdIsNull;
                return false;
            }

            //validate AccountId
            if (string.IsNullOrEmpty(request.paymentIdentityInfo.AccountId))
            {
                fault = new ValidationException("Input parameter: AcountId is invalid");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestAccountIdIsNull;
                return false;
            }

            //Validate PUID
            if (string.IsNullOrEmpty(request.paymentIdentityInfo.GuestId) && string.IsNullOrEmpty(request.paymentIdentityInfo.Puid))
            {
                fault = new ValidationException("Input parameter:  Puid/GuestId is invalid.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestPUIDIsNull;
                return false;
            }

            //Validate SKUInfo
            if (request.SKUInfo == null)
            {
                fault = new ValidationException("Input parameter:  SKUInfo is invalid.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull;
                return false;
            }
            
            //Validate SKUInfo
            if (string.IsNullOrEmpty(request.SKUInfo.PriceInfo.TaxCode))
            {
                fault = new ValidationException("Input parameter:  TaxCode cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull; // same as in reference but do we need to use new exception code i.e. TaxInfoTaxCodeIsNull
                return false;
            }

            //Validate SKUInfo
            if (request.SKUInfo.PriceInfo.Amount == 0.0M) //checks a decimal is uninitialised or not
            {
                fault = new ValidationException("Input parameter:  Amount cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull;
                return false;
            }

            //Validate SKUInfo
            if (string.IsNullOrEmpty(request.SKUInfo.PriceInfo.Currency))
            {
                fault = new ValidationException("Input parameter:  Currency cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull;
                return false;
            }
            //Validate SKUInfo
            if (string.IsNullOrEmpty(request.SKUInfo.Sku))
            {
                fault = new ValidationException("Input parameter:  SKU cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull;
                return false;
            }

            //Validate SKUInfo
            if (string.IsNullOrEmpty(request.SKUInfo.Description))
            {
                fault = new ValidationException("Input parameter:  Description cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull;
                return false;
            }
            
            //Validate SKUInfo
            if (string.IsNullOrEmpty(request.SKUInfo.PaymentSku))
            {
                fault = new ValidationException("Input parameter:  PaymentSku cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull;
                return false;
            }

            //Validate SKUInfo
            if (request.SKUInfo.AddressInfo == null)
            {
                fault = new ValidationException("Input parameter:  ShippingInfo PaymentSku cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull;
                return false;
            }
            //Validate country
            if (string.IsNullOrEmpty(request.SKUInfo.AddressInfo.Country))
            {
                fault = new ValidationException("Input parameter:  Country cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestCountryIsNull;
                return false;
            }
            //Validate Country
            if (!countries.Exists(country => country.IsoAlpha3Code == request.SKUInfo.AddressInfo.Country))
            {
                fault = new ValidationException("Input parameter:  Country code does not exists.");
                fault.ExceptionCode = PaymentExceptioncode.PaymentCountryCodeIsInvalid;
                return false;
            }

            //Validate Brand
            if (string.IsNullOrEmpty(request.Brand))
            {
                fault = new ValidationException("Input parameter:  Brand cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestBrandIsNull;
                return false;
            }
            //Validate Brand
            if (string.IsNullOrEmpty(request.OrderType))
            {
                fault = new ValidationException("Input parameter:  OrderType cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestOrderTypeIsNull;
                return false;
            }
            //Validate SKUInfo. Remaining test cases are only for physical goods
            if (request.OrderType != "ServiceContract" && request.SKUInfo.ShippingInfo == null)
            {
                fault = new ValidationException("Input parameter:  ShippingInfo cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull;
                return false;
            }
            //Validate SKUInfo
            if (request.OrderType!= "ServiceContract" && string.IsNullOrEmpty(request.SKUInfo.ShippingInfo.PaymentSku))
            {
                fault = new ValidationException("Input parameter:  ShippingInfo PaymentSku cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull;
                return false;
            }
            //Validate SKUInfo
            if (request.OrderType != "ServiceContract" && request.SKUInfo.ShippingInfo.AddressInfo == null)
            {
                fault = new ValidationException("Input parameter:  ShippingInfo AddressInfo cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull;
                return false;
            }
            //Validate SKUInfo
            if (request.OrderType != "ServiceContract" && string.IsNullOrEmpty(request.SKUInfo.ShippingInfo.AddressInfo.Country))
            {
                fault = new ValidationException("Input parameter:  ShippingInfo Address Country cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull;
                return false;
            }
            //Validate SKUInfo
            if (request.OrderType != "ServiceContract" && string.IsNullOrEmpty(request.SKUInfo.ShippingInfo.AddressInfo.UnitNumber))
            {
                fault = new ValidationException("Input parameter:  ShippingInfo Address Unit Number cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull;
                return false;
            }
            //Validate SKUInfo
            if (request.OrderType != "ServiceContract" && string.IsNullOrEmpty(request.SKUInfo.AddressInfo.FriendlyName))
            {
                fault = new ValidationException("Input parameter:  AddressInfo Friendly Name cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull;
                return false;
            }
            //Validate SKUInfo
            if (request.OrderType != "ServiceContract" && request.SKUInfo.ShippingInfo.PriceInfo == null)
            {
                fault = new ValidationException("Input parameter:  SkuInfo.ShippingInfo.PriceInfo cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull;
                return false;
            }
            //Validate SKUInfo
            if (request.OrderType != "ServiceContract" && string.IsNullOrEmpty(request.SKUInfo.ShippingInfo.PriceInfo.Currency))
            {
                fault = new ValidationException("Input parameter:  ShippingInfo.PriceInfo.Currency cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull;
                return false;
            }
            //Validate SKUInfo
            if (request.OrderType != "ServiceContract" && string.IsNullOrEmpty(request.SKUInfo.ShippingInfo.PriceInfo.TaxCode))
            {
                fault = new ValidationException("Input parameter:  ShippingInfo.PriceInfo.TaxCode cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull;
                return false;
            }
            //Validate SKUInfo
            if (request.OrderType != "ServiceContract" && request.SKUInfo.ShippingInfo.PriceInfo.Amount == 0.0M )
            {
                fault = new ValidationException("Input parameter:  ShippingInfo PriceInfo Amount cannot be null.");
                fault.ExceptionCode = PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull;
                return false;
            }
            return true;
        }
    }
}
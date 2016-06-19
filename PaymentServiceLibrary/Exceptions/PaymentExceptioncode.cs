using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SupplyChain.Care.Payment.ServiceLibrary.Exceptions
{
    public enum PaymentExceptioncode
    {
        InvalidZipCode = 4000,
        PaymentUpdateBillingAccountNonRetryableFailure = 4001,
        InvalidAddress = 4002,
        PaymentUpdateBillingAccountInvalidInput = 4003,
        PaymentUpdateBillingAccountRetryableFailure = 4004,
        GenericPaymentException = 4005,
        PaymentEndpointNotFoundException = 4006,
        PaymentTimeoutException = 4007,
        PaymentSoapException = 4008,
        CPRequiredConfigValuesUnavailable = 4009,
        PaymentGetBillingAccountInvalidInput = 4010,
        PaymentGetBillingAccountNonRetryableFailure = 4011,
        PaymentGetBillingAccountRetryableFailure = 4012,
        PaymentUpdateBillingAccountResponseNull = 4013,
        PaymentCalculateDigitalGoodsTaxInvalidInput = 4014,
        PaymentCalculateDigitalGoodsTaxNonRetryableFailure = 4015,
        PaymentCalculateDigitalGoodsTaxRetryableFailure = 4016,
        PaymentCalculatePhysicalGoodsTaxInvalidInput = 4017,
        PaymentCalculatePhysicalGoodsTaxNonRetryableFailure = 4018,
        PaymentCalculatePhysicalGoodsTaxRetryableFailure = 4019,
        UnknownGeneralException = 4020,
        TaxRequestIsNull = 4021,
        PaymentIdentityIsNull = 4022,
        CalculateTaxRequestPaymentInstrumentIdIsNull = 4023,
        CalculateTaxRequestAccountIdIsNull = 4024,
        CalculateTaxRequestPUIDIsNull = 4025,
        CalculateTaxRequestSKUInfoIsNull = 4026,
        CalculateTaxRequestCountryIsNull = 4027,
        PaymentCountryCodeIsInvalid = 4028,
        PaymentProviderCalculateTaxException = 4029,
        GeographyXMLDataError = 4030,
        GeographyXmlUnhandledError = 4031,
        CalculateTaxRequestBrandIsNull = 4032,
        CalculateTaxRequestOrderTypeIsNull = 4033
    }
}

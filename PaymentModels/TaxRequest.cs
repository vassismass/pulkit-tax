
namespace Microsoft.SupplyChain.Care.PaymentModels
{
    /// <summary>
    /// Names of the properties exposed by the Payment entity.
    /// </summary>
    public class TaxRequest
    {
        /// <summary>
        /// Payment Details
        /// </summary>

        public LineItem SKUInfo { get; set; }

        public PaymentIdentity paymentIdentityInfo { get; set; }

        //added by v-ashutr

        public string OrderType { get; set; }

        public string Brand { get; set; }    //added by t-pugoe
        public string Locale { get; set; }


        public string Currency { get; set; }

    }
}
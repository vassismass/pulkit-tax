using System.Collections.Generic;

namespace Microsoft.SupplyChain.Care.PaymentModels
{
    public class TaxInfo
    {
        /// <summary>
        /// Repair Offer Price 
        /// </summary>
        public decimal TotalAmoutWithoutTax { get; set; } //changed data type
        public string Sku { get; set; } //added newly

        public decimal TotalTax { get; set; }//added newly
        /// <summary>
        /// Total amount includingTax and excluding extended price
        /// </summary>
        public decimal TotalAmount { get; set; } //changed data type

        public List<TaxEntry> TaxEntries { get; set; } //added new data member

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SupplyChain.Care.PaymentModels
{
    /// <summary>
    /// Names of the properties exposed by the Payment entity.
    /// </summary>
    public class TaxEntry 
    {
        public string Type { get; set; }
                
        public decimal Tax { get; set; }

        public decimal Rate { get; set; }

    }
}
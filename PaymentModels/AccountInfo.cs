using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SupplyChain.Care.PaymentModels
{  
    public class AccountInfo
    {
        public string AccountId { get; set; }
        public Address Address { get; set; }
        public List<Address> Addresses { get; set; }

        public PhoneNumber Phone { get; set; }
    }
}
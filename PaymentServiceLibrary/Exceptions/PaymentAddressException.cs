using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SupplyChain.Care.Payment.ServiceLibrary.Exceptions
{
    [Serializable]
    public class PaymentAddressException : PaymentException
    {
        public PaymentAddressException(string message) : base(message) { }
    }
}

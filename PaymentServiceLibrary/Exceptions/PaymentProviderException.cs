using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SupplyChain.Care.Payment.ServiceLibrary.Exceptions
{
    class PaymentProviderException : PaymentIntegrationException
    {
        public PaymentProviderException(string message, PaymentExceptioncode exceptionCode, Exception innerException)
            : base(message, exceptionCode, innerException) { }
    }
}

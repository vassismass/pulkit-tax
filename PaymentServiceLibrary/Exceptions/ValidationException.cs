using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace Microsoft.SupplyChain.Care.Payment.ServiceLibrary.Exceptions
{
    public class ValidationException : PaymentIntegrationException
    {
        public ValidationException(string message) { }
        public ValidationException(string message, Exception innerException) { }
    }
}

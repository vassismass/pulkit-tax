using Microsoft.SupplyChain.Care.PaymentModels;
using System;
using System.Collections.Generic;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary.Exceptions;
namespace Microsoft.SupplyChain.Care.Payment.ServiceLibrary
{

    public interface ITaxCalculator
    {
        TaxResponse CalculateTax(TaxRequest request);
    }
    
}

using Microsoft.SupplyChain.Care.PaymentModels;
using System;

namespace Microsoft.SupplyChain.Care.Payment.ServiceLibrary
{
    public interface ITaxCalculator
    {
        TaxResponse CalculateTax(TaxRequest request);
    }
}

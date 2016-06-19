using Microsoft.SupplyChain.Care.PaymentModels;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary;
using System;

namespace Microsoft.SupplyChain.Care.Payment.TestTax
{
    public class MockedBillingService : IBillingService
    {

       public Func< string, PaymentIdentity, AccountInfo> GetBillingAccountFunc = null;
        public Func<AccountInfo,PaymentIdentity, string, string,AccountInfo> UpdateBillingAccountFunc = null;

        public AccountInfo GetBillingAccount(string country, PaymentIdentity paymentIdentity)
        {
            if (GetBillingAccountFunc != null)
                return GetBillingAccountFunc(country, paymentIdentity);
            return null;
        }

        public AccountInfo UpdateBillingAccount(AccountInfo accountInfo, PaymentIdentity paymentIdentity, 
            string locale, string currency)
        {
            if (UpdateBillingAccountFunc != null)
                return UpdateBillingAccountFunc(accountInfo, paymentIdentity, locale,currency);
            return null;
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.SupplyChain.Care.Payment.UnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.QualityTools.Testing.Fakes;
    using Microsoft.SupplyChain.Care.PaymentModels;
    using CP = Microsoft.SupplyChain.Care.Payment.ServiceLibrary.CP;
    using System;
    using Microsoft.SupplyChain.Care.Payment.ServiceLibrary.Fakes;
    using Microsoft.SupplyChain.Care.Payment.ServiceLibrary.CP.Fakes;
    //  using Moq;
    /// <summary>
    /// The test base.
    /// </summary>
    [TestClass]
    public class TestBase
    {
        ///<summary>
        ///Executing GetbillingAccount
        ///</summary>
        public static Action<Action, Action<CP.SearchAccountsResponse>> GetBillingContextAcoountInfoNull = (b, validate) =>
        {

            using (ShimsContext.Create())
            {
                ShimBillingService.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    SearchAccountsSearchAccountsRequest = req =>
                    {
                        var response = new CP.SearchAccountsResponse
                        {
                            Ack = CP.AckCode.Success

                        };
                        validate(response);
                        return response;
                    }
                };
                b();
            };
        };

        public static Action<Action, Action<CP.SearchAccountsResponse>> GetBillingContextAcoountNotFound = (b, validate) =>
        {

            using (ShimsContext.Create())
            {
                ShimBillingService.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    SearchAccountsSearchAccountsRequest = req =>
                    {
                        var response = new CP.SearchAccountsResponse
                        {
                            Ack = CP.AckCode.InvalidInput

                        };
                        validate(response);
                        return response;
                    }
                };
                b();
            };
        };

        public static Action<Action, Action<CP.SearchAccountsResponse>> GetBillingContextAcoountInfoNotNull = (b, validate) =>
        {
            CP.AccountInfoOutput[] ac = new CP.AccountInfoOutput[1];
            ac[0] = new CP.AccountInfoOutput
            {
                AccountId = "jWM6CQAAAAAAAAAA",
                AccountLevel = "Primary",
                CountryCode = "US"

            };


            using (ShimsContext.Create())
            {
                ShimBillingService.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    SearchAccountsSearchAccountsRequest = req =>
                    {
                        var response = new CP.SearchAccountsResponse
                        {
                            Ack = CP.AckCode.Success,
                            AccountInfos = ac
                        };
                        validate(response);
                        return response;
                    }
                };
                b();
            };
        };
        public static Action<Action, Action<CP.SearchAccountsResponse>> GetBillingContextAcoountIDtNull = (b, validate) =>
        {
            CP.AccountInfoOutput[] ac = new CP.AccountInfoOutput[1];
            ac[0] = new CP.AccountInfoOutput
            {
                // AccountId = "jWM6CQAAAAAAAAAA",
                AccountLevel = "Secondary",
                CountryCode = "US",
                Status = "Active"

            };


            using (ShimsContext.Create())
            {
                ShimBillingService.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    SearchAccountsSearchAccountsRequest = req =>
                    {
                        var response = new CP.SearchAccountsResponse
                        {
                            Ack = CP.AckCode.Success,
                            AccountInfos = ac
                        };
                        validate(response);
                        return response;
                    }
                };
                b();
            };
        };

        public static Action<Action, Action<CP.SearchAccountsResponse>> GetBillingContextAcoountIDNotMatch = (b, validate) =>
        {
            CP.AccountInfoOutput[] ac = new CP.AccountInfoOutput[1];
            ac[0] = new CP.AccountInfoOutput
            {
                AccountId = "ZzWM6CQAAAAAAAAAA",
                AccountLevel = "Primary",
                CountryCode = "US",
                Status = "Active"

            };


            using (ShimsContext.Create())
            {
                ShimBillingService.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    SearchAccountsSearchAccountsRequest = req =>
                    {
                        var response = new CP.SearchAccountsResponse
                        {
                            Ack = CP.AckCode.Success,
                            AccountInfos = ac
                        };
                        validate(response);
                        return response;
                    }
                };
                b();
            };
        };
        public static Action<Action, Action<CP.SearchAccountsResponse>> GetBillingContextAckInvalidInput = (b, validate) =>
        {
            CP.AccountInfoOutput[] ac = new CP.AccountInfoOutput[1];
            ac[0] = new CP.AccountInfoOutput
            {
                AccountId = "ZzWM6CQAAAAAAAAAA",
                AccountLevel = "Primary",
                CountryCode = "US",
                Status = "Active"

            };


            using (ShimsContext.Create())
            {
                ShimBillingService.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    SearchAccountsSearchAccountsRequest = req =>
                    {
                        var response = new CP.SearchAccountsResponse
                        {
                            Ack = CP.AckCode.InvalidInput,
                            AccountInfos = ac
                        };
                        validate(response);
                        return response;
                    }
                };
                b();
            };
        };

        public static Action<Action, Action<CP.SearchAccountsResponse>> GetBillingContextAckNonRetriable = (b, validate) =>
        {
            CP.AccountInfoOutput[] ac = new CP.AccountInfoOutput[1];
            ac[0] = new CP.AccountInfoOutput
            {
                AccountId = "ZzWM6CQAAAAAAAAAA",
                AccountLevel = "Primary",
                CountryCode = "US",
                Status = "Active"

            };


            using (ShimsContext.Create())
            {
                ShimBillingService.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    SearchAccountsSearchAccountsRequest = req =>
                    {
                        var response = new CP.SearchAccountsResponse
                        {
                            Ack = CP.AckCode.NonRetryableFailure,
                            AccountInfos = ac
                        };
                        validate(response);
                        return response;
                    }
                };
                b();
            };
        };

        public static Action<Action, Action<CP.SearchAccountsResponse>> GetBillingContextAckRetryableFailure = (b, validate) =>
        {
            CP.AccountInfoOutput[] ac = new CP.AccountInfoOutput[1];
            ac[0] = new CP.AccountInfoOutput
            {
                AccountId = "ZzWM6CQAAAAAAAAAA",
                AccountLevel = "Primary",
                CountryCode = "US",
                Status = "Active"

            };


            using (ShimsContext.Create())
            {
                ShimBillingService.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    SearchAccountsSearchAccountsRequest = req =>
                    {
                        var response = new CP.SearchAccountsResponse
                        {
                            Ack = CP.AckCode.RetryableFailure,
                            AccountInfos = ac
                        };
                        validate(response);
                        return response;
                    }
                };
                b();
            };
        };

        /// <summary>
        /// Executing in Update billing context
        /// </summary>
        public static Action<Action, Action<CP.UpdateAccountResponse>> UpdateBillingContext = (a, validate) =>
        {
            CP.Address[] ad = new CP.Address[1];

            ad[0] = new CP.Address
            {
                Street1 = "National Library Street",
                City = "Redmond",
                CountryCode = "USA",
                FirstName = "unit",
                LastName = "test",
                FriendlyName = "friendlyname",
                State = "WA",
                PostalCode = "98052"
            };



            CP.AccountInfoOutput ac = new CP.AccountInfoOutput
            {
                AccountId = "afasadasdafas",
                CompanyName = "CP",
                AddressSet = ad
            };



            using (ShimsContext.Create())
            {
                ShimBillingService.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    UpdateAccountUpdateAccountRequest = req =>
                    {
                        var response = new CP.UpdateAccountResponse
                        {
                            Ack = CP.AckCode.Success,
                            AccountInfoOutput = ac
                        };

                        validate(response);

                        return response;
                    }
                };
                a();
            }
        };

        public static Action<Action, Action<CP.UpdateAccountResponse>> UpdateBillingContextAccountInfoNull = (a, validate) =>
        {
            CP.Address[] ad = new CP.Address[1];

            ad[0] = new CP.Address
            {
                Street1 = "National Library Street",
                City = "Redmond",
                CountryCode = "USA",
                FirstName = "unit",
                LastName = "test",
                FriendlyName = "friendlyname",
                State = "WA",
                PostalCode = "98052"
            };



            CP.AccountInfoOutput ac = null;



            using (ShimsContext.Create())
            {
                ShimBillingService.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    UpdateAccountUpdateAccountRequest = req =>
                    {
                        var response = new CP.UpdateAccountResponse
                        {
                            Ack = CP.AckCode.Success,
                            AccountInfoOutput = ac
                        };

                        validate(response);

                        return response;
                    }
                };
                a();
            }
        };

        public static Action<Action, Action<CP.UpdateAccountResponse>> UpdateBillingContextNonRetryableFailure = (a, validate) =>
        {
            CP.Address[] ad = new CP.Address[1];

            ad[0] = new CP.Address
            {
                Street1 = "National Library Street",
                City = "Redmond",
                CountryCode = "USA",
                FirstName = "unit",
                LastName = "test",
                FriendlyName = "friendlyname",
                State = "WA",
                PostalCode = "98052"
            };



            CP.AccountInfoOutput ac = null;



            using (ShimsContext.Create())
            {
                ShimBillingService.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    UpdateAccountUpdateAccountRequest = req =>
                    {
                        var response = new CP.UpdateAccountResponse
                        {
                            Ack = CP.AckCode.NonRetryableFailure,
                            AccountInfoOutput = ac,
                            Error = new CP.CommerceError
                            {
                                ErrorCode = 11111
                            }

                        };

                        validate(response);

                        return response;
                    }
                };
                a();
            }
        };
        public static Action<Action, Action<CP.UpdateAccountResponse>> UpdateBillingContextInvalidAddress = (a, validate) =>
        {
            CP.Address[] ad = new CP.Address[1];

            ad[0] = new CP.Address
            {
                Street1 = "National Library Street",
                City = "Redmond",
                CountryCode = "USA",
                FirstName = "unit",
                LastName = "test",
                FriendlyName = "friendlyname",
                State = "WA",
                PostalCode = "98052"
            };



            CP.AccountInfoOutput ac = null;



            using (ShimsContext.Create())
            {
                ShimBillingService.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    UpdateAccountUpdateAccountRequest = req =>
                    {
                        var response = new CP.UpdateAccountResponse
                        {
                            Ack = CP.AckCode.NonRetryableFailure,
                            AccountInfoOutput = ac,
                            Error = new CP.CommerceError
                            {
                                ErrorCode = 60011
                            }

                        };

                        validate(response);

                        return response;
                    }
                };
                a();
            }
        };
        public static Action<Action, Action<CP.UpdateAccountResponse>> UpdateBillingContextInvalidZip = (a, validate) =>
        {
            CP.Address[] ad = new CP.Address[1];

            ad[0] = new CP.Address
            {
                Street1 = "National Library Street",
                City = "Redmond",
                CountryCode = "USA",
                FirstName = "unit",
                LastName = "test",
                FriendlyName = "friendlyname",
                State = "WA",
                PostalCode = "98052"
            };



            CP.AccountInfoOutput ac = null;



            using (ShimsContext.Create())
            {
                ShimBillingService.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    UpdateAccountUpdateAccountRequest = req =>
                    {
                        var response = new CP.UpdateAccountResponse
                        {
                            Ack = CP.AckCode.NonRetryableFailure,
                            AccountInfoOutput = ac,
                            Error = new CP.CommerceError
                            {
                                ErrorCode = 10021
                            }

                        };

                        validate(response);

                        return response;
                    }
                };
                a();
            }
        };

        public static Action<Action, Action<CP.UpdateAccountResponse>> UpdateBillingContextRetryableFailure = (a, validate) =>
        {
            CP.Address[] ad = new CP.Address[1];

            ad[0] = new CP.Address
            {
                Street1 = "National Library Street",
                City = "Redmond",
                CountryCode = "USA",
                FirstName = "unit",
                LastName = "test",
                FriendlyName = "friendlyname",
                State = "WA",
                PostalCode = "98052"
            };



            CP.AccountInfoOutput ac = null;



            using (ShimsContext.Create())
            {
                ShimBillingService.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    UpdateAccountUpdateAccountRequest = req =>
                    {
                        var response = new CP.UpdateAccountResponse
                        {
                            Ack = CP.AckCode.RetryableFailure,
                            AccountInfoOutput = ac


                        };

                        validate(response);

                        return response;
                    }
                };
                a();
            }
        };



    }

}

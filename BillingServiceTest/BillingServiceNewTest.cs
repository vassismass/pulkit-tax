using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary;
//using Moq;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SupplyChain.Care.PaymentModels;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary.Exceptions;
 
namespace Microsoft.SupplyChain.Care.Payment.UnitTest
{
    [TestClass]
    public class BillingServiceTest : TestBase
    {
        [TestMethod]
        public void GetBilling_AccountInfoNull()
        {
            GetBillingContextAcoountInfoNull(() =>
            {
                BillingService target = new BillingService();

                PaymentIdentity paymentIdentity = new PaymentIdentity()
                { Puid = "1829585232515266" };

                var actual = target.GetBillingAccount("US", paymentIdentity);
                Assert.IsNull(actual);
            }, (sh) =>
            {
            }
            );
        }
        [TestMethod]
        public void GetBilling_AccountInfoNotFound()
        {
            GetBillingContextAcoountNotFound(() =>
            {
                BillingService target = new BillingService();

                PaymentIdentity paymentIdentity = new PaymentIdentity()
                { Puid = "1829585232515266" };

                try
                {
                    var actual = target.GetBillingAccount("US", paymentIdentity);
                }
                catch (PaymentException px)
                {
                    Assert.AreEqual(PaymentExceptioncode.PaymentGetBillingAccountInvalidInput, px.ExceptionCode);
                }


            }, (sh) =>
            {
            }
            );
        }
        [TestMethod]
        public void GetBilling_AccountInfoNotNull()
        {
            GetBillingContextAcoountInfoNotNull(() =>
            {
                BillingService target = new BillingService();

                PaymentIdentity paymentIdentity = new PaymentIdentity()
                { Puid = "1829585232515266", AccountId = "jWM6CQAAAAAAAAAA" };

                var actual = target.GetBillingAccount("US", paymentIdentity);
                Assert.IsNotNull(actual);
            }, (sh) =>
            {
            }
            );
        }
        [TestMethod]
        public void GetBilling_AccountIDNull()
        {
            GetBillingContextAcoountIDtNull(() =>
            {
                BillingService target = new BillingService();

                PaymentIdentity paymentIdentity = new PaymentIdentity()
                { Puid = "1829585232515266" };

                var actual = target.GetBillingAccount("US", paymentIdentity);
                Assert.IsNull(actual);
            }, (sh) =>
            {
            }
            );
        }
        [TestMethod]
        public void GetBilling_AccountIDNotMatched()
        {
            GetBillingContextAcoountIDNotMatch(() =>
            {
                BillingService target = new BillingService();

                PaymentIdentity paymentIdentity = new PaymentIdentity()
                { Puid = "1829585232515266", AccountId = "jWM6CQAAAAAAAAAA" };
                try
                {
                    var actual = target.GetBillingAccount("US", paymentIdentity);
                }
                catch (PaymentException px)
                {
                    Assert.AreEqual(PaymentExceptioncode.PaymentGetBillingAccountInvalidInput, px.ExceptionCode);
                }

            }, (sh) =>
            {
            }
            );
        }

        [TestMethod]
        public void GetBilling_AccountIDACKInvalidInput()
        {
            GetBillingContextAckInvalidInput(() =>
            {
                BillingService target = new BillingService();

                PaymentIdentity paymentIdentity = new PaymentIdentity()
                { Puid = "1829585232515266", AccountId = "ZzWM6CQAAAAAAAAAA" };
                try
                {
                    var actual = target.GetBillingAccount("US", paymentIdentity);
                }
                catch (PaymentException px)
                {
                    Assert.AreEqual(PaymentExceptioncode.PaymentGetBillingAccountInvalidInput, px.ExceptionCode);
                }

            }, (sh) =>
            {
            }
            );
        }
        [TestMethod]
        public void GetBilling_AccountIDAckNonRetriable()
        {
            GetBillingContextAckNonRetriable(() =>
            {
                BillingService target = new BillingService();

                PaymentIdentity paymentIdentity = new PaymentIdentity()
                { Puid = "1829585232515266", AccountId = "ZzWM6CQAAAAAAAAAA" };
                try
                {
                    var actual = target.GetBillingAccount("US", paymentIdentity);
                }
                catch (PaymentException px)
                {
                    Assert.AreEqual(PaymentExceptioncode.PaymentGetBillingAccountNonRetryableFailure, px.ExceptionCode);
                }

            }, (sh) =>
            {
            }
            );
        }
        [TestMethod]
        public void GetBilling_AccountIDAckRetryableFailure()
        {
            GetBillingContextAckRetryableFailure(() =>
            {
                BillingService target = new BillingService();

                PaymentIdentity paymentIdentity = new PaymentIdentity()
                { Puid = "1829585232515266", AccountId = "ZzWM6CQAAAAAAAAAA" };
                try
                {
                    var actual = target.GetBillingAccount("US", paymentIdentity);
                }
                catch (PaymentException px)
                {
                    Assert.AreEqual(PaymentExceptioncode.PaymentGetBillingAccountRetryableFailure, px.ExceptionCode);
                }

            }, (sh) =>
            {
            }
            );
        }

        [TestMethod]

        public void UpdateBilling()
        {
            UpdateBillingContext(() =>
            {
                BillingService target = new BillingService();
                AccountInfo accountInfo = new AccountInfo
                {
                    AccountId = "jWM6CQAAAAAAAAAA",
                    Address = new Address
                    {
                        Address1 = "National Library Street",
                        City = "Redmond",
                        Country = "USA",
                        Email = "svithala@microsoft.com",
                        FirstName = "unit",
                        LastName = "test",
                        FriendlyName = "friendlyname",
                        State = "WA",
                        Zip = "98052"
                    },
                };
                PaymentIdentity paymentIdentity = new PaymentIdentity()
                { Puid = "1829585232515266" };

                var actual = target.UpdateBillingAccount(accountInfo, paymentIdentity, "en-US", "USD");
                Assert.IsNotNull(actual);
            }, (sh) =>
            {
            }
            );
        }
        [TestMethod]

        public void UpdateBillingAccountInfoNull()
        {
            UpdateBillingContextAccountInfoNull(() =>
            {
                BillingService target = new BillingService();
                AccountInfo accountInfo = new AccountInfo
                {
                    AccountId = "jWM6CQAAAAAAAAAA",
                    Address = new Address
                    {
                        Address1 = "National Library Street",
                        City = "Redmond",
                        Country = "USA",
                        Email = "svithala@microsoft.com",
                        FirstName = "unit",
                        LastName = "test",
                        FriendlyName = "friendlyname",
                        State = "WA",
                        Zip = "98052"
                    },
                };
                PaymentIdentity paymentIdentity = new PaymentIdentity()
                { Puid = "1829585232515266" };

                try
                {
                    var actual = target.UpdateBillingAccount(accountInfo, paymentIdentity, "en-US", "USD");
                }
                catch (PaymentException px)
                {
                    Assert.AreEqual(PaymentExceptioncode.PaymentUpdateBillingAccountResponseNull, px.ExceptionCode);
                }

            }, (sh) =>
            {
            }
            );
        }

        [TestMethod]

        public void UpdateNonRetriable()
        {
            UpdateBillingContextNonRetryableFailure(() =>
            {
                BillingService target = new BillingService();
                AccountInfo accountInfo = new AccountInfo
                {
                    AccountId = "jWM6CQAAAAAAAAAA",
                    Address = new Address
                    {
                        Address1 = "National Library Street",
                        City = "Redmond",
                        Country = "USA",
                        Email = "svithala@microsoft.com",
                        FirstName = "unit",
                        LastName = "test",
                        FriendlyName = "friendlyname",
                        State = "WA",
                        Zip = "98052"
                    },
                };
                PaymentIdentity paymentIdentity = new PaymentIdentity()
                { Puid = "1829585232515266" };
                try
                {
                    var actual = target.UpdateBillingAccount(accountInfo, paymentIdentity, "en-US", "USD");
                }
                catch (PaymentException px)
                {
                    Assert.AreEqual(PaymentExceptioncode.PaymentUpdateBillingAccountNonRetryableFailure, PaymentExceptioncode.PaymentUpdateBillingAccountNonRetryableFailure);
                }

            }, (sh) =>
            {
            }
            );
        }

        [TestMethod]

        public void UpdateBillingInvalidZipCode()
        {
            UpdateBillingContextInvalidZip(() =>
            {
                BillingService target = new BillingService();
                AccountInfo accountInfo = new AccountInfo
                {
                    AccountId = "jWM6CQAAAAAAAAAA",
                    Address = new Address
                    {
                        Address1 = "National Library Street",
                        City = "Redmond",
                        Country = "USA",
                        Email = "svithala@microsoft.com",
                        FirstName = "unit",
                        LastName = "test",
                        FriendlyName = "friendlyname",
                        State = "WA",
                        Zip = "98052"
                    },
                };
                PaymentIdentity paymentIdentity = new PaymentIdentity()
                { Puid = "1829585232515266" };
                try
                {
                    var actual = target.UpdateBillingAccount(accountInfo, paymentIdentity, "en-US", "USD");
                }
                catch (PaymentException px)
                {
                    Assert.AreEqual(PaymentExceptioncode.InvalidZipCode, PaymentExceptioncode.InvalidZipCode);
                }

            }, (sh) =>
            {
            }
            );
        }

        [TestMethod]

        public void UpdateBillingInvalidAddress()
        {
            UpdateBillingContextInvalidAddress(() =>
            {
                BillingService target = new BillingService();
                AccountInfo accountInfo = new AccountInfo
                {
                    AccountId = "jWM6CQAAAAAAAAAA",
                    Address = new Address
                    {
                        Address1 = "National Library Street",
                        City = "Redmond",
                        Country = "USA",
                        Email = "svithala@microsoft.com",
                        FirstName = "unit",
                        LastName = "test",
                        FriendlyName = "friendlyname",
                        State = "WA",
                        Zip = "98052"
                    },
                };
                PaymentIdentity paymentIdentity = new PaymentIdentity()
                { Puid = "1829585232515266" };
                try
                {
                    var actual = target.UpdateBillingAccount(accountInfo, paymentIdentity, "en-US", "USD");
                }
                catch (PaymentAddressException px)
                {
                    Assert.AreEqual(PaymentExceptioncode.InvalidAddress, PaymentExceptioncode.InvalidAddress);
                }

            }, (sh) =>
            {
            }
            );
        }

        [TestMethod]

        public void UpdateBillingRetriableFailure()
        {
            UpdateBillingContextRetryableFailure(() =>
            {
                BillingService target = new BillingService();
                AccountInfo accountInfo = new AccountInfo
                {
                    AccountId = "jWM6CQAAAAAAAAAA",
                    Address = new Address
                    {
                        Address1 = "National Library Street",
                        City = "Redmond",
                        Country = "USA",
                        Email = "svithala@microsoft.com",
                        FirstName = "unit",
                        LastName = "test",
                        FriendlyName = "friendlyname",
                        State = "WA",
                        Zip = "98052"
                    },
                };
                PaymentIdentity paymentIdentity = new PaymentIdentity()
                { Puid = "1829585232515266" };
                try
                {
                    var actual = target.UpdateBillingAccount(accountInfo, paymentIdentity, "en-US", "USD");
                }
                catch (PaymentException px)
                {
                    Assert.AreEqual(PaymentExceptioncode.PaymentUpdateBillingAccountRetryableFailure, PaymentExceptioncode.PaymentUpdateBillingAccountRetryableFailure);
                }

            }, (sh) =>
            {
            }
            );
        }

    }
}

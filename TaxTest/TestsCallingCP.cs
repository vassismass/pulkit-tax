using System;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary;
using System.Collections.Generic;
//using Moq;
using Microsoft.SupplyChain.Care.PaymentModels;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary.Exceptions;
namespace Microsoft.SupplyChain.Care.Payment.TestTax
{
    [TestClass]
    public class CPServiceAgentTest : TaxTestBase
    {
        [TestMethod]
        public void TaxRequestCountryXmlFormatException()
        {
            //TaxRequestIsNull(() =>
            //{
            IBillingService billingAgent = new MockedBillingService();
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "tyjytjty";
            Configuration["productGuid"] = "yjy";
            Configuration["isZipCodeIncludedInCpComparision"] = "etyyjtge";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Desktop\\Geography.docx";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            TaxCalculator target = new TaxCalculator(config, billingAgent);
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "gujtyract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentIntegrationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.GeographyXMLDataError, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxRequestCountryPathInvalid()
        {
            //TaxRequestIsNull(() =>
            //{
            IBillingService billingAgent = new MockedBillingService();
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "tyjytjty";
            Configuration["productGuid"] = "yjy";
            Configuration["isZipCodeIncludedInCpComparision"] = "etyyjtge";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Deskg4regtop\\Geography.docx";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            TaxCalculator target = new TaxCalculator(config, billingAgent);
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "gujtyract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentIntegrationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.GeographyXMLDataError, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsInvalidAck()
        {

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    Address addr = new Address { Country = "AUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };
                    List<Address> addresslst = new List<Address>();
                    addresslst.Add(addr);
                    AccountInfo accInf = new AccountInfo { Addresses = addresslst };
                    return accInf;
                }
            };
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            TaxCalculator target = new TaxCalculator(config, billingAgent);
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            InvalidAck(() =>
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculateDigitalGoodsTaxInvalidInput;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }
        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsNonRetryableFailure()
        {

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    Address addr = new Address { Country = "AUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };
                    List<Address> addresslst = new List<Address>();
                    addresslst.Add(addr);
                    AccountInfo accInf = new AccountInfo { Addresses = addresslst };
                    return accInf;
                }
            };
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            TaxCalculator target = new TaxCalculator(config, billingAgent);
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            NonRetryableFailure(() =>
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculateDigitalGoodsTaxNonRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }
        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsRetryableFailure()
        {

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    Address addr = new Address { Country = "AUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };
                    List<Address> addresslst = new List<Address>();
                    addresslst.Add(addr);
                    AccountInfo accInf = new AccountInfo { Addresses = addresslst };
                    return accInf;
                }
            };
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            TaxCalculator target = new TaxCalculator(config, billingAgent);
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            RetryableFailure(() =>
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculateDigitalGoodsTaxRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }
        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsAckSuccessful()
        {

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    Address addr = new Address { Country = "AUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };
                    List<Address> addresslst = new List<Address>();
                    addresslst.Add(addr);
                    AccountInfo accInf = new AccountInfo { Addresses = addresslst };
                    return accInf;
                }
            };
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            TaxCalculator target = new TaxCalculator(config, billingAgent);
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            AckSuccessful(() =>
            {
                  var temp = target.CalculateTax(request);
            }, (sh) =>
            {
            }
           );
        }


        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeFalseAckSuccessful()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "false";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);
            AckSuccessful(() =>
            {
                var temp = target.CalculateTax(request);
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeFalseInvalidAck()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "false";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);
            InvalidAck(() =>
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculateDigitalGoodsTaxInvalidInput;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeFalseNonRetryableFailure()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "false";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);
            NonRetryableFailure(() =>
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculateDigitalGoodsTaxNonRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeFalseRetryableFailure()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "false";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);
            RetryableFailure(() =>
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculateDigitalGoodsTaxRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeFalseRetryableFailure()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst, Address = addr };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "false";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            RetryableFailure(() =>
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculateDigitalGoodsTaxRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeFalseNonRetryableFailure()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst, Address = addr };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "false";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            NonRetryableFailure(() =>
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculateDigitalGoodsTaxNonRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeFalseRetryableFailureInvalidAck()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst, Address = addr };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "false";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            InvalidAck(() =>
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculateDigitalGoodsTaxInvalidInput;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeFalseRetryableFailureAckSuccessful()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst, Address = addr };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "false";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            AckSuccessful(() =>
            {
                var temp = target.CalculateTax(request);
                
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeTrueInvalidAck()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            InvalidAck(() =>
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculateDigitalGoodsTaxInvalidInput;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeTrueRetryableFailure()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            RetryableFailure(() =>
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculateDigitalGoodsTaxRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeTrueNonRetryableFailure()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            NonRetryableFailure(() =>
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculateDigitalGoodsTaxNonRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeTrueAckSuccessful()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            AckSuccessful(() =>
            {
                var temp = target.CalculateTax(request);
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeTrueInvalidAck()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst, Address = addr };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            InvalidAck(() =>
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculateDigitalGoodsTaxInvalidInput;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeTrueRetryableFailure()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst, Address = addr };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            RetryableFailure(() =>
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculateDigitalGoodsTaxRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeTruekNonRetryableFailure()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst, Address = addr };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            NonRetryableFailure(() =>
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculateDigitalGoodsTaxNonRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeTrueAckSuccessful()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst, Address = addr };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            AckSuccessful(() =>
            {
                var temp = target.CalculateTax(request);
            }, (sh) =>
            {
            }
           );
        }
























        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeTrueBrandUnmatched()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst, Address = addr };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "vwrevr", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);
            InvalidInputPhysicalGoods(() =>             //can use any cp.ack
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    Assert.AreEqual(px.Message, "Ship From address Brand could not be found.");
                }
            }, (sh) =>
            {
            }
           );
            
        }


        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeTrueBrandUnmatched()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "reger", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            InvalidInputPhysicalGoods(() =>                 //can use any cp.ack
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    Assert.AreEqual(px.Message, "Ship From address Brand could not be found.");
                }
            }, (sh) =>
            {
            }
           );
        }


        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeFalseBrandUnmatched()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst, Address = addr };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "false";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "verer", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            InvalidInputPhysicalGoods(() =>                 //can use any cp.ack
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    Assert.AreEqual(px.Message, "Ship From address Brand could not be found.");
                }
            }, (sh) =>
            {
            }
           );
        }


        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeFalseBrandUnmatched()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "false";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "rgve", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            InvalidInputPhysicalGoods(() =>                 //can use any cp.ack
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    Assert.AreEqual(px.Message, "Ship From address Brand could not be found.");
                }
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsTaxFakeGetBillingAccountAddressMatchesBrandUnmatched()
        {

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    Address addr = new Address { Country = "AUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };
                    List<Address> addresslst = new List<Address>();
                    addresslst.Add(addr);
                    AccountInfo accInf = new AccountInfo { Addresses = addresslst };
                    return accInf;
                }
            };
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            TaxCalculator target = new TaxCalculator(config, billingAgent);
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "fwerf", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            InvalidInputPhysicalGoods(() =>                 //can use any cp.ack
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    Assert.AreEqual(px.Message, "Ship From address Brand could not be found.");
                }
            }, (sh) =>
            {
            }
           );
        }









        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeTrueInvalidInput()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst, Address = addr };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "vwrevr", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);
            InvalidInputPhysicalGoods(() =>             
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculatePhysicalGoodsTaxInvalidInput;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );

        }


        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeTrueInvalidInput()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "reger", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            InvalidInputPhysicalGoods(() =>                 
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculatePhysicalGoodsTaxInvalidInput;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }


        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeFalseInvalidInput()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst, Address = addr };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "false";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "verer", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            InvalidInputPhysicalGoods(() =>                 
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculatePhysicalGoodsTaxInvalidInput;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }


        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeFalseInvalidInput()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "false";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "rgve", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            InvalidInputPhysicalGoods(() =>                 
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculatePhysicalGoodsTaxInvalidInput;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsTaxFakeGetBillingAccountAddressMatchesInvalidInput()
        {

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    Address addr = new Address { Country = "AUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };
                    List<Address> addresslst = new List<Address>();
                    addresslst.Add(addr);
                    AccountInfo accInf = new AccountInfo { Addresses = addresslst };
                    return accInf;
                }
            };
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            TaxCalculator target = new TaxCalculator(config, billingAgent);
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "fwerf", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            InvalidInputPhysicalGoods(() =>                 
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculatePhysicalGoodsTaxInvalidInput;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }




        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeTrueNonRetryableFailure()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst, Address = addr };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "vwrevr", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);
            NonRetryableFailurePhysicalGoods(() =>             
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculatePhysicalGoodsTaxNonRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );

        }


        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeTrueNonRetryableFailure()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "reger", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            NonRetryableFailurePhysicalGoods(() =>                 
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculatePhysicalGoodsTaxNonRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }


        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeFalseNonRetryableFailure()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst, Address = addr };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "false";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "verer", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            NonRetryableFailurePhysicalGoods(() =>                
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculatePhysicalGoodsTaxNonRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }


        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeFalseNonRetryableFailure()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "false";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "rgve", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            NonRetryableFailurePhysicalGoods(() =>                
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculatePhysicalGoodsTaxNonRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsTaxFakeGetBillingAccountAddressMatchesNonRetryableFailure()
        {

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    Address addr = new Address { Country = "AUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };
                    List<Address> addresslst = new List<Address>();
                    addresslst.Add(addr);
                    AccountInfo accInf = new AccountInfo { Addresses = addresslst };
                    return accInf;
                }
            };
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            TaxCalculator target = new TaxCalculator(config, billingAgent);
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "fwerf", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            NonRetryableFailurePhysicalGoods(() =>                 
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculatePhysicalGoodsTaxNonRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }



        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeTrueRetryableFailure()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst, Address = addr };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "vwrevr", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);
            RetryableFailurePhysicalGoods(() =>           
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculatePhysicalGoodsTaxRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );

        }


        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeTrueRetryableFailure()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "reger", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            RetryableFailurePhysicalGoods(() =>                
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculatePhysicalGoodsTaxRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }


        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeFalseRetryableFailure()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst, Address = addr };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "false";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "verer", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            RetryableFailurePhysicalGoods(() =>                 
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculatePhysicalGoodsTaxRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }


        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeFalseRetryableFailure()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "false";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "rgve", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            RetryableFailurePhysicalGoods(() =>                
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculatePhysicalGoodsTaxRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsTaxFakeGetBillingAccountAddressMatchesRetryableFailure()
        {

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    Address addr = new Address { Country = "AUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };
                    List<Address> addresslst = new List<Address>();
                    addresslst.Add(addr);
                    AccountInfo accInf = new AccountInfo { Addresses = addresslst };
                    return accInf;
                }
            };
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            TaxCalculator target = new TaxCalculator(config, billingAgent);
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "fwerf", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            RetryableFailurePhysicalGoods(() =>                 
            {
                try
                {
                    var temp = target.CalculateTax(request);
                }
                catch (PaymentServiceLibraryException px)
                {
                    PaymentException ex = new PaymentException();
                    ex.ExceptionCode = PaymentExceptioncode.PaymentCalculatePhysicalGoodsTaxRetryableFailure;
                    Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
                }
            }, (sh) =>
            {
            }
           );
        }









        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeTrueAckSuccessful()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst, Address = addr };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "vwrevr", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);
            AckSuccessfulPhysicalGoods(() =>             
            {
                    var temp = target.CalculateTax(request);
            }, (sh) =>
            {
            }
           );

        }


        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeTrueAckSuccessful()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "reger", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            AckSuccessfulPhysicalGoods(() =>                 
            {
                var temp = target.CalculateTax(request);
            }, (sh) =>
            {
            }
           );
        }


        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeFalseAckSuccessful()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst, Address = addr };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "false";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "verer", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            AckSuccessfulPhysicalGoods(() =>                 
            {
                var temp = target.CalculateTax(request);
            }, (sh) =>
            {
            }
           );
        }


        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeFalseAckSuccessful()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst };


            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "false";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "rgve", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    accInf.Addresses.Add(request.SKUInfo.AddressInfo);
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            AckSuccessfulPhysicalGoods(() =>                 
            {
                var temp = target.CalculateTax(request);
            }, (sh) =>
            {
            }
           );
        }

        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsTaxFakeGetBillingAccountAddressMatchesAckSuccessful()
        {

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    Address addr = new Address { Country = "AUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };
                    List<Address> addresslst = new List<Address>();
                    addresslst.Add(addr);
                    AccountInfo accInf = new AccountInfo { Addresses = addresslst };
                    return accInf;
                }
            };
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "qwedge";
            Configuration["geographyPath"] = "C:\\Users\\t-pugoe\\Documents\\My_Project\\Payment_Final\\PaymentServiceLibrary\\Geography\\Geography.xml";
            MockedGetConfiguration config = new MockedGetConfiguration()
            {
                GetConfigFunc = () =>
                {
                    TaxCalculatorConfiguration mockedConfig = new TaxCalculatorConfiguration { Config = Configuration };
                    return mockedConfig;
                }
            };
            TaxCalculator target = new TaxCalculator(config, billingAgent);
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676 }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "fwerf", Brand = "Xbox", Locale = "erge", Currency = "hrt" };

            AckSuccessfulPhysicalGoods(() =>                 
            {
                    var temp = target.CalculateTax(request);
            }, (sh) =>
            {
            }
           );
        }
    }
}
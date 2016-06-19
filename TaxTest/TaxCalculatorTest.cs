using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary;
//using Moq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SupplyChain.Care.PaymentModels;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary.Exceptions;
using System.Configuration.Provider;
namespace Microsoft.SupplyChain.Care.Payment.TestTax
{
    [TestClass]
    public class TaxCalculatorTest
    {
        
        [TestMethod]
        public void TaxRequestIsNull()
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
            TaxRequest request = null;
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.TaxRequestIsNull, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxRequestPaymentIdentityInfoIsNull()
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
            LineItem sku = new LineItem();
            TaxRequest request = new TaxRequest { SKUInfo = sku, paymentIdentityInfo = null, OrderType = "gerger", Brand = "GRWEgER", Locale = "erge", Currency = "hrt"};
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.PaymentIdentityIsNull, px.ExceptionCode);
            }


        }
        [TestMethod]
        public void TaxRequestPaymentInstrumentIdIsNull()
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
            LineItem sku = new LineItem();
            PaymentIdentity paymentidentity = new PaymentIdentity();
            TaxRequest request = new TaxRequest { SKUInfo = sku, paymentIdentityInfo = paymentidentity, OrderType = "gerger", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestPaymentInstrumentIdIsNull, px.ExceptionCode);
            }


        }

        [TestMethod]
        public void TaxRequestAccountIdIsNull()
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
            LineItem sku = new LineItem();
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe" };
            TaxRequest request = new TaxRequest { SKUInfo = sku, paymentIdentityInfo = paymentidentity, OrderType = "gerger", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestAccountIdIsNull, px.ExceptionCode);
            }


        }

        [TestMethod]
        public void TaxRequestGuestIdNull()
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
            LineItem sku = new LineItem();
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe" , AccountId = "THrt" };
            TaxRequest request = new TaxRequest { SKUInfo = sku, paymentIdentityInfo = paymentidentity, OrderType = "gerger", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestPUIDIsNull, px.ExceptionCode);
            }


        }
        [TestMethod]
        public void TaxRequestSKUInfoInfoIsNull()
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
            TaxRequest request = new TaxRequest { paymentIdentityInfo = paymentidentity, OrderType = "gerger", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull, px.ExceptionCode);
            }
        }

        [TestMethod]
        public void TaxRequestSKUInfoPriceInfoTaxcodeIsNull()
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
            LineItem sku = new LineItem { PriceInfo = new Price { Amount = 123, Currency = "Rfg3e" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr"};
            TaxRequest request = new TaxRequest { SKUInfo = sku, paymentIdentityInfo = paymentidentity, OrderType = "gerger", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxRequestSKUInfoPriceInfoAmountIsNull()
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
            LineItem sku = new LineItem { PriceInfo = new Price { TaxCode = "ef", Currency = "REfg" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = sku, paymentIdentityInfo = paymentidentity, OrderType = "gerger", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxRequestSKUInfoPriceInfoCurrencyIsNull()
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
            LineItem sku = new LineItem { PriceInfo = new Price { TaxCode = "ef", Amount = 213 } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = sku, paymentIdentityInfo = paymentidentity, OrderType = "gerger", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxRequestSKUInfoSkuIsNull()
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
            LineItem skuInfo = new LineItem { PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "gerger", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxRequestSKUInfoDescriptionIsNull()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "gerger", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxRequestSKUInfoPaymentSkuIsNull()
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
            LineItem skuInfo = new LineItem { Sku = "ER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "gerger", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxRequestSKUInfoAddressInfoIsNull()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "gerger", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxRequestSKUInfoAddressInfoCountryIsNull()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address() };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "gerger", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestCountryIsNull, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxRequestPaymentCountryCodeIsInvalid()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "rthrth" } }; // Substituting with vaues like AUT, BEL, CAN cause exception(ones we will encounter later and fake them) because they are valid
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "gerger", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.PaymentCountryCodeIsInvalid, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxRequestPaymentBrandIsNull()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } }; // Substituting with vaues like AUT, BEL, CAN cause exception(ones we will encounter later and fake them) because they are valid
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "gerger", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestBrandIsNull, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxRequestOrderTypeIsINull()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestOrderTypeIsNull, px.ExceptionCode);
            }
        }

        [TestMethod]
        public void TaxRequestPhysicalGoodsSKuInfoShippingInfoIsNull()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { OrderType = "hge", SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull, px.ExceptionCode);
            }
        }

        [TestMethod]
        public void TaxRequestPhysicalGoodsSKuInfoShippingInfoPaymentSkuIsNull()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem() , Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { OrderType = "hge", SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull, px.ExceptionCode);
            }
        }

        [TestMethod]
        public void TaxRequestPhysicalGoodsSKuInfoShippingInfoAddressInfoIsNull()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PaymentSku = "gfr" }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { OrderType = "hge", SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxRequestPhysicalGoodsSKuInfoShippingInfoAddressInfoCountryIsNull()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PaymentSku = "gfr", AddressInfo = new Address() }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { OrderType = "hge", SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxRequestPhysicalGoodsSKuInfoShippingInfoAddressInfoUnitNumberIsNull()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER",  ShippingInfo = new LineItem { PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { OrderType = "hge", SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull, px.ExceptionCode);
            }
        }

        [TestMethod]
        public void TaxRequestPhysicalGoodsSKuInfoAddressInfoFriendlyNameIsNull()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { OrderType = "hge", SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull, px.ExceptionCode);
            }
        }

        [TestMethod]
        public void TaxRequestPhysicalGoodsSKuInfoShippingInfoPriceInfoIsNull()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv"} };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { OrderType = "hge", SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxRequestPhysicalGoodsSKuInfoShippingInfoPriceInfoCurrencyIsNull()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price(),PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { OrderType = "hge", SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxRequestPhysicalGoodsSKuInfoShippingInfoPriceInfoTaxcodeIsNull()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver" }, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { OrderType = "hge", SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxRequestPhysicalGoodsSKuInfoShippingInfoPriceInfoAmountIsNull()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe"}, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { OrderType = "hge", SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (ValidationException px)
            {
                Assert.AreEqual(PaymentExceptioncode.CalculateTaxRequestSKUInfoIsNull, px.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxConfigurationDigitalGoodsPartnerGuidIsNull()
        {
            //TaxRequestIsNull(() =>
            //{
            IBillingService billingAgent = new MockedBillingService();
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "etyyjtge";
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                Assert.AreEqual(px.ExceptionCode, PaymentExceptioncode.PaymentProviderCalculateTaxException);
            }
        }
        [TestMethod]
        public void TaxConfigurationPhysicalGoodsPartnerGuidIsNull()
        {
            //TaxRequestIsNull(() =>
            //{
            IBillingService billingAgent = new MockedBillingService();
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "etyyjtge";
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676}, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "fer", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                Assert.AreEqual(px.ExceptionCode, PaymentExceptioncode.PaymentProviderCalculateTaxException);
            }
        }
        [TestMethod]
        public void TaxConfigurationDigitalGoodsProductGuidIsNull()
        {
            //TaxRequestIsNull(() =>
            //{
            IBillingService billingAgent = new MockedBillingService();
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "etfgerfgr";
            Configuration["productGuid"] = "";
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                Assert.AreEqual(px.ExceptionCode, PaymentExceptioncode.PaymentProviderCalculateTaxException);
            }
        }

        [TestMethod]
        public void TaxConfigurationPhysicalGoodsProductGuidIsNull()
        {
            //TaxRequestIsNull(() =>
            //{
            IBillingService billingAgent = new MockedBillingService();
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "etfgerfgr";
            Configuration["productGuid"] = "";
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676}, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "bnjmghmjhract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                Assert.AreEqual(px.ExceptionCode, PaymentExceptioncode.PaymentProviderCalculateTaxException);
            }
        }
        [TestMethod]
        public void TaxConfigurationDigitalGoodsIsZipCodeIncludedInCpComparisionIsNull()
        {
            //TaxRequestIsNull(() =>
            //{
            IBillingService billingAgent = new MockedBillingService();
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "";
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                Assert.AreEqual(px.ExceptionCode, PaymentExceptioncode.PaymentProviderCalculateTaxException);
            }
        }
        [TestMethod]
        public void TaxConfigurationPhysicalGoodsIsZipCodeIncludedInCpComparisionIsNull()
        {
            //TaxRequestIsNull(() =>
            //{
            IBillingService billingAgent = new MockedBillingService();
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "";
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676}, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "Shnmhgract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                Assert.AreEqual(px.ExceptionCode, PaymentExceptioncode.PaymentProviderCalculateTaxException);
            }
        }
        [TestMethod]
        public void TaxConfigurationDigitalGoodsShipFromPathIsNull()
        {
            //TaxRequestIsNull(() =>
            //{
            IBillingService billingAgent = new MockedBillingService();
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "";
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                Assert.AreEqual(px.ExceptionCode, PaymentExceptioncode.PaymentProviderCalculateTaxException);
            }
        }
        [TestMethod]
        public void TaxConfigurationPhysicalGoodsShipFromPathIsNull()
        {
            //TaxRequestIsNull(() =>
            //{
            IBillingService billingAgent = new MockedBillingService();
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "";
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676}, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "mgnmact", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                Assert.AreEqual(px.ExceptionCode, PaymentExceptioncode.PaymentProviderCalculateTaxException);
            }
        }
        [TestMethod]
        public void TaxConfigurationDigitalGoodsDatacenterCurrentIsNull()
        {
            //TaxRequestIsNull(() =>
            //{
            IBillingService billingAgent = new MockedBillingService();
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "";
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                Assert.AreEqual(px.ExceptionCode, PaymentExceptioncode.PaymentProviderCalculateTaxException);
            }
        }
        [TestMethod]
        public void TaxConfigurationPhysicalGoodsDatacenterCurrentIsNull()
        {
            //TaxRequestIsNull(() =>
            //{
            IBillingService billingAgent = new MockedBillingService();
            Dictionary<string, string> Configuration = new Dictionary<string, string>();
            Configuration["partnerGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["productGuid"] = "11112222-3333-4444-5555-666677778888";
            Configuration["isZipCodeIncludedInCpComparision"] = "true";
            Configuration["shipFromPath"] = "yhtyrhty";
            Configuration["datacenterCurrent"] = "";
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676}, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "jyjyact", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                Assert.AreEqual(px.ExceptionCode, PaymentExceptioncode.PaymentProviderCalculateTaxException);
            }
        }
        [TestMethod]
        public void TaxCPServiceDigitalGoodsAgentaccountInfoGetIsNull()
        {
            //TaxRequestIsNull(() =>
            //{
            IBillingService billingAgent = new MockedBillingService();
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (Exception px)
            {
                Assert.AreEqual(px.Message, "Could not retrieve account details for the puid/GuestID passed.");
            }
        }
        [TestMethod]
        public void TaxCPServicePhysicalGoodsAgentaccountInfoGetIsNull()
        {
            //TaxRequestIsNull(() =>
            //{
            IBillingService billingAgent = new MockedBillingService();
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676}, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            PaymentIdentity paymentidentity = new PaymentIdentity { PaymentInstrumentId = "egherhe", AccountId = "THrt", GuestId = "RFGEr", Puid = "fgr" };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "gujtyract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };
            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (Exception px)
            {
                Assert.AreEqual(px.Message, "Could not retrieve account details for the puid/GuestID passed.");
            }
        }
        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsTaxFakeGetBillingAccountAddressMatches()
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

            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                PaymentException ex = new PaymentException("UnknownGeneralException");
                ex.ExceptionCode = PaymentExceptioncode.UnknownGeneralException;
                Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsTaxFakeGetBillingAccountAddressMatches()
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

            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                PaymentException ex = new PaymentException("UnknownGeneralException");
                ex.ExceptionCode = PaymentExceptioncode.UnknownGeneralException;
                Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsTaxFakeGetBillingUpdateBillingIsNull()
        {

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ServiceContract", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                PaymentException ex = new PaymentException("UnknownGeneralException");
                ex.ExceptionCode = PaymentExceptioncode.PaymentProviderCalculateTaxException;
                Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsTaxFakeGetBillingUpdateBillingIsNull()
        {

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676}, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "rgferef", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                PaymentException ex = new PaymentException("UnknownGeneralException");
                ex.ExceptionCode = PaymentExceptioncode.PaymentProviderCalculateTaxException;
                Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeFalse()
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

            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                PaymentException ex = new PaymentException("UnknownGeneralException");
                ex.ExceptionCode = PaymentExceptioncode.UnknownGeneralException;
                Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeFalse()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676}, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
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

            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                PaymentException ex = new PaymentException("UnknownGeneralException");
                ex.ExceptionCode = PaymentExceptioncode.UnknownGeneralException;
                Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeFalse()
        {
            Address addr = new Address { Country = "AdUT", FirstName = "Rahul", LastName = "Kumar", AddressId = "EGFer" };//accountid must be same in all test cases
            List<Address> addresslst = new List<Address>();
            addresslst.Add(addr);
            AccountInfo accInf = new AccountInfo { Addresses = addresslst , Address = addr};


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

            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                PaymentException ex = new PaymentException("UnknownGeneralException");
                ex.ExceptionCode = PaymentExceptioncode.UnknownGeneralException;
                Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
            }
        }

        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeFalse()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676}, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
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

            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                PaymentException ex = new PaymentException("UnknownGeneralException");
                ex.ExceptionCode = PaymentExceptioncode.UnknownGeneralException;
                Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeTrue()
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

            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                PaymentException ex = new PaymentException("UnknownGeneralException");
                ex.ExceptionCode = PaymentExceptioncode.UnknownGeneralException;
                Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeTrue()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676}, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
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

            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                PaymentException ex = new PaymentException("UnknownGeneralException");
                ex.ExceptionCode = PaymentExceptioncode.UnknownGeneralException;
                Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeTrue()
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

            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                PaymentException ex = new PaymentException("UnknownGeneralException");
                ex.ExceptionCode = PaymentExceptioncode.UnknownGeneralException;
                Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeTrue()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676}, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
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

            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                PaymentException ex = new PaymentException("UnknownGeneralException");
                ex.ExceptionCode = PaymentExceptioncode.UnknownGeneralException;
                Assert.AreEqual(px.ExceptionCode, ex.ExceptionCode);
            }
        }
        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeTrueAddressNull()
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
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                bool b = true;
                PaymentException ex = new PaymentException("Shipping address is not found in user profile.");
                Assert.AreEqual(px.Message.StartsWith(ex.Message), b);
            }
        }

        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountInfoAddrNullIsZipCOdeTrueAddressNull()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676}, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "ewfgwe", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                bool b = true;
                PaymentException ex = new PaymentException("Shipping address is not found in user profile.");
                Assert.AreEqual(px.Message.StartsWith(ex.Message), b);
            }
        }
        [TestMethod]
        public void TaxPayment_CalculateDigitalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeTrueAddressNull()
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
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                bool b = true;
                PaymentException ex = new PaymentException("Shipping address is not found in user profile.");
                Assert.AreEqual(px.Message.StartsWith(ex.Message), b);
            }
        }
        [TestMethod]
        public void TaxPayment_CalculatePhysicalGoodsCPServiceAgentMatchedNullAccountAddrInfoNotNullIsZipCOdeTrueAddressNull()
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
            LineItem skuInfo = new LineItem { Sku = "ER", PaymentSku = "ERFER", ShippingInfo = new LineItem { PriceInfo = new Price { Currency = "gver", TaxCode = "FWe", Amount = 676}, PaymentSku = "gfr", AddressInfo = new Address { Country = "AUT", UnitNumber = "grr" } }, Description = "FG", PriceInfo = new Price { TaxCode = "ef", Amount = 213, Currency = "dg" }, AddressInfo = new Address { Country = "AUT", FriendlyName = "Gverfgv" } };
            TaxRequest request = new TaxRequest { SKUInfo = skuInfo, paymentIdentityInfo = paymentidentity, OrderType = "regrerg", Brand = "GRWEgER", Locale = "erge", Currency = "hrt" };

            MockedBillingService billingAgent = new MockedBillingService()
            {
                GetBillingAccountFunc = (a, b) =>
                {
                    return accInf;
                },
                UpdateBillingAccountFunc = (a, b, c, d) =>
                {
                    return accInf;
                }
            };

            TaxCalculator target = new TaxCalculator(config, billingAgent);

            try
            {
                var temp = target.CalculateTax(request);
            }
            catch (PaymentServiceLibraryException px)
            {
                bool b = true;
                PaymentException ex = new PaymentException("Shipping address is not found in user profile.");
                Assert.AreEqual(px.Message.StartsWith(ex.Message), b);
            }
        }

    }
}

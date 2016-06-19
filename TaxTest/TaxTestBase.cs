using Microsoft.SupplyChain.Care.PaymentModels;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary.CP;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SupplyChain.Care.PaymentModels;
using System.Collections.Generic;
using CP = Microsoft.SupplyChain.Care.Payment.ServiceLibrary.CP;
using System;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary.Fakes;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary.CP.Fakes;

namespace Microsoft.SupplyChain.Care.Payment.TestTax
{
    public class TaxTestBase
    {
        public static Action<Action, Action<PurchaseContentResponse>> AckSuccessful = (b, validate) =>
        {

            using (ShimsContext.Create())
            {
                ShimCPServiceAgent.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    PurchaseContentPurchaseContentRequest = req =>
                    {
                        var response = new PurchaseContentResponse
                        {
                            Ack = CP.AckCode.Success,
                            TotalAmountWithoutTax = 454,
                            TotalTax = 345
                        };
                        validate(response);
                        return response;
                    }
                };
                b();
            };
        };
        public static Action<Action, Action<PurchaseContentResponse>> InvalidAck = (b, validate) =>
        {

            using (ShimsContext.Create())
            {
                ShimCPServiceAgent.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    PurchaseContentPurchaseContentRequest = req =>
                    {
                        var response = new PurchaseContentResponse
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
        public static Action<Action, Action<PurchaseContentResponse>> NonRetryableFailure = (b, validate) =>
        {

            using (ShimsContext.Create())
            {
                ShimCPServiceAgent.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    PurchaseContentPurchaseContentRequest = req =>
                    {
                        var response = new PurchaseContentResponse
                        {
                            Ack = CP.AckCode.NonRetryableFailure

                        };
                        validate(response);
                        return response;
                    }
                };
                b();
            };
        };
        public static Action<Action, Action<PurchaseContentResponse>> RetryableFailure = (b, validate) =>
        {

            using (ShimsContext.Create())
            {
                ShimCPServiceAgent.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    PurchaseContentPurchaseContentRequest = req =>
                    {
                        var response = new PurchaseContentResponse
                        {
                            Ack = CP.AckCode.RetryableFailure

                        };
                        validate(response);
                        return response;
                    }
                };
                b();
            };
        };

        public static Action<Action, Action<PurchasePhysicalGoodsResponse>> InvalidInputPhysicalGoods = (b, validate) =>
        {

            using (ShimsContext.Create())
            {
                ShimCPServiceAgent.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    PurchasePhysicalGoodsPurchasePhysicalGoodsRequest = req =>
                    {
                        var response = new PurchasePhysicalGoodsResponse
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

        public static Action<Action, Action<PurchasePhysicalGoodsResponse>> NonRetryableFailurePhysicalGoods = (b, validate) =>
        {

            using (ShimsContext.Create())
            {
                ShimCPServiceAgent.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    PurchasePhysicalGoodsPurchasePhysicalGoodsRequest = req =>
                    {
                        var response = new PurchasePhysicalGoodsResponse
                        {
                            Ack = CP.AckCode.NonRetryableFailure
                        };
                        validate(response);
                        return response;
                    }
                };
                b();
            };
        };

        public static Action<Action, Action<PurchasePhysicalGoodsResponse>> RetryableFailurePhysicalGoods = (b, validate) =>
        {

            using (ShimsContext.Create())
            {
                ShimCPServiceAgent.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    PurchasePhysicalGoodsPurchasePhysicalGoodsRequest = req =>
                    {
                        var response = new PurchasePhysicalGoodsResponse
                        {
                            Ack = CP.AckCode.RetryableFailure
                        };
                        validate(response);
                        return response;
                    }
                };
                b();
            };
        };
        public static Action<Action, Action<PurchasePhysicalGoodsResponse>> AckSuccessfulPhysicalGoods = (b, validate) =>
        {
            CP.TaxEntry entry = new CP.TaxEntry { Rate = 2, Jurisdiction = "Ger" };
            CP.TaxEntry[] taxEntries = new CP.TaxEntry[2];
            taxEntries[0] = entry;
            CP.TaxEntry entry2 = new CP.TaxEntry { Rate = 3, Jurisdiction = "Ggvrfver" };
            taxEntries[1] = entry2;
            PurchasePhysicalGoodsOutput physicalGoodOutput = new PurchasePhysicalGoodsOutput { ExternalProductItemId  = "REGe", TaxEntries = taxEntries};
            FeesAndServiceChargesOutput feesAndCharges = new FeesAndServiceChargesOutput { ExternalProductItemId = "REGe", TaxEntries = taxEntries };

            PurchaseProductItemOutput[] purchaseProductItemOutputSet = new PurchaseProductItemOutput[2];
            purchaseProductItemOutputSet[0] = physicalGoodOutput;
            purchaseProductItemOutputSet[1] = feesAndCharges;
            using (ShimsContext.Create())
            {
                ShimCPServiceAgent.AllInstances.GetCpClient = l => new StubICommerceService
                {
                    PurchasePhysicalGoodsPurchasePhysicalGoodsRequest = req =>
                    {
                        var response = new PurchasePhysicalGoodsResponse
                        {
                            Ack = CP.AckCode.Success,
                            PurchaseProductItemOutputSet = purchaseProductItemOutputSet
                        };
                        validate(response);
                        return response;
                    }
                };
                b();
            };
        };
    }
}


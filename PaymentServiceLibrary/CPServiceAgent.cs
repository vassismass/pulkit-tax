using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ServiceModel;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.SupplyChain.Care.PaymentModels;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary.Exceptions;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary.Extension;
using Microsoft.SupplyChain.Care.Payment.ServiceLibrary.CP;
namespace Microsoft.SupplyChain.Care.Payment.ServiceLibrary
{
    #region Using

    #endregion

    public class CPServiceAgent
    {
        internal const int DecimalRoundDigit = 4;
        private const string CPPaymentIDNullException = "Payment Id is Null in CP Purchase Response";
        private const string ShippingAddressNotFound = "Shipping address is not found in user profile.";
        readonly static List<int> LstAddressErrorCodes = new List<int> { 60001, 60011, 60012, 60013, 60014, 60015, 60016, 60017, 60018, 60019, 60029, 60030, 60041, 60042, 10021 };
        private ICommerceService cpclient = null;
        private CPAgentInfo Info;
        private ICommerceService GetCpClient()
        {
            return new CP.CommerceServiceClient();
        }
        public CPServiceAgent(CPAgentInfo Inf)
        {
                Info = new CPAgentInfo();
                this.Info.productGuid = Inf.productGuid;
                this.Info.isZipCodeIncludedInCpComparision = Inf.isZipCodeIncludedInCpComparision;
                this.Info.dataCenter = Inf.dataCenter;
                this.Info.shipFromPath = Inf.shipFromPath;
                this.Info.partnerGuid = Inf.partnerGuid;            
        }

        /// <summary>
        /// 
        /// </summary>        
        internal List<TaxInfo> CalculateTax(string addressid, TaxRequest request)
        {
            try
            {
                return request.OrderType == "ServiceContract"
                           ? CalculateDigitalGoodsTax(addressid, request.paymentIdentityInfo, request.SKUInfo)
                           : CalculatePhysicalGoodsTax(addressid, request.paymentIdentityInfo, request.SKUInfo, request.Brand);
            }
            catch (Exception ex)
            {
                var context = this.GetCurrentMethodContext(addressid, request.OrderType, request.paymentIdentityInfo.PaymentInstrumentId, request.paymentIdentityInfo.AccountId, request.SKUInfo, request.Locale, request.Currency);
                HandleException(ex, context);
                return null;
            }
        }
        /// <summary>
        /// 
        /// To get PUID or Anonymous ID for GuestCheck Out 
        /// </summary>
        /// <param name="paymentIdentity"></param>
        /// <returns></returns>
        internal static Identity SelectIdentity(PaymentIdentity paymentIdentity)
        {
            var computeRequester = new Identity();

            if (!string.IsNullOrEmpty(paymentIdentity.GuestId))
                computeRequester = new Identity { IdentityValue = paymentIdentity.GuestId, IdentityType = CpConstants.AnonymousId };
            else
                computeRequester = new Identity { IdentityValue = paymentIdentity.Puid, IdentityType = CpConstants.Puid };

            return computeRequester;
        }

        /// <summary>
       
        /// 
        internal string GetAddressId(AccountInfo accountInfo, TaxRequest request, IBillingService billingAgent)
        {
            var addressId = default(string);     
            var matchedAddress = PaymentModels.Address.FindAddress(accountInfo.Addresses, request.SKUInfo.AddressInfo);//both to have addressid if they match
            if (matchedAddress == null)
            {
                //Update Billing Account
                AccountInfo updateAccountInfo = new AccountInfo();

                updateAccountInfo.AccountId = accountInfo.AccountId;// need to ensure it has friendly name and accountId
                updateAccountInfo.Address = request.SKUInfo.AddressInfo;//need to ensure it has firstname & lastname
                if (accountInfo.Address != null)
                {
                    updateAccountInfo.Address.FriendlyName = accountInfo.Address.FriendlyName;
                }
                else
                {
                    updateAccountInfo.Address.FriendlyName = updateAccountInfo.Address.FirstName + updateAccountInfo.Address.LastName;
                }
                IBillingService bill = billingAgent;
                accountInfo = bill.UpdateBillingAccount(updateAccountInfo, request.paymentIdentityInfo, request.Locale, request.Currency);

                if (this.Info.isZipCodeIncludedInCpComparision)
                {
                    var address = Microsoft.SupplyChain.Care.PaymentModels.Address.FindAddress(accountInfo.Addresses, updateAccountInfo.Address);//accountinfo should have addresses
                    if (address != null)
                    {
                        addressId = address.AddressId;
                    }
                    else
                    {
                        throw new PaymentAddressException(ShippingAddressNotFound + "\n" + Serialize(updateAccountInfo.Address) + "\n" + Serialize(accountInfo.Addresses));
                    }
                }
                else
                {
                    //addressId = accountInfo.Addresses.Where(ad => ad.Equals(updateAccountInfo.Address)).First().AddressId;
                    var matchedResults = accountInfo.Addresses.Where(ad => ad.Equals(updateAccountInfo.Address));
                    if (matchedResults.Any())
                    {
                        addressId = matchedResults.First().AddressId;
                    }
                    //else generate an exception
                }
            }
            else
            {
                addressId = matchedAddress.AddressId;
            }

            return addressId;
        }

        /// <summary>
        /// 
        //done
        /// </summary>
        internal string GetAddressId(TaxRequest request, IBillingService billingAgent)
        {
            var addressId = default(string);
            PaymentException payex = null;
            //Get Billing Account
            IBillingService bill = billingAgent;
            var accountInfoGet = bill.GetBillingAccount(request.SKUInfo.AddressInfo.Country, request.paymentIdentityInfo);

            //Compare Address
            //commented for testing
            if (accountInfoGet != null)
            {
                addressId = GetAddressId(accountInfoGet, request, billingAgent);
            }
            else
            {
                payex = new PaymentException("Could not retrieve account details for the puid/GuestID passed.");
                payex.PaymentServiceLibraryContext.Add("accountId", request.paymentIdentityInfo.AccountId);

                payex.PaymentServiceLibraryContext.Add("puid/GuestID", (!string.IsNullOrEmpty(request.paymentIdentityInfo.Puid) ? request.paymentIdentityInfo.Puid : request.paymentIdentityInfo.GuestId));
                throw payex;
            }

            return addressId;
        }

        #region Private Methods
        /// <summary>
        /// Calculate Tax Details for Digital Goods
        /// </summary>
        /// <param name="paymentInstrumentId"></param>
        /// <param name="accountId"></param>
        /// <param name="puid"></param>
        /// <param name="skuInfo"></param>
        /// <returns></returns>
        private List<TaxInfo> CalculateDigitalGoodsTax(string addressid, PaymentIdentity paymentIdentity, LineItem skuInfo)
        {
            PaymentException payex = null;
            string identityValue = string.Empty;

            try
            {
                var response = new List<TaxInfo>();


                cpclient = GetCpClient();
                var getIdentity = SelectIdentity(paymentIdentity);
                identityValue = getIdentity.IdentityValue;
                string identityType = getIdentity.IdentityType;

                var computeRequest = skuInfo.ConvertToPurchaseContentRequest(this.Info.dataCenter, this.Info.partnerGuid);
                computeRequest.BillingInfo = new BillingInfo
                {
                    BillingMode = BillingMode.ImmediateSettle,
                    PaymentMethod = new RegisteredPaymentMethod { PaymentMethodId = paymentIdentity.PaymentInstrumentId }
                };
                computeRequest.AccountId = paymentIdentity.AccountId;
                computeRequest.Requester = new Identity { IdentityValue = identityValue, IdentityType = identityType };
                computeRequest.PurchaseContext = new PurchaseContext
                {
                    Timestamp = DateTime.UtcNow,
                    ComputeOnly = true,
                    AddressId = addressid
                };

                computeRequest.PurchaseContext.ProductGuid = this.Info.productGuid;
                computeRequest.TrackingGuid = Guid.NewGuid();

                var purchaseResponse = cpclient.PurchaseContent(computeRequest);

                if (purchaseResponse.Ack == AckCode.Success)
                {
                    var taxinformation = new TaxInfo
                    {
                        Sku = skuInfo.Sku,
                        TotalAmoutWithoutTax = purchaseResponse.TotalAmountWithoutTax,
                        TotalTax = purchaseResponse.TotalTax
                    };
                    response.Add(taxinformation);
                    return response;
                }
                switch (purchaseResponse.Ack)
                {
                    case AckCode.InvalidInput:
                        payex = new PaymentException(GetCPExceptionMessage(purchaseResponse))
                        {
                            ExceptionCode =
                                PaymentExceptioncode.PaymentCalculateDigitalGoodsTaxInvalidInput
                        };
                        break;
                    case AckCode.NonRetryableFailure:
                        payex = new PaymentException(GetCPExceptionMessage(purchaseResponse))
                        {
                            ExceptionCode =
                                PaymentExceptioncode.PaymentCalculateDigitalGoodsTaxNonRetryableFailure
                        };
                        break;
                    case AckCode.RetryableFailure:
                        payex = new PaymentException(GetCPExceptionMessage(purchaseResponse))
                        {
                            ExceptionCode =
                                PaymentExceptioncode.PaymentCalculateDigitalGoodsTaxRetryableFailure
                        };
                        break;
                }

                if (payex != null)
                {
                    var context = this.GetCurrentMethodContext(addressid, paymentIdentity.PaymentInstrumentId, paymentIdentity.AccountId, identityValue, skuInfo);
                    payex.PaymentServiceLibraryContext = context;
                    throw payex;
                }
            }
            catch (Exception ex)
            {
                var context = this.GetCurrentMethodContext(addressid, paymentIdentity.PaymentInstrumentId, paymentIdentity.AccountId, identityValue, skuInfo);
                HandleException(ex, context);
            }
            finally
            {
                CloseOrAbortProxy(cpclient);
            }
            return null;
        }

        /// <summary>
        /// Calculate Tax Details for Physical Goods
        /// </summary>
        /// <param name="paymentInstrumentId"></param>
        /// <param name="accountId"></param>
        /// <param name="puid"></param>
        /// <param name="skuInfo"></param>
        /// <returns></returns>
        private List<TaxInfo> CalculatePhysicalGoodsTax(string addressid, PaymentIdentity paymentIdentity, LineItem skuInfo, string brand)
        {
            PaymentException payex = null;
            string identityValue = string.Empty;
            try
            {
                var taxInformationList = new List<TaxInfo>();


                this.cpclient = GetCpClient();
                var getIdentity = SelectIdentity(paymentIdentity);
                identityValue = getIdentity.IdentityValue;
                string identityType = getIdentity.IdentityType;

                var computeRequest = skuInfo.ConvertToPurchaseRequest(this.Info.dataCenter, this.Info.partnerGuid, this.Info.shipFromPath, brand);
                computeRequest.BillingInfo = new BillingInfo
                {
                    BillingMode = BillingMode.AuthorizedSettle,
                    PaymentMethod = new RegisteredPaymentMethod { PaymentMethodId = paymentIdentity.PaymentInstrumentId }
                };
                computeRequest.AccountId = paymentIdentity.AccountId;
                computeRequest.Requester = new Identity { IdentityValue = identityValue, IdentityType = identityType };
                computeRequest.PurchaseContext = new PurchaseContext
                {
                    Timestamp = DateTime.UtcNow,
                    ComputeOnly = true,
                    AddressId = addressid
                };

                computeRequest.PurchaseContext.ProductGuid = this.Info.productGuid;
                var purchaseResponse = cpclient.PurchasePhysicalGoods(computeRequest);

                if (purchaseResponse.Ack == AckCode.Success)
                {
                    foreach (var itemOutput in purchaseResponse.PurchaseProductItemOutputSet)
                    {
                        if (itemOutput is PurchasePhysicalGoodsOutput)
                        {
                            var item = itemOutput as PurchasePhysicalGoodsOutput;
                            var taxInformation = new TaxInfo();
                            taxInformation.Sku = item.ExternalProductItemId;
                            taxInformation.TotalAmount = skuInfo.PriceInfo.Amount;
                            taxInformation.TotalTax = item.TaxEntries.Sum(taxentry => (Math.Round(taxentry.Rate * taxInformation.TotalAmount, DecimalRoundDigit)));
                            taxInformation.TaxEntries =
                                new List<Microsoft.SupplyChain.Care.PaymentModels.TaxEntry>
                                    ();
                            foreach (var taxEntry in item.TaxEntries)
                            {
                                taxInformation.TaxEntries.Add(
                                    new Microsoft.SupplyChain.Care.PaymentModels.TaxEntry
                                    {
                                        Tax = taxInformation.TotalAmount * taxEntry.Rate,
                                        Type = taxEntry.Jurisdiction,
                                        Rate = taxEntry.Rate
                                    });
                            }
                            taxInformationList.Add(taxInformation);
                        }
                        if (itemOutput is FeesAndServiceChargesOutput)
                        {
                            var item = itemOutput as FeesAndServiceChargesOutput;
                            var taxInformation = new TaxInfo();
                            taxInformation.Sku = item.ExternalProductItemId;
                            taxInformation.TotalAmount = skuInfo.ShippingInfo.PriceInfo.Amount;
                            taxInformation.TotalTax = item.TaxEntries.Sum(taxentry => (Math.Round(taxentry.Rate * taxInformation.TotalAmount, DecimalRoundDigit)));
                            taxInformation.TaxEntries = new List<Microsoft.SupplyChain.Care.PaymentModels.TaxEntry>();
                            foreach (var taxEntry in item.TaxEntries)
                            {
                                taxInformation.TaxEntries.Add(new Microsoft.SupplyChain.Care.PaymentModels.TaxEntry { Tax = taxInformation.TotalAmount * taxEntry.Rate, Type = taxEntry.Jurisdiction, Rate = taxEntry.Rate });
                            }
                            taxInformationList.Add(taxInformation);
                        }
                    }
                    return taxInformationList;
                }

                switch (purchaseResponse.Ack)
                {
                    case AckCode.InvalidInput:
                        payex = new PaymentException(GetCPExceptionMessage(purchaseResponse))
                        {
                            ExceptionCode =
                                PaymentExceptioncode.PaymentCalculatePhysicalGoodsTaxInvalidInput
                        };
                        break;
                    case AckCode.NonRetryableFailure:
                        payex = new PaymentException(GetCPExceptionMessage(purchaseResponse))
                        {
                            ExceptionCode =
                                PaymentExceptioncode.PaymentCalculatePhysicalGoodsTaxNonRetryableFailure
                        };
                        break;
                    case AckCode.RetryableFailure:
                        payex = new PaymentException(GetCPExceptionMessage(purchaseResponse))
                        {
                            ExceptionCode =
                                PaymentExceptioncode.PaymentCalculatePhysicalGoodsTaxRetryableFailure
                        };
                        break;
                }

                if (payex != null)
                {
                    var context = this.GetCurrentMethodContext(addressid, paymentIdentity.PaymentInstrumentId, paymentIdentity.AccountId, identityValue, skuInfo);
                    payex.PaymentServiceLibraryContext = context;
                    throw payex;
                }
            }
            catch (Exception ex)
            {
                var context = this.GetCurrentMethodContext(addressid, paymentIdentity.PaymentInstrumentId, paymentIdentity.AccountId, identityValue, skuInfo);
                HandleException(ex, context);
            }
            finally
            {
                CloseOrAbortProxy(cpclient);
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
       
        /// 
        /// </summary>
        private string GetCPExceptionMessage(AbstractResponse CPResponse)
        {
            string strCPResponse = "";
            if (CPResponse != null)
            {
                if (CPResponse.Error != null)
                {
                    strCPResponse = System.String.Format("{1} (CP ErrorCode:{0})",
                       CPResponse.Error.ErrorCode, CPResponse.Error.Detail);

                }
            }
            return strCPResponse;
        }

        /// <summary>
        /// Clean the WCF proxy
        /// </summary>
        /// <param name="proxy"></param>
        private void CloseOrAbortProxy(ICommerceService proxy)
        {
            if (proxy != null)
            {
                if (proxy.State != CommunicationState.Faulted && proxy.State != CommunicationState.Closed)
                {
                    try
                    {
                        proxy.Close();
                    }
                    catch
                    {
                        proxy.Abort();
                    }
                }
                else
                {
                    proxy.Abort();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void HandleException(Exception exception, Dictionary<string, string> context)
        {
            PaymentServiceLibraryException derived = null;

            if (exception is EndpointNotFoundException)
            {
                derived = new PaymentException(exception.Message, PaymentExceptioncode.PaymentEndpointNotFoundException,
                                                      exception);
            }
            else if (exception is TimeoutException)
            {
                derived = new PaymentException(exception.Message, PaymentExceptioncode.PaymentTimeoutException,
                                                      exception);
            }

            else if (exception is System.Web.Services.Protocols.SoapException)
            {
                derived = new PaymentException(exception.Message, PaymentExceptioncode.PaymentSoapException,
                                                      exception);
            }
            else if (exception is ConfigurationException)
            {
                derived = new PaymentException(exception.Message, PaymentExceptioncode.CPRequiredConfigValuesUnavailable,
                                                      exception);
            }
            else if (exception is PaymentException)
            {
                derived = new PaymentException(exception.Message, ((PaymentServiceLibraryException)(exception)).ExceptionCode,
                                                      exception);
            }
            else
            {
                derived = exception as PaymentIntegrationException ??
                          new PaymentException(exception.Message, PaymentExceptioncode.UnknownGeneralException, exception);
            }

            derived.AddToExistingContext(context);
            throw derived;
        }

        /// <summary>
        /// 
        /// </summary>
        private static string Serialize(object obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                var xs = new XmlSerializer(obj.GetType());
                var xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                xs.Serialize(xmlTextWriter, obj);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }
        #endregion
    }
}

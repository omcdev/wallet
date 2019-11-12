﻿// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.

using OmniCoin.DTO;
using OmniCoin.Models;
using OmniCoin.ServiceAgent;
using OmniCoin.Utility;
using OmniCoin.Utility.Api;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OmniCoin.Business
{
    public static class PaymentRequestApi
    {
        public static async Task<ApiResponse> CreateNewPaymentRequest(string tag, long amount, string comment)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                Accounts accounts = new Accounts();
                PaymentRequest request = new PaymentRequest();
                PayRequest pay = new PayRequest();
                AccountInfoOM accountInfo = await accounts.GetNewAddress(tag);
                PayRequestOM result = await request.CreateNewPaymentRequest(accountInfo.Address, tag, amount, comment);
                if (result != null)
                {
                    pay.AccountId = result.AccountId;
                    pay.Amount = result.Amount;
                    pay.Comment = result.Comment;
                    pay.Id = result.Id;
                    pay.Tag = result.Tag;
                    pay.Timestamp = result.Timestamp;
                    response.Result = Newtonsoft.Json.Linq.JToken.FromObject(pay);
                }
                else
                {
                    response.Result = null;
                }
            }
            catch (ApiCustomException ex)
            {
                Logger.Singleton.Error(ex.ToString());
                response.Error = new ApiError(ex.ErrorCode, ex.ToString());
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error(ex.ToString());
                response.Error = new ApiError(ex.HResult, ex.ToString());
            }
            return response;
        }

        public static async Task<ApiResponse> GetAllPaymentRequests()
        {
            ApiResponse response = new ApiResponse();
            try
            {
                PaymentRequest request = new PaymentRequest();
                List<PayRequest> list = new List<PayRequest>();
                PayRequestOM[] result = await request.GetAllPaymentRequests();
                if (result != null)
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        list.Add(new PayRequest()
                        {
                            AccountId = result[i].AccountId,
                            Amount = result[i].Amount,
                            Comment = result[i].Comment,
                            Id = result[i].Id,
                            Tag = result[i].Tag,
                            Timestamp = result[i].Timestamp
                        });
                    }

                    response.Result = Newtonsoft.Json.Linq.JToken.FromObject(list);
                }
                else
                {
                    response.Result = null;
                }
            }
            catch (ApiCustomException ex)
            {
                Logger.Singleton.Error(ex.ToString());
                response.Error = new ApiError(ex.ErrorCode, ex.ToString());
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error(ex.ToString());
                response.Error = new ApiError(ex.HResult, ex.ToString());
            }
            return response;
        }

        public static async Task<ApiResponse> DeletePaymentRequestsByIds(long[] ids)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                PaymentRequest request = new PaymentRequest();
                await request.DeletePaymentRequestsByIds(ids);
            }
            catch (ApiCustomException ex)
            {
                Logger.Singleton.Error(ex.ToString());
                response.Error = new ApiError(ex.ErrorCode, ex.ToString());
            }
            catch (Exception ex)
            {
                Logger.Singleton.Error(ex.ToString());
                response.Error = new ApiError(ex.HResult, ex.ToString());
            }
            return response;
        }
    }
}

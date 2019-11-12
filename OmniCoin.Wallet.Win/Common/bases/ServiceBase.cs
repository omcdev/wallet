﻿// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Utility.Api;
using OmniCoin.Wallet.Win.Common.Proxys;
using OmniCoin.Wallet.Win.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace OmniCoin.Wallet.Win.Common
{
    public abstract class ServiceBase<T> : MarshalByRefObject where T : class
    {
        private static T _default;

        public static T Default
        {
            get
            {
                if (_default == null)
                    _default = TransparentProxy.Create<T>();
                return _default;
            }
        }
        
        protected Result<T1> GetResult<T1>(ApiResponse apiResponse)
        {
            Result<T1> result = new Result<T1>();
            result.IsFail = true;
            result.ApiResponse = apiResponse;
            if (apiResponse == null || apiResponse.HasError)
                return result;

            result.IsFail = apiResponse.HasError;
            result.Value = apiResponse.GetResult<T1>();
            
            return result;
        }

        protected Result GetResult(ApiResponse apiResponse)
        {
            Result result = new Result();
            result.IsFail = true;
            result.ApiResponse = apiResponse;
            if (apiResponse == null || apiResponse.HasError)
                return result;

            result.IsFail = apiResponse.HasError;
            
            return result;
        }

        protected ApiResponse GetResponseResult(Task<ApiResponse> apiResponseTask)
        {
            ApiResponse result = null;

            if (apiResponseTask == null)
                return null;
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);
            var task = Task.Factory.StartNew(async () =>
            {
                result = await apiResponseTask;
                autoResetEvent.Set();
            });
            task.Wait();
            autoResetEvent.WaitOne();
            return result;
        }
    }
}

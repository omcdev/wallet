﻿// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.

namespace OmniCoin.Wallet.Win.Common.interfaces
{
    public delegate void MonitorCallBackHandle<T>(T outParam);
    public interface IServiceMonitor<T> : IServiceMonitor
    {
        event MonitorCallBackHandle<T> MonitorCallBack;
    }

    public interface IServiceMonitor
    {
        void Start(int interval);
        void Stop();
    }

}

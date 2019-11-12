﻿// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Wallet.Win.Common.interfaces;
using System.Collections.Generic;

namespace OmniCoin.Wallet.Win.Biz.Monitor
{
    public sealed class ServiceMonitor
    {
        public static List<IServiceMonitor> Monitors { get; } = new List<IServiceMonitor>();

        public static void StopAll()
        {
            if (Monitors != null)
            {
                Monitors.ForEach(x => x.Stop());
            }
        }
    }
}

// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.ServiceAgent;
using OmniCoin.Wallet.Win.Biz.Services;
using OmniCoin.Wallet.Win.Common.Utils;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace OmniCoin.Wallet.Win.Biz.Monitor
{
    public class NodeMonitor : ServiceMonitorBase<bool?>
    {
        private static NodeMonitor _default;

        public static NodeMonitor Default
        {
            get
            {
                if (_default == null)
                    _default = new NodeMonitor();
                return _default;
            }
        }
        
        public bool Set_NetIsActive = true;

        protected override bool? ExecTaskAndGetResult()
        {
            if (!Set_NetIsActive)
                return null;
            return NodeIsRunning();
        }

        public bool NodeIsRunning()
        {
            var ls = ProcessUtil.Find("dotnet.exe", OmniCoinSetting.NodeRunParams);
            return ls.Any();
        }

        public void ActiveNode()
        {
            var tcpPorts = IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections().Select(x => x.LocalEndPoint);
            var isActiveNode = tcpPorts.Any(x => x.Port == OmniCoinSetting.NodeAPIPort);
            if (!isActiveNode)
                NetWorkService.Default.SetNetworkActive(true);
        }
    }
}

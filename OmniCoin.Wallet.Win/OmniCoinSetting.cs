// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniCoin.Wallet.Win
{
    public enum NetworkType
    {
        Mainnet,
        TestNet
    }
    
    public class OmniCoinSetting
    {
        private static NetworkType _currentNetworkType = NetworkType.TestNet;

        public static NetworkType CurrentNetworkType
        {
            get
            {
                return _currentNetworkType;
            }
            set
            {
                _currentNetworkType = value;
                WalletNetwork.SetNetWork(_currentNetworkType == NetworkType.TestNet);
            }
        }

        private const int NodeAPIPort_Test = 58804;
        private const int NodeAPIPort_Main = 58803;

        private const int NodePort_Test = 58802;
        private const int NodePort_Main = 58801;

        public static int NodeAPIPort
        {
            get
            {
                var port = CurrentNetworkType == NetworkType.TestNet ? NodeAPIPort_Test : NodeAPIPort_Main;
                return port;
            }
        }
        
        public static int NodePort
        {
            get
            {
                var port = CurrentNetworkType == NetworkType.TestNet ? NodePort_Test : NodePort_Main;
                return port;
            }
        }

        public static string NodeApiUrl
        {
            get
            {
                var apiUrl = string.Format("http://localhost:{0}", NodeAPIPort);
                return apiUrl;
            }
        }

        public static string NodeRunParams
        {
            get
            {
                var result = "OmniCoin.Node.dll";
                switch (CurrentNetworkType)
                {
                    case NetworkType.Mainnet:
                        result += "";
                        break;
                    case NetworkType.TestNet:
                        result += " -testnet";
                        break;
                    default:
                        break;
                }
                return result;
            }
        }

        public static string NodeTypeStr
        {
            get
            {
                var result = "";
                switch (CurrentNetworkType)
                {
                    case NetworkType.Mainnet:
                        result = "mainnet";
                        break;
                    case NetworkType.TestNet:
                        result = "testnet";
                        break;
                    default:
                        break;
                }
                return result;
            }
        }
    }
}
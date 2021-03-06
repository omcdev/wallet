﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniCoin.Utility
{
    public class WalletNetwork
    {
        private const string API_URI_MAIN = "http://localhost:58803";
        private const string API_URI_TEST = "http://localhost:58804/";

        public static string NetWork { get; set; }

        public static void SetNetWork(bool isTestNet)
        {
            NetWork = isTestNet ? API_URI_TEST : API_URI_MAIN;
        }
    }
}

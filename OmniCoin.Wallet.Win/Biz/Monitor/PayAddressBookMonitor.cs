// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Models;
using OmniCoin.Wallet.Win.Biz.Services;
using System.Collections.Generic;

namespace OmniCoin.Wallet.Win.Biz.Monitor
{
    public class PayAddressBookMonitor : ServiceMonitorBase<List<AddressBookInfo>>
    {
        private static PayAddressBookMonitor _default;

        public static PayAddressBookMonitor Default
        {
            get
            {
                if (_default == null)
                    _default = new PayAddressBookMonitor();
                return _default;
            }
        }

        protected override List<AddressBookInfo> ExecTaskAndGetResult()
        {
            var bookResults = AddressBookService.Default.GetAddressBook();

            if (bookResults.IsFail)
                return null;
            else
                return bookResults.Value;
        }
    }
}

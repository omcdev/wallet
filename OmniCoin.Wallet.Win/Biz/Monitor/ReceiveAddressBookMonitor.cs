// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Models;
using OmniCoin.Wallet.Win.Biz.Services;
using System.Collections.Generic;

namespace OmniCoin.Wallet.Win.Biz.Monitor
{
    public class ReceiveAddressBookMonitor : ServiceMonitorBase<List<AccountInfo>>
    {
        private static ReceiveAddressBookMonitor _default;

        public static ReceiveAddressBookMonitor Default
        {
            get
            {
                if (_default == null)
                    _default = new ReceiveAddressBookMonitor();
                return _default;
            }
        }

        protected override List<AccountInfo> ExecTaskAndGetResult()
        {
            var result = AccountsService.Default.GetPageAccountCategory(AccountsService.AccountCategory.ALL);
            if (result.IsFail)
                return null;
            else
                return result.Value;
        }
    }
}

// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OmniCoin.Wallet.Win.Common
{
    public interface IShell
    {
        Window GetWindow();
    }
}

﻿// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniCoin.Wallet.Win.Models
{
    public enum MessageTopic
    {
        UpdatePopupView,
        ClosePopupView,
        UpdateMainView,
        ChangedPopupViewState,
        ShowMessageAutoClose,
        ShowMessageNoClose,
        ClosePopUpWindow,
    }

    public enum SendMessageTopic
    {
        Refresh
    }

    public enum CommonTopic
    {
        UpdateWalletStatus,
        ExportBackUp,
    }


    public enum InputWalletPwdPageTopic
    {
        Normal,
        UnLockWallet,
        RequestPassword,
    }
}

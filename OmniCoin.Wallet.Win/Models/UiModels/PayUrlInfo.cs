﻿// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Models;
using OmniCoin.Wallet.Win.Common;

namespace OmniCoin.Wallet.Win.Models.UiModels
{
    public class UrlInfo : AddressBookInfo
    {
        private UrlMode _mode;

        public UrlMode Mode
        {
            get { return _mode; }
            set { _mode = value; OnChanged("Mode"); }
        }

        public UrlInfo()
        {

        }

        public UrlInfo(AddressBookInfo info)
        {
            this.Address = info.Address;
            this.Id = info.Id;
            this.Tag = info.Tag;
            this.Timestamp = info.Timestamp;
        }
    }

    public enum UrlMode
    {
        CreatePay,
        Edit,
        CreateByReceive,
        EditByReceive
    }
}
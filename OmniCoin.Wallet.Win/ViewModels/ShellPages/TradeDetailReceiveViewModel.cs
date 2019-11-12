﻿// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Wallet.Win.Common;
using OmniCoin.Wallet.Win.Models;

namespace OmniCoin.Wallet.Win.ViewModels.ShellPages
{
    public class TradeDetailReceiveViewModel : PopupShellBase
    {
        protected override string GetPageName()
        {
            return Pages.TradeDetailReceivePage;
        }

        protected override void OnLoaded()
        {
            base.OnLoaded();
            RegeistMessenger<TradeRecordInfo>(GetRequest);
        }

        void GetRequest(TradeRecordInfo tradeRecordInfo)
        {
            TradeRecordInfo = tradeRecordInfo;
        }


        private TradeRecordInfo _tradeRecordInfo;

        public TradeRecordInfo TradeRecordInfo
        {
            get { return _tradeRecordInfo; }
            set
            {
                _tradeRecordInfo = value;
                RaisePropertyChanged("TradeRecordInfo");
            }
        }
    }
}

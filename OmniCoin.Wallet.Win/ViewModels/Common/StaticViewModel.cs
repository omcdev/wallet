// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.

namespace OmniCoin.Wallet.Win.ViewModels
{
    public static class StaticViewModel
    {
        private static GlobalViewModel _globalViewModel = null;

        public static GlobalViewModel GlobalViewModel
        {
            get
            {
                if (_globalViewModel == null)
                {
                    _globalViewModel = new GlobalViewModel();
                }
                return _globalViewModel;
            }
        }
    }
}
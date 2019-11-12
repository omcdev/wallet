// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Wallet.Win.Common;
using System.Windows.Controls;

namespace OmniCoin.Wallet.Win.ValidationRules
{
    public abstract class RuleBase : ValidationRule
    {
        public string ErrorKey { get; set; }

        public string GetErrorMsg()
        {
            return LanguageService.Default.GetLanguageValue(ErrorKey);
        }
    }
}

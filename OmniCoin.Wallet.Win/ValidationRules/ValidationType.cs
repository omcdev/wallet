// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.

namespace OmniCoin.Wallet.Win.ValidationRules
{
    public enum ValidationType
    {
        Error_NotNull,
        Error_Password,
        Error_PasswordDifferent,
        Error_NewPasswordDifferent,
        Error_Address,
        Error_OutofRange,
        Error_Amount
    }
}

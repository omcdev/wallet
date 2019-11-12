// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Models;
using OmniCoin.Utility.Helper;
using OmniCoin.Wallet.Win.Common;
using System;
using System.Globalization;
using System.Windows.Data;

namespace OmniCoin.Wallet.Win.Converters
{
    public class ConfirmationToStatus : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            var payment = (Payment)value;
            if (payment == null)
                return null;

            //if (payment.BlockHash != null && Time.EpochTime - payment.Time >= 1000 * 60 * 10)
            //    return LanguageService.Default.GetLanguageValue("converter_confirming");

            if (payment.BlockHash != null)
                return LanguageService.Default.GetLanguageValue("converter_confirmed");

            return LanguageService.Default.GetLanguageValue("converter_unconfirmed");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

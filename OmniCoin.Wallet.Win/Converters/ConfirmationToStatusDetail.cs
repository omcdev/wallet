// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Models;
using OmniCoin.Utility.Helper;
using OmniCoin.Wallet.Win.Common;
using OmniCoin.Wallet.Win.Models;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace OmniCoin.Wallet.Win.Converters
{
    public class ConfirmationToStatusDetail : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            var payment = (Payment)value;
            if (payment == null)
                return null;

            //if (payment.BlockHash != null && Time.EpochTime - payment.Time >= 1000 * 60 * 10)
            //    return LanguageService.Default.GetLanguageValue("converter_confirmed");

            if (payment.BlockHash != null)
                return LanguageService.Default.GetLanguageValue("converter_confirmed");

            return LanguageService.Default.GetLanguageValue("converter_unconfirmed");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (value == null || !(value is string))
            //    return null;
            


            //var txt = value.ToString();
            //if (txt ==  LanguageService.Default.GetLanguageValue("converter_confirmed"))
            //    return 6;
            //if (txt == LanguageService.Default.GetLanguageValue("converter_unconfirmed"))
            //    return 0;
            //var format = LanguageService.Default.GetLanguageValue("converter_confirmFormat");
            //var pattern = format + "(?'value'[^/]+)/6";
            //Regex regex = new Regex(pattern);
            //var match = regex.Match(pattern);
            //var result = match.Groups["value"].Value;

            //int i = 0;
            //if (int.TryParse(result, out i))
            //{
            //    return i;
            //}
            return null;
        }
    }
}

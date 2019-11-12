// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Models;
using OmniCoin.Utility.Helper;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace OmniCoin.Wallet.Win.Converters
{
    public class ConfirmationToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            var payment = (Payment)value;
            if (payment == null)
                return null;

            //if (payment.BlockHash != null && Time.EpochTime - payment.Time >= 1000 * 60 * 10)
            //    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));

            if (payment.BlockHash != null)
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));

            return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3B8EFF"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

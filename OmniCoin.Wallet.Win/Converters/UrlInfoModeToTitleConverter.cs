﻿// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Wallet.Win.Common;
using OmniCoin.Wallet.Win.Models.UiModels;
using System;
using System.Globalization;
using System.Windows.Data;

namespace OmniCoin.Wallet.Win.Converters
{
    public class UrlInfoModeToTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is UrlMode))
                return null;
            var val = (UrlMode)value;
            var result = "";
            switch (val)
            {
                case UrlMode.CreatePay:
                    result = LanguageService.Default.GetLanguageValue("CreatePayUrl");
                    break;
                case UrlMode.Edit:
                    result = LanguageService.Default.GetLanguageValue("EditPayUrl");
                    break;
                case UrlMode.CreateByReceive:
                    result = LanguageService.Default.GetLanguageValue("CreateByReceive");
                    break;
                case UrlMode.EditByReceive:
                    result = LanguageService.Default.GetLanguageValue("EditByReceive");
                    break;
                default:
                    break;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

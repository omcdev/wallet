// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Wallet.Win.Common;
using OmniCoin.Wallet.Win.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OmniCoin.Wallet.Win.Converters
{
    public class InitStepToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is InitStep))
                return null;

            string result = "";
            var step = (InitStep)value;
            switch (step)
            {
                case InitStep.Initing:
                    result = LanguageService.Default.GetLanguageValue("WalletLoading");
                    break;
                case InitStep.ServiceStarting:
                    result = LanguageService.Default.GetLanguageValue("ServiceStarting");
                    break;
                case InitStep.NetConnectting:
                    result = LanguageService.Default.GetLanguageValue("NetConnectting");
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
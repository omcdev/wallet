﻿// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Models;
using OmniCoin.Wallet.Win.Common;
using OmniCoin.Wallet.Win.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace OmniCoin.Wallet.Win.Converters
{
    public class PaymentToMarkConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is Payment))
                return null;

            var payment = value as Payment;
            if (!string.IsNullOrEmpty(payment.Comment))
                return payment.Comment;

            string mark = null;
            var categoryType = Enum.Parse(typeof(PaymentCategoryType), payment.Category);
            if (payment.Account == payment.Address)
            {
                mark = LanguageService.Default.GetLanguageValue("converter_disabled");
            }
            else if (string.IsNullOrEmpty(payment.Comment))
            {
                switch (categoryType)
                {
                    case PaymentCategoryType.generate:
                    case PaymentCategoryType.receive:
                        mark = LanguageService.Default.GetLanguageValue("myself");
                        break;
                    case PaymentCategoryType.self:
                    case PaymentCategoryType.send:
                        if (string.IsNullOrEmpty(payment.Comment))
                            mark = payment.Account;
                        else
                            mark = payment.Comment;
                        break;
                }
            }
            return mark;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

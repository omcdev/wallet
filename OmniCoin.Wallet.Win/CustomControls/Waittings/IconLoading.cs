// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using System.Windows;
using System.Windows.Controls;

namespace OmniCoin.Wallet.Win.CustomControls.Waittings
{
    public partial class IconLoading : UserControl
    {
        static IconLoading()
        {
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(IconLoading), new FrameworkPropertyMetadata(typeof(IconLoading)));
        }
    }
}

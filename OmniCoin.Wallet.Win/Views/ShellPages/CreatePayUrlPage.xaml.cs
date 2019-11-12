// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Wallet.Win.Common;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace OmniCoin.Wallet.Win.Views.ShellPages
{
    /// <summary>
    /// CreatePayUrlPage.xaml 的交互逻辑
    /// </summary>
    [Export(typeof(IPage))]
    public partial class CreatePayUrlPage : Page , IPage
    {
        public CreatePayUrlPage()
        {
            InitializeComponent();
        }

        public Page GetCurrentPage()
        {
            return this;
        }

        public string GetPageName()
        {
            return Pages.CreatePayUrlPage;
        }
    }
}

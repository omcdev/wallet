// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Utility;
using OmniCoin.Wallet.Win.Biz;
using OmniCoin.Wallet.Win.Common;
using OmniCoin.Wallet.Win.Models;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;

namespace OmniCoin.Wallet.Win.ViewModels
{
    public class InitViewModel : VmBase
    {
        protected override void OnLoaded()
        {
            base.OnLoaded();
            OnPageLoadedCommand = new RelayCommand(OnPageLoaded);
        }

        public ICommand OnPageLoadedCommand { get; private set; }

        void OnPageLoaded()
        {
            InitWalletSataus();
        }

        void InitWalletSataus()
        {
            Initializer.Default.InitializedInvoke += OnInitialized;
            Initializer.Default.Start();
            Logger.Singleton.Debug("Initializer Start");
        }

        private InitMsgEvent _msg;

        public InitMsgEvent Msg
        {
            get {
                if (_msg == null)
                    _msg = new InitMsgEvent(false, LanguageService.Default.GetLanguageValue("WalletLoading"));
                return _msg; }
            set {
                _msg = value;
                RaisePropertyChanged("Msg"); }
        }

        void OnInitialized(InitMsgEvent msg)
        {
            StaticViewModel.GlobalViewModel.InitStep = InitStep.Sucesses;
            Application.Current.Dispatcher.Invoke(() =>
            {
                Msg.IsSucesses = msg.IsSucesses;
                Msg.Message = msg.Message;
                if(msg.IsSucesses)
                    UpdatePage(Pages.MainPage, PageModel.MainPage);
            });
        }
    }
}

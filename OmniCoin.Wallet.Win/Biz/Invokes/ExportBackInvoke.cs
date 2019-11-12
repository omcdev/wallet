﻿// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Wallet.Win.Biz.Services;
using OmniCoin.Wallet.Win.Common;
using OmniCoin.Wallet.Win.Common.interfaces;
using OmniCoin.Wallet.Win.Models;
using Microsoft.Win32;
using System.ComponentModel.Composition;

namespace OmniCoin.Wallet.Win.Biz.Invokes
{
    [Export(typeof(IInvoke))]
    public class ExportBackInvoke : VmBase , IInvoke
    {
        public string GetInvokeName()
        {
            return InvokeKeys.BackUp;
        }

        public void Invoke<T>(T obj)
        {
            var result = CheckAndInputPwd();
            if (result)
            {
                Export();
            }
        }


        private bool CheckAndInputPwd()
        {
            var settingResult = OmniCoinService.Default.GetTxSettings();
            if (settingResult.IsFail)
                return false;

            if (!settingResult.Value.Encrypt)
                return true;

            SendMsgData<InputWalletPwdPageTopic> data = new SendMsgData<InputWalletPwdPageTopic>();
            data.Token = InputWalletPwdPageTopic.UnLockWallet;
            data.SetCallBack(()=>
            {
                Export(true);
                OnClosePopup();
            });
            SendMessenger(Pages.InputWalletPwdPage, SendMessageTopic.Refresh);
            SendMessenger(Pages.InputWalletPwdPage, data);
            UpdatePage(Pages.InputWalletPwdPage);
            return false;
        }

        void Export(bool isEncrypt = false)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            var filter = isEncrypt ? "fcdatx（*.fcdatx）|*.fcdatx" : "fcdat（*.fcdat）|*.fcdat";
            saveFileDialog.Filter = filter;
            saveFileDialog.RestoreDirectory = true;
            var result = saveFileDialog.ShowDialog(BootStrapService.Default.Shell.GetWindow());
            if (result.HasValue && result.Value)
            {
                var file = saveFileDialog.FileName;
                var exportResult = WalletService.Default.ExportBackupWallet(file);
                if (!exportResult.IsFail)
                    ShowMessage(LanguageService.Default.GetLanguageValue(MessageKeys.Backup_Sucesses));
                else
                    ShowMessage(LanguageService.Default.GetLanguageValue(MessageKeys.Backup_Fail));
            }

            if (isEncrypt)
                WalletService.Default.LockWallet();
        }
    }

    

}

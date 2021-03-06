﻿// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.

namespace OmniCoin.Wallet.Win.Common.interfaces
{
    public interface IInvoke
    {
        string GetInvokeName();

        void Invoke<T>(T obj);
    }
}

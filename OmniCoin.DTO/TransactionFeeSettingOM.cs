// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.

namespace OmniCoin.DTO
{
    public class TransactionFeeSettingOM
    {
        public long Confirmations { get; set; }

        public long FeePerKB { get; set; }

        public bool Encrypt { get; set; }
    }
}

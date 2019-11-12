﻿// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.

namespace OmniCoin.DTO
{
    public class BannedInfoOM
    {
        public long Id { get; set; }

        public string Address { get; set; }

        public long Timestamp { get; set; }

        public string Expired { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniCoin.DTO
{
    public class ListPageUnspentOM
    {
        public List<PageUnspentOM> UnspentOMList { get; set; }

        public long Count { get; set; }
    }
}

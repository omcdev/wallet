using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniCoin.DTO
{
    public class SendRawTransactionInputsIM
    {
        public string TxId { get; set; }

        public long Vout { get; set; }
    }
}

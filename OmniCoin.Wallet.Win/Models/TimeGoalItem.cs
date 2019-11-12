// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Wallet.Win.Common;
using System.Xml.Serialization;

namespace OmniCoin.Wallet.Win.Models
{
    [XmlRoot]
    public class TimeGoalItem : VmBase
    {
        private string _value;

        [XmlIgnore]
        public string Value { get { return _value; } set { _value = value; RaisePropertyChanged("Value"); } }

        [XmlAttribute("Value")]
        public string ValueKey { get; set; }

        [XmlAttribute("Key")]
        public double Key { get; set; }
    }
}

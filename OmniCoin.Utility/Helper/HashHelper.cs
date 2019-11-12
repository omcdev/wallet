// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.

using System.Security.Cryptography;

namespace OmniCoin.Utility.Helper
{
    public class HashHelper
    {
        public static byte[] Hash(byte[] bytes)
        {
            SHA256 sha256 = SHA256Managed.Create();
            return sha256.ComputeHash(bytes);
        }

        public static byte[] DoubleHash(byte[] bytes)
        {
            return Hash(
                    Hash(bytes)
                );
        }

        /*
        public static byte[] Hash160(byte[] bytes)
        {
            SHA256 sha256 = SHA256.Create();
            RIPEMD160 ripemd160 = RIPEMD160.Create();

            return ripemd160.ComputeHash(
                    sha256.ComputeHash(bytes)
                );

        }
        */
        public static byte[] EmptyHash()
        {
            return new byte[32];
        }
    }
}

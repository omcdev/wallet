// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.

using OmniCoin.Utility.Localization.SourceFiles;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace OmniCoin.Utility.Localization
{
    public static class OmniCoinLocalizationConfigurer
    {
        
        public static string GetResource(string key)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentUICulture;
            ResourceManager resource = new ResourceManager(OmniCoinLocalization.ResourceManager.BaseName, Assembly.GetExecutingAssembly());
            return resource.GetString(key);
        }
    }
}

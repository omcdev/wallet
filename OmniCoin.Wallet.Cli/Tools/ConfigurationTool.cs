// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace OmniCoin.Wallet.Cli.Tools
{
    public class ConfigurationTool
    {
        public T GetAppSettings<T>(string key) where T : class, new()
        {
            IConfiguration config = new ConfigurationBuilder()
            .Add(new JsonConfigurationSource { Path = "qstpay.json", ReloadOnChange = true })
            .Build();

            T appconfig = new ServiceCollection()
                .AddOptions()
                .Configure<T>(config.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;

            return appconfig;
        }
    }
}

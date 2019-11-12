// Copyright (c) 2018 OmniCoin Technology Ltd
// Distributed under the MIT software license, see the accompanying
// file LICENSE or or http://www.opensource.org/licenses/mit-license.php.
using OmniCoin.Utility;
using OmniCoin.Wallet.Win.Biz.Services;
using OmniCoin.Wallet.Win.Models;

namespace OmniCoin.Wallet.Win.Biz.Monitor
{
    public class UpdateBlocksMonitor : ServiceMonitorBase<BlockSyncInfo>
    {
        private static UpdateBlocksMonitor _default;

        public static UpdateBlocksMonitor Default
        {
            get
            {
                if (_default == null)
                    _default = new UpdateBlocksMonitor();
                return _default;
            }
        }

        public BlockSyncInfo blockSyncInfo = new BlockSyncInfo();
        protected override BlockSyncInfo ExecTaskAndGetResult()
        {
            Logger.Singleton.Info("GetBlockChainInfoSync Start");
            var result = NetWorkService.Default.GetBlockChainInfoSync(blockSyncInfo);
            if (result.ApiResponse.HasError && result.ApiResponse.Error != null && result.ApiResponse.Error.Code != 0)
            {
                return null;
            }
            if (blockSyncInfo != null)
                Logger.Singleton.Info(blockSyncInfo.ToString());
            return result.Value;
        }

        public void Reset()
        {
            blockSyncInfo = new BlockSyncInfo();
        }
    }
}

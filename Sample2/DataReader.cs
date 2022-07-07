using System;
using System.Collections.Generic;
using System.Text;
using Common.Service;
using Common.Model;
using Newtonsoft.Json;

namespace Sample2
{
    public class DataReader
    {
        /// <summary>
        /// ログサービスのインスタンス
        /// </summary>
        private readonly ILogService logService;

        /// <summary>
        /// ログサービスのインスタンス
        /// </summary>
        private readonly IFileService fileService;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="logService">ログサービス</param>
        /// <param name="fileService">ファイルサービス</param>
        public DataReader(ILogService logService, IFileService fileService)
        {
            this.logService = logService;
            this.fileService = fileService;
        }

        /// <summary>
        /// データの読み込み
        /// </summary>
        /// <returns></returns>
        public DataModel ReadData()
        {
            try
            {
                string jsonStr = this.fileService.Read(@"..\..\..\..\data.json");
                if (!this.fileService.Delete(@"..\..\..\..\data.json"))
                {
                    this.logService.SystemLog($"Failed to delete json file.");
                    return null;
                }
                return JsonConvert.DeserializeObject<DataModel>(jsonStr);
            }
            catch (Exception e)
            {
                this.logService.UserLog($"Failed to json deserialize.");
                this.logService.SystemLog($"Failed to json deserialize.", e);
                return null;
            }
        }
    }
}

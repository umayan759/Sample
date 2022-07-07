using System;
using System.Collections.Generic;
using System.Text;
using Common.Service;
using Common.Model;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Sample1
{
    public class DataWriter
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
        /// データ
        /// </summary>
        public DataModel DataModel { get; set; } = new DataModel();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="logService">ログサービス</param>
        /// <param name="fileService">ファイルサービス</param>
        public DataWriter(ILogService logService, IFileService fileService)
        {
            this.logService = logService;
            this.fileService = fileService;
        }

        /// <summary>
        /// AddData
        /// </summary>
        /// <param name="content">content</param>
        [ExcludeFromCodeCoverage]
        public void AddData(string content)
        {
            DataModel.Data += content; 
        }

        /// <summary>
        /// AddData
        /// </summary>
        /// <param name="a">a</param>
        /// <param name="b">b</param>
        public void AddData(int a, int b)
        {
            DataModel.Data += (a + b).ToString();
        }

       /// <summary>
       /// データの書き込み
       /// </summary>
       /// <returns></returns>
        public bool WriteData()
        {
            string jsonStr = JsonConvert.SerializeObject(this.DataModel);

            if (!this.fileService.Write(@"..\..\..\..\data.json", jsonStr))
            {
                this.logService.UserLog($"Faild to write json file.");
                this.logService.SystemLog($"Faild to write json file.");
                return false;
            }

            return true;
        }
    }
}

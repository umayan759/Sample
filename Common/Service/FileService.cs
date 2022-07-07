using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Common.Service
{
    /// <summary>
    /// ファイルサービス
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// ログサービスのインスタンス
        /// </summary>
        private readonly ILogService logService;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="logService">ログサービス</param>
        public FileService(ILogService logService)
        {
            this.logService = logService;
        }

        /// <summary>
        /// ファイル書き込み
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool Write(string filePath, string text)
        {
            try
            {
                File.WriteAllText(filePath, text);
            }
            catch (Exception e)
            {
                this.logService.SystemLog($"Faild to write file.[{filePath}]", e);
                return false;
            }

            return true;
        }

        /// <summary>
        /// ファイル読み込み
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string Read(string filePath)
        {
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (Exception e)
            {
                this.logService.SystemLog($"Faild to read file.[{filePath}]", e);
                return default;
            }
        }

        /// <summary>
        /// ファイル削除
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool Delete(string filePath)
        {
            try
            {
                File.Delete(filePath);
            }
            catch (Exception e)
            {
                this.logService.SystemLog($"Faild to delete file.[{filePath}]", e);
                return false;
            }

            return true;
        }
    }
}

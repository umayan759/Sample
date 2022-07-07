using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service
{
    /// <summary>
    /// ファイルサービスインターフェース
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// ファイル書き込み
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        bool Write(string filePath, string text);

        /// <summary>
        /// ファイル読み込み
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        string Read(string filePath);

        /// <summary>
        /// ファイル削除
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        bool Delete(string filePath);
    }
}

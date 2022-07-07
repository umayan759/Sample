using System;
using Microsoft.Extensions.Logging;

namespace Common.Service
{
    /// <summary>
    /// ログサービスインターフェース
    /// </summary>
    public interface ILogService
    {
        /// <summary>
        /// ユーザーログ
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="logLevel">ログレベル</param>
        void UserLog(string message, LogLevel logLevel = LogLevel.Error);

        /// <summary>
        /// システムログ
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="e">エクセプション</param>
        /// <param name="logLevel">ログレベル</param>
        void SystemLog(string message, Exception e = null, LogLevel logLevel = LogLevel.Error);
    }
}

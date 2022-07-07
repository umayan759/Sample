using System;
using NLog;
using System.Diagnostics.CodeAnalysis;

namespace Common.Service
{
    /// <summary>
    /// ログサービス
    /// </summary>
    public class LogService : ILogService
    {
        /// <summary>
        /// ユーザーロガーインスタンス
        /// </summary>
        private Logger userLogger = LogManager.GetLogger("User");

        /// <summary>
        /// システムロガーインスタンス
        /// </summary>
        private Logger systemLogger = LogManager.GetLogger("System");

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        [ExcludeFromCodeCoverage]
        public LogService(string fileName)
        {
            LogManager.Configuration.Variables["FileName"] = fileName;
        }

        /// <summary>
        /// ユーザーログ
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="logLevel">ログレベル</param>
        [ExcludeFromCodeCoverage]
        public void UserLog(string message, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Error)
        {
            this.Logging(this.userLogger, message, logLevel);
        }

        /// <summary>
        /// システムログ
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="e">エクセプション</param>
        /// <param name="logLevel">ログレベル</param>
        [ExcludeFromCodeCoverage]
        public void SystemLog(string message, Exception e = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Error)
        {

            this.Logging(this.userLogger, $"{message}[{e?.ToString().Replace("\r\n", "/")}]", logLevel);
        }

        /// <summary>
        /// ロギング
        /// </summary>
        /// <param name="logger">ロガーインスタンス</param>
        /// <param name="message">メッセージ</param>
        /// <param name="logLevel">ログレベル</param>
        [ExcludeFromCodeCoverage]
        private void Logging(Logger logger, string message, Microsoft.Extensions.Logging.LogLevel logLevel)
        {
            switch (logLevel)
            {
                case Microsoft.Extensions.Logging.LogLevel.Trace:
                    logger.Trace(message);
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Debug:
                    logger.Debug(message);
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Information:
                    logger.Info(message);
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Warning:
                    logger.Warn(message);
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Error:
                    logger.Error(message);
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Critical:
                    logger.Fatal(message);
                    break;
                default:
                    logger.Error(message);
                    break;
            }
        }
    }
}
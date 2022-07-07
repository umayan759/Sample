using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Service
{
    /// <summary>
    /// コンソールサービスインターフェース
    /// </summary>
    public interface IConsoleService
    {
        /// <summary>
        /// コンソールへのライン書き込み
        /// </summary>
        /// <param name="text"></param>
        void WriteLine(string text);

        /// <summary>
        /// コンソールからのキー読み込み
        /// </summary>
        /// <returns></returns>
        string ReadKey();
    }
}

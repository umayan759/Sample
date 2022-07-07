using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Common.Service
{
    /// <summary>
    /// コンソールサービス
    /// </summary>
    public class ConsoleService : IConsoleService
    {
        /// <summary>
        /// コンソールへのライン書き込み
        /// </summary>
        /// <param name="text"></param>
        [ExcludeFromCodeCoverage]
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// コンソールからのキー読み込み
        /// </summary>
        /// <returns></returns>
        [ExcludeFromCodeCoverage]
        public string ReadKey()
        {
            return Console.ReadKey().KeyChar.ToString();
        }
    }
}

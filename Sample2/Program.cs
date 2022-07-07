using System;
using Common.Service;
using Common.Model;
using System.Diagnostics.CodeAnalysis;

namespace Sample2
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            LogService logService = new LogService("Sample2");
            FileService fileService = new FileService(logService);
            ConsoleService consoleService = new ConsoleService();

            DataReader dataReader = new DataReader(logService, fileService);

            consoleService.WriteLine(dataReader.ReadData()?.Data);
            logService.SystemLog("dataReader.ReadData", null, Microsoft.Extensions.Logging.LogLevel.Information);
            
            consoleService.WriteLine("処理終了、何かキーを押してください。");
            consoleService.ReadKey();
        }
    }
}

using System;
using Common.Service;
using Common.Model;
using System.Diagnostics.CodeAnalysis;

namespace Sample1
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            LogService logService = new LogService("Sample1");
            FileService fileService = new FileService(logService);
            ConsoleService consoleService = new ConsoleService();

            DataWriter dataWriter = new DataWriter(logService, fileService);

            dataWriter.AddData("From Sample1");
            logService.SystemLog("dataWriter.AddData", null, Microsoft.Extensions.Logging.LogLevel.Information);
            dataWriter.WriteData();
            logService.SystemLog("dataWriter.WriteData", null, Microsoft.Extensions.Logging.LogLevel.Information);

            consoleService.WriteLine("処理終了、何かキーを押してください。");
            consoleService.ReadKey();
        }
    }
}

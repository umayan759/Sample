using System;
using System.IO;
using Xunit;
using Common.Service;
using Common.Model;
using Moq;

namespace Common.Test
{
    /// <summary>
    /// ファイルサービスのテスト
    /// </summary>
    public class FileServiceTest : IDisposable
    {
        /// <summary>
        /// テスト用フォルダ
        /// </summary>
        private readonly string TestFolder = @".\Test";

        /// <summary>
        /// テスト準備
        /// </summary>
        public FileServiceTest()
        {
            if (!Directory.Exists(TestFolder))
            {
                Directory.CreateDirectory(TestFolder);
            }
        }

        /// <summary>
        /// テスト後の掃除
        /// </summary>
        public void Dispose()
        {
            Directory.Delete(TestFolder, true);
        }

        /// <summary>
        /// ファイル書き込みが成功したとき、Trueが返る
        /// </summary>
        [Fact]
        public void Write_WriteSuccess_ReturnTrue()
        {
            // Arrange
            string filePath = Path.Combine(TestFolder, "test.txt");
            Mock<ILogService> mockLogService = new Mock<ILogService>();
            FileService fileService = new FileService(mockLogService.Object);

            // Action
            bool succeed = fileService.Write(filePath,"text");

            // Assert
            Assert.True(succeed);

            string text = File.ReadAllText(filePath);
            Assert.Equal("text", text);
        }

        /// <summary>
        /// ファイル書き込みが失敗したとき、Falseが返る
        /// </summary>
        [Fact]
        public void Write_WriteFailed_ReturnFalse()
        {
            // Arrange
            string filePath = Path.Combine(@"C:\dummy", "test.txt");
            Mock<ILogService> mockLogService = new Mock<ILogService>();
            FileService fileService = new FileService(mockLogService.Object);

            // Action
            bool succeed = fileService.Write(filePath,"text");

            // Assert
            Assert.False(succeed);
        }

        /// <summary>
        /// ファイル読み込みが成功したとき、Trueが返る
        /// </summary>
        [Fact]
        public void Write_ReadSuccess_ReturnTrue()
        {
            // Arrange
            string filePath = Path.Combine(TestFolder, "test.txt");
            Mock<ILogService> mockLogService = new Mock<ILogService>();
            FileService fileService = new FileService(mockLogService.Object);
            File.WriteAllText(filePath, "text");

            // Action
            string text = fileService.Read(filePath);

            // Assert
            Assert.Equal("text", text);

        }

        /// <summary>
        /// ファイル読み込みが失敗したとき、Falseが返る
        /// </summary>
        [Fact]
        public void Write_ReadFailed_ReturnFalse()
        {
            // Arrange
            string filePath = Path.Combine(@"C:\dummy", "test.txt");
            Mock<ILogService> mockLogService = new Mock<ILogService>();
            FileService fileService = new FileService(mockLogService.Object);

            // Action
            string text = fileService.Read(filePath);

            // Assert
            Assert.Null(text);
        }

        /// <summary>
        /// ファイル削除が成功したとき、Trueが返る
        /// </summary>
        [Fact]
        public void Write_DeleteSuccess_ReturnTrue()
        {
            // Arrange
            string filePath = Path.Combine(TestFolder, "test.txt");
            Mock<ILogService> mockLogService = new Mock<ILogService>();
            FileService fileService = new FileService(mockLogService.Object);
            File.WriteAllText(filePath, "text");

            // Action
            bool succeed = fileService.Delete(filePath);

            // Assert
            Assert.True(succeed);

        }

        /// <summary>
        /// ファイル削除が失敗したとき、Falseが返る
        /// </summary>
        [Fact]
        public void Write_DeleteFailed_ReturnFalse()
        {
            // Arrange
            string filePath = Path.Combine(@"C:\dummy", "test.txt");
            Mock<ILogService> mockLogService = new Mock<ILogService>();
            FileService fileService = new FileService(mockLogService.Object);

            // Action
            bool succeed = fileService.Delete(filePath);

            // Assert
            Assert.False(succeed);
        }
    }
}

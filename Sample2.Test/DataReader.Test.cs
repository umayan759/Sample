using System;
using System.IO;
using Xunit;
using Common.Service;
using Common.Model;
using Sample2;
using Moq;

namespace Sample2.Test
{
    /// <summary>
    ///  DataReaderのテスト
    /// </summary>
    public class DataReaderTest
    {
        /// <summary>
        /// ReadDataが成功したとき、Trueが返る
        /// </summary>
        [Fact]
        public void ReadData_ReadSuccess_ReturnTrue()
        {
            // Arrange
            Mock<ILogService> mockLogService = new Mock<ILogService>();
            Mock<IFileService> mockFileService = new Mock<IFileService>();
            mockFileService.Setup(x => x.Read(It.IsAny<string>())).Returns("{\"dat\":\"From Sample1\"}");
            mockFileService.Setup(x => x.Delete(It.IsAny<string>())).Returns(true);
            Sample2.DataReader DataReader = new DataReader(mockLogService.Object, mockFileService.Object);

            // Action
            DataModel dataModel = DataReader.ReadData();

            // Assert
            Assert.NotNull(dataModel);
        }

        /// <summary>
        /// ReadDataでデシリアライズに失敗したとき、Falseが返る
        /// </summary>
        [Fact]
        public void ReadData_DeserializeFailed_ReturnFalse()
        {
            // Arrange
            Mock<ILogService> mockLogService = new Mock<ILogService>();
            Mock<IFileService> mockFileService = new Mock<IFileService>();
            mockFileService.Setup(x => x.Read(It.IsAny<string>())).Returns(null as string);
            mockFileService.Setup(x => x.Delete(It.IsAny<string>())).Returns(true);
            Sample2.DataReader DataReader = new DataReader(mockLogService.Object, mockFileService.Object);

            // Action
            DataModel dataModel = DataReader.ReadData();

            // Assert
            Assert.Null(dataModel);
            mockLogService.Verify(x => x.UserLog(It.IsAny<string>(), It.IsAny<Microsoft.Extensions.Logging.LogLevel>()), Times.Once);
            mockLogService.Verify(x => x.SystemLog(It.IsAny<string>(), It.IsAny<Exception>(), It.IsAny<Microsoft.Extensions.Logging.LogLevel>()), Times.Once);
        }


        /// <summary>
        /// ReadDataでファイル削除に失敗したとき、Falseが返る
        /// </summary>
        [Fact]
        public void ReadData_DeleteFailed_ReturnFalse()
        {
            // Arrange
            Mock<ILogService> mockLogService = new Mock<ILogService>();
            Mock<IFileService> mockFileService = new Mock<IFileService>();
            mockFileService.Setup(x => x.Read(It.IsAny<string>())).Returns("dummy");
            mockFileService.Setup(x => x.Delete(It.IsAny<string>())).Returns(false);
            Sample2.DataReader DataReader = new DataReader(mockLogService.Object, mockFileService.Object);

            // Action
            DataModel dataModel = DataReader.ReadData();

            // Assert
            Assert.Null(dataModel);
            mockLogService.Verify(x => x.UserLog(It.IsAny<string>(), It.IsAny<Microsoft.Extensions.Logging.LogLevel>()), Times.Never);
            mockLogService.Verify(x => x.SystemLog(It.IsAny<string>(), It.IsAny<Exception>(), It.IsAny<Microsoft.Extensions.Logging.LogLevel>()), Times.Once);

        }
    }
}

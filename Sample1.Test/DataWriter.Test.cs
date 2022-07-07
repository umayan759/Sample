using System;
using System.IO;
using Xunit;
using Common.Service;
using Common.Model;
using Sample1;
using Moq;

namespace Sample1.Test
{
    /// <summary>
    /// DataWriterのテスト
    /// </summary>
    public class DataWriterTest
    {
        /// <summary>
        /// WriteDataが成功したとき、Trueが返る
        /// </summary>
        [Fact]
        public void WriteData_WriteSuccess_ReturnTrue()
        {
            // Arrange
            Mock<ILogService> mockLogService = new Mock<ILogService>();
            Mock<IFileService> mockFileService = new Mock<IFileService>();
            mockFileService.Setup(x => x.Write(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            Sample1.DataWriter dataWriter = new DataWriter(mockLogService.Object, mockFileService.Object);

            // Action
            bool succeed = dataWriter.WriteData();

            // Assert
            Assert.True(succeed);
        }

        /// <summary>
        /// WriteDataが失敗したとき、Falseが返る
        /// </summary>
        [Fact]
        public void WriteData_WriteFailed_ReturnFalse()
        {
            // Arrange
            Mock<ILogService> mockLogService = new Mock<ILogService>();
            Mock<IFileService> mockFileService = new Mock<IFileService>();
            mockFileService.Setup(x => x.Write(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            Sample1.DataWriter dataWriter = new DataWriter(mockLogService.Object, mockFileService.Object);

            // Action
            bool succeed = dataWriter.WriteData();

            // Assert
            Assert.False(succeed);
        }

        /// <summary>
        /// AddDataのテスト
        /// </summary>
        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 4)]
        public void AddData_Test(int a, int b)
        {
            // Arrange
            Mock<ILogService> mockLogService = new Mock<ILogService>();
            Mock<IFileService> mockFileService = new Mock<IFileService>();
            Sample1.DataWriter dataWriter = new DataWriter(mockLogService.Object, mockFileService.Object);

            // Action
            dataWriter.AddData(a, b);

            // Assert
            Assert.Equal((a + b).ToString(), dataWriter.DataModel.Data);
        }
    }
}

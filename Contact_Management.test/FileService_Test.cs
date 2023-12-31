using Contact_Management.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Management.test
{
    public class FileService_Test
    {
        [Fact]
        public void SaveToFileShould_SaveContentToFile_TheReturnTrue()
        {
            // Arrange
            IFileService fileService = new FileService();
            string filePath = @"c:\EC_utbildning_csharp\Contact_Management\test.txt";
            string content = "Ella princess";


            // Act
            bool result = fileService.SaveToFile(filePath, content);


            // Assert
            Assert.True(result);
        }


        [Fact]
        public void SaveToFileShould_ReturnFalse_IfFilePathDoNotExist()
        {
            // Arrange
            IFileService fileService = new FileService();
            string filePath = @$"c:\{Guid.NewGuid()}\test.txt";
            string content = "Ella princess";


            // Act
            bool result = fileService.SaveToFile(filePath, content);


            // Assert
            Assert.False(result);
        }
    }
}

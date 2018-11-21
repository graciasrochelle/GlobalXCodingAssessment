using System;
using System.IO;
using NameSorter.Controllers;
using NameSorter.Interfaces;
using Xunit;

namespace NameSorterTester
{
    public class ValidateIfFileExistsUnitTest
    {
        [Fact]
        public void Test()
        {
            string arg1 = Path.GetFileName("./unit-test-unsorted-names-list.txt");

            IFileSystem fileSystem = new FileSystemController();

            var parent = Directory
                              .GetParent(Environment.CurrentDirectory)
                              .Parent.Parent.Parent.FullName;
            var pjFolder = "/NameSorterTester";

            string inputFilePath = parent + pjFolder + Utils.Constants.FilePath + arg1;

            Boolean isFileExits = fileSystem.ValidateIfFileExists(inputFilePath);

            NLog.LogManager.GetCurrentClassLogger().Debug("\nFile Exists?: " + isFileExits);
            Assert.True(isFileExits);
        }
    }
}

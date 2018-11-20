using System;
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
            var parent = System.IO.Directory
                               .GetParent(Environment.CurrentDirectory)
                               .Parent.Parent.Parent.FullName;
            var pjFolder = "/NameSorter";
            var pjFullPath = parent + pjFolder;

            string inputFileName = System.IO.Path.GetFileName("./unsorted-names-list.txt");
            string filePath = pjFullPath + "/" + inputFileName;

            IFileSystem fileSystem = new FileSystemController();

            Boolean isFileExits = fileSystem.ValidateIfFileExists(filePath);
            NLog.LogManager.GetCurrentClassLogger().Debug("\nFile Path: " + filePath);
            NLog.LogManager.GetCurrentClassLogger().Debug("\nFile Exists?: " + isFileExits);
            Assert.True(isFileExits);
        }
    }
}

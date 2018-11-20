using System;
using System.Collections.Generic;
using NameSorter;
using NameSorter.Controllers;
using NameSorter.Interfaces;
using NameSorter.Repositories;
using Xunit;

namespace NameSorterTester
{
    public class WriteSortedListOfNamesUnitTest
    {
        [Fact]
        public void Test()
        {
            string outputFileName = "sorted-names-list.txt";

            var parent = System.IO.Directory
                               .GetParent(Environment.CurrentDirectory)
                               .Parent.Parent.Parent.FullName;
            var pjFolder = "/NameSorter";
            var pjFullPath = parent + pjFolder;

            string filePath = pjFullPath + "/" + outputFileName;

            if(System.IO.File.Exists(filePath)){
                System.IO.File.Delete(filePath);
            }

            List<Person> people = new List<Person>
            {
                new Person(new string[]{ "Marin"}, "Alvarez"),
                new Person(new string[]{ "Adonis", "Julius"}, "Archer"),
                new Person(new string[]{ "Richard", "Andrew", "Larry"}, "Burgess"),
                new Person(new string[]{ "Richard", "Benny", "Larry"}, "Burgess"),
                new Person(new string[]{ "Richard", "Larry"}, "Burgess"),
                new Person(new string[]{ "Richard", "Martin"}, "Burgess"),
                new Person(new string[]{ "Vaughn"}, "Lewis"),
                new Person(new string[]{ "Janet"}, "Parsons"),
                new Person(new string[]{ "Shelby", "Nathan"}, "Yoder")
            };

            Boolean isFileWritten = new FileSystemController().WriteToFile(filePath, people);

            NLog.LogManager.GetCurrentClassLogger().Debug("\nFile Path: " + filePath);

            Assert.True(isFileWritten);
        }
    }
}

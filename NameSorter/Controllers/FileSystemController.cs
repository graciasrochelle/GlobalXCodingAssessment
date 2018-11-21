using System;
using System.Collections.Generic;
using NameSorter.Repositories;

namespace NameSorter.Controllers
{
    public class FileSystemController : Interfaces.IFileSystem
    {
        public FileSystemController()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("FileSystemController() called...");
        }

        public Boolean ValidateIfFileExists(string filePath)
        {
            return (new ValidateIfFileExists().IsFileExists(filePath));
        }

        public List<Person> GetListOfNames(string filePath)
        {
            return (new GetUnsortedListOfNames().ReadFromFile(filePath));
        }

        public Boolean WriteToFile(string fileName, List<Person> listOfNames)
        {
            return (new WriteSortedListOfNames().WriteToFile(fileName, listOfNames));
        }
    }
}

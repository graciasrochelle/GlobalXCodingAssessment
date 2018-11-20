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

        public Boolean ValidateIfFileExists(string filename)
        {
            return (new ValidateIfFileExists().IsFileExists(filename));
        }

        public List<Person> GetListOfNames(string fileName)
        {
            return (new GetUnsortedListOfNames().ReadFromFile(fileName));
        }

        public Boolean WriteToFile(string fileName, List<Person> listOfNames)
        {
            return (new WriteSortedListOfNames().WriteToFile(fileName, listOfNames));
        }
    }
}

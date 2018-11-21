using System;
using System.Collections.Generic;

namespace NameSorter.Interfaces
{
    public interface IFileSystem
    {
        Boolean ValidateIfFileExists(string filePath);
        List<Person> GetListOfNames(string filePath);
        Boolean WriteToFile(string filepath, List<Person> listOfNames);
    }
}

using System;
using System.Collections.Generic;

namespace NameSorter.Interfaces
{
    public interface IFileSystem
    {
        Boolean ValidateIfFileExists(string filename);
        List<Person> GetListOfNames(string fileName);
        Boolean WriteToFile(string fileName, List<Person> listOfNames);
    }
}

using System;
using System.Collections.Generic;

namespace NameSorter.Interfaces
{
    public interface INameSorter
    {
        List<Person> GetListOfNames(List<Person> listOfNames);
        List<Person> GetListOfNames(string fileName);
        Boolean WriteListOfNames(string fileName, List<Person> listOfNames);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace NameSorter.Interfaces
{
    public interface INameSorter
    {
        List<Person> GetUnsortedNameList(string fileName);
        Boolean WriteSortedListOfNames(string fileName, List<Person> sortedListOfNames);
        List<Person> GetSortedListOfNames(List<Person> unsortedListOfNames);
    }
}

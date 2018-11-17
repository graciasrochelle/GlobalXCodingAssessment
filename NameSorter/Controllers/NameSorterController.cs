using System;
using System.Collections;
using System.Collections.Generic;
using NameSorter.Interfaces;
using NameSorter.Repositories;

namespace NameSorter.Controllers
{
    public class NameSorterController : INameSorter
    {
        public NameSorterController()
        {
        }

        public List<Person> GetSortedListOfNames(List<Person> unsortedListOfNames)
        {
            return (new GetSortedListOfNames().SortNames(unsortedListOfNames));
        }

        public List<Person> GetUnsortedNameList(string fileName)
        {
            return (new GetUnsortedListOfNames().ReadFromFile(fileName));
        }

        public Boolean WriteSortedListOfNames(string fileName, List<Person> sortedListOfNames)
        {
            return (new WriteSortedListOfNames().WriteToFile(fileName, sortedListOfNames));
        }
    }
}

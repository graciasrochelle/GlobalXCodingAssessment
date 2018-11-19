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

        public List<Person> GetListOfNames(List<Person> listOfNames)
        {
            return (new GetSortedListOfNames().SortNames(listOfNames));
        }

        public List<Person> GetListOfNames(string fileName)
        {
            return (new GetUnsortedListOfNames().ReadFromFile(fileName));
        }

        public Boolean WriteListOfNames(string fileName, List<Person> listOfNames)
        {
            return (new WriteSortedListOfNames().WriteToFile(fileName, listOfNames));
        }
    }
}

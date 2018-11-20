using System;
using System.Collections.Generic;
using NameSorter.Interfaces;
using NameSorter.Repositories;

namespace NameSorter.Controllers
{
    public class NameSorterController : INameSorter
    {
        public NameSorterController()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("NameSorterController() called...");
        }

        public List<Person> GetListOfNames(List<Person> listOfNames)
        {
            return (new GetSortedListOfNames().SortNames(listOfNames));
        }

        public Boolean WriteToScreen(List<Person> unsortedListOfPeople, List<Person> sortedListOfPeople)
        {
            return (new WriteToScreen().WriteToConsole(unsortedListOfPeople, sortedListOfPeople));
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using NameSorter.Controllers;
using NameSorter.Interfaces;

namespace NameSorter
{
    public class NameSorterService
    {
        string inputFileName = "unsorted-names-list.txt";
        string outputFileName = "sorted-names-list.txt";
        List<Person> _unsortedListOfNames;
        List<Person> _sortedListOfNames;
        INameSorter _nameSorter;

        public NameSorterService(){
            _nameSorter = new NameSorterController();
        }

        public void StartNameSorter()
        {
            _unsortedListOfNames = _nameSorter.GetUnsortedNameList(inputFileName);
            Console.WriteLine("~~!Unsorted List of Names!~~");
            foreach (Person person in _unsortedListOfNames)
            {
                Console.WriteLine(person);
            }
            _sortedListOfNames = _nameSorter.GetSortedListOfNames(_unsortedListOfNames);
            Console.WriteLine("------------------------------");
            Console.WriteLine("~~!Sorted List of Names!~~");
            foreach (Person person in _sortedListOfNames)
            {
                Console.WriteLine(person);
            }
            _nameSorter.WriteSortedListOfNames(outputFileName, _sortedListOfNames);
        }
    }
}

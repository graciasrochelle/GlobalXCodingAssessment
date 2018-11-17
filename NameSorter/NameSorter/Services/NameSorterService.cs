using System;
using System.Collections.Generic;
using System.IO;
using NameSorter.Controllers;
using NameSorter.Interfaces;

namespace NameSorter
{
    public class NameSorterService
    {
        readonly string _filename = "sorted-names-list.txt";

        private readonly string _inputFilePath;
        private readonly string _outputFilePath;
        private List<Person> _unsortedListOfNames;
        private List<Person> _sortedListOfNames;
        private readonly INameSorter _nameSorter;

        public NameSorterService(string inputFileName){
            _nameSorter = new NameSorterController();
            _inputFilePath = Path.GetFullPath(inputFileName);
            _outputFilePath = Path.GetFullPath(_filename);
        }

        public void StartNameSorter()
        {
            try{
                _unsortedListOfNames = _nameSorter.GetUnsortedNameList(_inputFilePath);

                if(_unsortedListOfNames != null){
                    Console.WriteLine("~~!Unsorted List of Names!~~");
                    foreach (Person person in _unsortedListOfNames)
                    {
                        Console.WriteLine(person);
                        NLog.LogManager.GetCurrentClassLogger().Info(person);
                    }
                    _sortedListOfNames = _nameSorter.GetSortedListOfNames(_unsortedListOfNames);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("~~!Sorted List of Names!~~");
                    foreach (Person person in _sortedListOfNames)
                    {
                        Console.WriteLine(person);
                    }
                    _nameSorter.WriteSortedListOfNames(_outputFilePath, _sortedListOfNames);
                }
                else{
                    throw new Exception();
                }
            }catch(Exception ex){
                NLog.LogManager.GetCurrentClassLogger().Fatal(ex);
                Console.WriteLine("Error Occured! Check logs for more details.\nExiting program...");
            }
        }
    }
}

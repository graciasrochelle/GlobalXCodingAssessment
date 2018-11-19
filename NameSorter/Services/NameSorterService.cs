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

        readonly string _inputFilePath;
        readonly string _outputFilePath;

        readonly INameSorter _nameSorter;

        public NameSorterService(string inputFileName){
            _nameSorter = new NameSorterController();
            _inputFilePath = Path.GetFullPath(inputFileName);
            _outputFilePath = Path.GetFullPath(_filename);
        }

        public void StartNameSorter()
        {
            try{
                List<Person> unsortedListOfNames = _nameSorter.GetListOfNames(_inputFilePath);

                if(unsortedListOfNames != null){
                    Console.WriteLine("~~!Unsorted List of Names!~~");
                    foreach (Person person in unsortedListOfNames)
                    {
                        Console.WriteLine(person);
                        NLog.LogManager.GetCurrentClassLogger().Debug(person);
                    }
                    List<Person> sortedListOfNames = _nameSorter.GetListOfNames(unsortedListOfNames);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("~~!Sorted List of Names!~~");
                    foreach (Person person in sortedListOfNames)
                    {
                        Console.WriteLine(person);
                    }
                    _nameSorter.WriteListOfNames(_outputFilePath, sortedListOfNames);
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

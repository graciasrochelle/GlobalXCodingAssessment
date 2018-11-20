using System;
using System.Collections.Generic;
using NameSorter.Controllers;
using NameSorter.Interfaces;
using NameSorter.Services;
using NameSorter.Utils;

namespace NameSorter
{
    public class NameSorterService
    {
        readonly INameSorter _nameSorter;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:NameSorter.NameSorterService"/> class.
        /// </summary>
        /// <param name="inputFileName">File to be sorted.</param>
        public NameSorterService(){
            _nameSorter = new NameSorterController();
        }

        public void StartNameSorter(string filename)
        {
            try{
                FileSystemService fileSystem = new FileSystemService();

                List<Person> unsortedListOfNames = fileSystem.ReadFromFile(filename);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                _nameSorter.WriteToScreen(Constants.MessageBeforeSorting, unsortedListOfNames);
                Console.ResetColor();

                if (unsortedListOfNames != null){

                    List<Person> sortedListOfNames = _nameSorter.GetListOfNames(unsortedListOfNames);

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Boolean isDisplayedOnScreen = _nameSorter.WriteToScreen(Constants.MessageAfterSorting, sortedListOfNames);
                    Console.ResetColor();

                    Boolean isWrittenToFile = fileSystem.WriteToFile(sortedListOfNames);

                    if (!isDisplayedOnScreen || !isWrittenToFile)
                    {
                        throw new Exception();
                    }
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

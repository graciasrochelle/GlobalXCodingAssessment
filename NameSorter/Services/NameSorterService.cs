using System;
using System.Collections.Generic;
using System.IO;
using NameSorter.Controllers;
using NameSorter.Interfaces;
using NameSorter.Services;

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

                List<Person> unsortedListOfNames = (new FileSystemService().ReadFromFile(filename));
                if (unsortedListOfNames != null){
                    List<Person> sortedListOfNames = _nameSorter.GetListOfNames(unsortedListOfNames);
                    Boolean isDisplayedOnScreen = _nameSorter.WriteToScreen(unsortedListOfNames, sortedListOfNames);
                    Boolean isWrittenToFile = (new FileSystemService().WriteToFile(sortedListOfNames));
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

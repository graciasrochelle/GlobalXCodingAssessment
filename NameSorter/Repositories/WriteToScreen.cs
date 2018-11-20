using System;
using System.Collections.Generic;

namespace NameSorter.Repositories
{
    public class WriteToScreen
    {
        public WriteToScreen()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("WriteToScreen() called...");
        }

        /// <summary>
        /// Writes to console.
        /// </summary>
        /// <returns><c>true</c>, if to console was writed, <c>false</c> otherwise.</returns>
        /// <param name="unsortedListOfNames">Unsorted list of names.</param>
        /// <param name="sortedListOfNames">Sorted list of names.</param>
        public Boolean WriteToConsole(List<Person> unsortedListOfNames, List<Person> sortedListOfNames)
        {
            try
            {
                Console.WriteLine("~~!Unsorted List of Names!~~");
                foreach (Person person in unsortedListOfNames)
                {
                    Console.WriteLine(person);
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n--------After Sorting-----\n");
                Console.WriteLine("~~!Sorted List of Names!~~");
                foreach (Person person in sortedListOfNames)
                {
                    Console.WriteLine(person);
                }
                Console.ResetColor();
                NLog.LogManager.GetCurrentClassLogger().Info("Write to console was successful!");
                return true;
            }
            catch(Exception ex){
                NLog.LogManager.GetCurrentClassLogger().Fatal(ex);
                Console.WriteLine("Error Occured! Check logs for more details.\nExiting program...");
                return false;
            }
        }
    }
}

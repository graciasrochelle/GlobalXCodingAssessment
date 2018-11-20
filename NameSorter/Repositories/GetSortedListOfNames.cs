using System;
using System.Collections.Generic;

namespace NameSorter.Repositories
{
    public class GetSortedListOfNames
    {
        public GetSortedListOfNames()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("GetSortedListOfNames() called...");
        }

        /// <summary>
        /// Takes the list of unsorted names of people and returns a sorted list of people.
        /// </summary>
        /// <returns>Sorted List of people.</returns>
        /// <param name="unsortedListOfNames">Unsorted list of people.</param>
        public List<Person> SortNames(List<Person> unsortedListOfNames)
        {
            try{
                unsortedListOfNames.Sort(delegate (Person person1, Person person2)
                {
                    int compareLastName = string.Compare(person1.LastName, person2.LastName, StringComparison.CurrentCulture);
                    return compareLastName == 0 ? -1 : compareLastName;
                });
                List<Person> sortedNames = unsortedListOfNames;
                NLog.LogManager.GetCurrentClassLogger().Info("Names sorted!");
                return sortedNames;
            }
            catch(Exception ex){
                NLog.LogManager.GetCurrentClassLogger().Fatal(ex.Message);
                Console.WriteLine("Error Occured! Check logs for more details.\nExiting program...");
            }
            return null;
        }
    }
}

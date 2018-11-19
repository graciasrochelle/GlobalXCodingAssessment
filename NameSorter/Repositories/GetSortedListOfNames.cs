using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter.Repositories
{
    public class GetSortedListOfNames
    {
        public GetSortedListOfNames()
        {
        }

        public List<Person> SortNames(List<Person> unsortedListOfNames)
        {
            try{
                unsortedListOfNames.Sort(delegate (Person person1, Person person2)
                {
                    int compareLastName = string.Compare(person1.LastName, person2.LastName, StringComparison.CurrentCulture);
                    return compareLastName == 0 ? -1 : compareLastName;
                });
                List<Person> sortedNames = unsortedListOfNames;
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

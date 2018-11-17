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
                List<Person> sortedNames = unsortedListOfNames.OrderBy(p => p.LastName).ToList();
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

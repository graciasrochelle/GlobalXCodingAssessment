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
        /// Algo: (Given names can be at least 1 and at most 3)
        /// If LastName is equal Then take Next Given Name
        ///  If Next Given Name is equal Then take Next Given Name
        ///   If Next Given Name is equal Then take Next Given Name
        ///    If Next Given Name is equal Then take Next Given Name
        public List<Person> SortNames(List<Person> unsortedListOfNames)
        {
            try{
                List<Person> sortedNames = unsortedListOfNames;

                sortedNames.Sort(delegate (Person person1, Person person2)
                {
                    string p1_LastName = person1.LastName;
                    string p2_LastName = person2.LastName;
                    int compareNextGivenName = -1;
                    int compareLastName = CompareLastNames(p1_LastName, p2_LastName);
                    // If lastname is equal then check next given name
                    if(compareLastName == 0){
                        NLog.LogManager.GetCurrentClassLogger().Debug("Last name is equal!Person1:" + p1_LastName +"Person2:"+ p2_LastName);

                        string[] p1_GivenNames = person1.GivenNames;
                        string[] p2_GivenNames = person2.GivenNames;

                        // Compare given names
                        compareNextGivenName = CompareGivenNames(p1_GivenNames, p2_GivenNames);

                        // If Next Given name equal
                        if (compareNextGivenName == 0)
                        {
                            // Check if the length after re-sizing is greater than equal to 0
                            if (p1_GivenNames.Length - 1 >= 0 && p2_GivenNames.Length - 1 >= 0)
                            {
                                // Re-size given names array string
                                Array.Resize(ref p1_GivenNames, p1_GivenNames.Length - 1);
                                Array.Resize(ref p2_GivenNames, p2_GivenNames.Length - 1);

                                // Compare
                                compareNextGivenName = CompareGivenNames(p1_GivenNames, p2_GivenNames);

                                // If Next Given name equal
                                if (compareNextGivenName == 0)
                                {
                                    // Check if the length after re-sizing is greater than equal to 0
                                    if (p1_GivenNames.Length - 1 >= 0 && p2_GivenNames.Length - 1 >= 0)
                                    {
                                        // Re-size given names array string
                                        Array.Resize(ref p1_GivenNames, p1_GivenNames.Length - 1);
                                        Array.Resize(ref p2_GivenNames, p2_GivenNames.Length - 1);

                                        // Compare
                                        return CompareGivenNames(p1_GivenNames, p2_GivenNames);
                                    }
                                }
                                return compareNextGivenName;
                            }
                        }
                        return compareNextGivenName;
                    }
                    return compareLastName;
                });

                NLog.LogManager.GetCurrentClassLogger().Info("Names sorted!");
                return sortedNames;
            }
            catch(Exception ex){
                NLog.LogManager.GetCurrentClassLogger().Fatal(ex.Message);
                Console.WriteLine("Error Occured! Check logs for more details.\nExiting program...");
            }
            return null;
        }

        public static int CompareLastNames(string pName1, string pName2){
            return string.Compare(pName1, pName2, StringComparison.CurrentCulture);
        }

        public static int CompareGivenNames(string[] p1_GivenNames, string[] p2_GivenNames)
        {
            return string.Compare(p1_GivenNames[p1_GivenNames.Length - 1], p2_GivenNames[p2_GivenNames.Length - 1], StringComparison.CurrentCulture);
        }
    }
}

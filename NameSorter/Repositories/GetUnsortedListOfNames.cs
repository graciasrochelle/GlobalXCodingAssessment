using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NameSorter.Repositories
{
    public class GetUnsortedListOfNames
    {

        public GetUnsortedListOfNames()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("GetUnsortedListOfNames() called...");
        }

        /// <summary>
        /// Reads the unsorted names from file and checks if the given names are valid.
        /// </summary>
        /// <returns>list of valid names of people</returns>
        /// <param name="fileName">File name that contains the names of people</param>
        public List<Person> ReadFromFile(string fileName)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    List<Person> unsortedNamesList = new List<Person>();
                    while (streamReader.Peek() >= 0)
                    {
                        String line = streamReader.ReadLine();
                        string[] fullName = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        Boolean isGivenNameValid = new ValidateFullName().IsFullNameValid(fullName);
                        if (isGivenNameValid)
                        {
                            string lastName = fullName[fullName.Length - 1];
                            fullName = fullName.Take(fullName.Count() - 1).ToArray();
                            string[] givenNames = new string[fullName.Length];
                            for (int i = 0; i < givenNames.Length; i++)
                            {
                                givenNames[i] = fullName[i];
                            }
                            Person person = new Person(givenNames, lastName);
                            NLog.LogManager.GetCurrentClassLogger().Info("{Person} add to list!"  , person);
                            unsortedNamesList.Add(person);
                        }
                    }
                    return unsortedNamesList;
                }
            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Fatal(e);
                Console.WriteLine("Error Occured! Check logs for more details.\nExiting program...");
            }
            return null;
        }
    }
}

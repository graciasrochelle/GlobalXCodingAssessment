using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NameSorter.Repositories
{
    public class GetUnsortedListOfNames
    {

        public GetUnsortedListOfNames()
        {
        }

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

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

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
                    long position = 0;
                    List<Person> unsortedNamesList = new List<Person>();
                    while (streamReader.Peek() >= 0)
                    {
                        String fullName = streamReader.ReadLine();
                        string[] name = fullName.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        Person person = new Person();
                        for (int i = 0; i < name.Length - 1; i++)
                        {
                            person.GivenNames += name[i] + " ";
                        }
                        person.Position = position;
                        person.GivenNames = person.GivenNames.Trim();
                        person.LastName = name[name.Length - 1];
                        unsortedNamesList.Add(person);
                        position++;
                    }
                    return unsortedNamesList;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}

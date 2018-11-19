using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace NameSorter.Repositories
{
    public class WriteSortedListOfNames
    {

        public WriteSortedListOfNames()
        {
        }

        public Boolean WriteToFile(string fileName, List<Person> listOfNames)
        {
            try
            {
                using (StreamWriter writetext = new StreamWriter(fileName))
                {
                    for (int i = 0; i < listOfNames.Count; i++)
                    {
                        if (i != listOfNames.Count - 1)
                            writetext.WriteLine(string.Format(listOfNames[i].ToString()));
                        else
                            writetext.Write(string.Format(listOfNames[i].ToString()));
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Fatal(e.Message);
                Console.WriteLine("The file could not be written! Check logs for more details.\nExiting program...");
            }
            return false;
        }
    }
}

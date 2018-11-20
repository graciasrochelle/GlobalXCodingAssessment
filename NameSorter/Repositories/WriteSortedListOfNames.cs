using System;
using System.Collections.Generic;
using System.IO;

namespace NameSorter.Repositories
{
    public class WriteSortedListOfNames
    {
        public WriteSortedListOfNames()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("WriteSortedListOfNames() called...");
        }

        /// <summary>
        /// Writes list of name to file.
        /// </summary>
        /// <returns><c>true</c>, if to file was written, <c>false</c> otherwise.</returns>
        /// <param name="fileName">File name to be written.</param>
        /// <param name="listOfNames">List of names to be written to file.</param>
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
                    NLog.LogManager.GetCurrentClassLogger().Info("Write to File was successful!");
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

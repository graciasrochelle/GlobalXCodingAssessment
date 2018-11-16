using System;
using System.IO;
using System.Collections;
using Microsoft.Extensions.Logging;

namespace NameSorter
{
    public class WriteToFile
    {
        private readonly ILogger<WriteToFile> _logger;

        public WriteToFile(ILogger<WriteToFile> logger)
        {
            _logger = logger;
        }

        public Boolean WriteSortedNameList(ArrayList sortedNamesList, string fileName)
        {
            try
            {
                using (StreamWriter writetext = new StreamWriter(fileName))
                {
                    for (int i = 0; i < sortedNamesList.Count; i++){
                        if(i != sortedNamesList.Count-1)
                            writetext.WriteLine(string.Format(sortedNamesList[i].ToString()));
                        else
                            writetext.Write(string.Format(sortedNamesList[i].ToString()));
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be written:");
                Console.WriteLine(e.Message);
            }
            return false;
        }
    }
}

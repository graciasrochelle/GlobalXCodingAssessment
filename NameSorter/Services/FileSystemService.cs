using System;
using System.Collections.Generic;
using System.IO;
using NameSorter.Controllers;
using NameSorter.Interfaces;
using NameSorter.Utils;

namespace NameSorter.Services
{
    public class FileSystemService
    {
        readonly IFileSystem _fileSystem;

        public FileSystemService()
        {
            _fileSystem = new FileSystemController();
        }

        /// <summary>
        /// Reads from file if the file exists
        /// </summary>
        /// <returns>List of people read from file.</returns>
        /// <param name="inputFileName">Input file name.</param>
        public List<Person> ReadFromFile(string inputFileName)
        {
            string inputFilePath = inputFileName;

            Boolean isFileExits = _fileSystem.ValidateIfFileExists(inputFilePath);
            if(isFileExits){
                inputFilePath = Path.GetFullPath(inputFilePath);
                Console.WriteLine(inputFilePath + " was read!\n");
                return _fileSystem.GetListOfNames(inputFilePath);
            }
            return null;
        }

        /// <summary>
        /// Writes list of people to file if the file.
        /// </summary>
        /// <returns><c>true</c>, if list of people written, <c>false</c> otherwise.</returns>
        /// <param name="people">List of people to be written to file.</param>
        public Boolean WriteToFile(List<Person> people)
        {
            if(people!=null){
                String outputFilePath = Path.GetFullPath(Constants.FilePath + Constants.OutputFileName);
                Boolean isFileWritten = _fileSystem.WriteToFile(outputFilePath, people);

                if (isFileWritten)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nThe names was written to " + outputFilePath);
                    Console.ResetColor();
                    return true;
                }
            }
            return false;    
        }
    }
}

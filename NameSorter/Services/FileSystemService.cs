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
            Boolean isFileExits = _fileSystem.ValidateIfFileExists(inputFileName);
            if(isFileExits){
                String inputFilePath = Path.GetFullPath(inputFileName);
                Console.WriteLine(inputFileName + " was read!");
                return _fileSystem.GetListOfNames(inputFileName);
            }
            return null;
        }

        /// <summary>
        /// Writes to file if the file exists.
        /// </summary>
        /// <returns><c>true</c>, if file exists write to file, <c>false</c> otherwise.</returns>
        /// <param name="people">List of people to be written to file.</param>
        public Boolean WriteToFile(List<Person> people)
        {
            String outputFilePath = Path.GetFullPath(Constants.OutputFileName);
            Boolean isFileWritten = _fileSystem.WriteToFile(outputFilePath, people);

            if (isFileWritten)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("The names was written to " + outputFilePath);
                Console.ResetColor();
                return true;
            }
            return false;    
        }
    }
}

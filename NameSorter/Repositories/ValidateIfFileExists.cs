using System;
using System.IO;

namespace NameSorter.Repositories
{
    public class ValidateIfFileExists
    {
        readonly string _errorMessage;

        public ValidateIfFileExists()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ValidateIfFileExists() called...");
            _errorMessage = "File doesn't exists! Please ensure the input file exists!";
        }

        /// <summary>
        /// Checks if file is valid
        /// </summary>
        /// <returns><c>true</c>, if file exists, <c>false</c> otherwise.</returns>
        public Boolean IsFileExists(string filename)
        {
            string filePath = Path.GetFullPath(filename);
            if (File.Exists(filePath))
            {
                NLog.LogManager.GetCurrentClassLogger().Info("File exists!");
                return true;
            }
            NLog.LogManager.GetCurrentClassLogger().Fatal(_errorMessage);
            Console.WriteLine(_errorMessage);
            return false;
        }
    }
}

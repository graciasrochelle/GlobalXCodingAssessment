using System;
using System.Linq;
using NameSorter.Utils;

namespace NameSorter.Repositories
{
    public class ValidateFullName
    {
        public ValidateFullName()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ValidateFullName() called...");
        }

        /// <summary>
        /// Checks if the full name of a person is valid i.e. if the given name at least is 1 and at most 3.
        /// </summary>
        /// <returns><c>true</c>, if given name is at least 1 and at most 3, <c>false</c> otherwise.</returns>
        /// <param name="fullName">Full name of a person i.e. Given names and last name.</param>
        public Boolean IsFullNameValid(string[] fullName){
            try
            {
                if(fullName.Length >= Constants.MinNumberOfNames)
                {
                    string lastName = fullName[fullName.Length - 1];
                    fullName = fullName.Take(fullName.Count() - 1).ToArray();
                    string[] givenNames = new string[fullName.Length];
                    for (int i = 0; i < givenNames.Length; i++)
                    {
                        givenNames[i] = fullName[i];
                    }
                    if (givenNames.Length >= Constants.MinNumberOfGivenNames && givenNames.Length <= Constants.MaxNumberOfGivenNames)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                NLog.LogManager.GetCurrentClassLogger().Fatal("\n"+ex.Message);
                Console.WriteLine("Error Occured while validating fullname!Check logs for more details.\nExiting program...");
            }
            NLog.LogManager.GetCurrentClassLogger().Info("Not a valid name!");
            return false;
        }
    }
}

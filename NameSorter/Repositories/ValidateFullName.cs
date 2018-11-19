using System;
using System.Linq;

namespace NameSorter.Repositories
{
    public class ValidateFullName
    {
        public ValidateFullName()
        {
        }

        public Boolean IsFullNameValid(string[] fullName){
            try
            {
                if(fullName.Length > 1){
                    string lastName = fullName[fullName.Length - 1];
                    fullName = fullName.Take(fullName.Count() - 1).ToArray();
                    string[] givenNames = new string[fullName.Length];
                    for (int i = 0; i < givenNames.Length; i++)
                    {
                        givenNames[i] = fullName[i];
                    }
                    if (givenNames.Length >= 1 && givenNames.Length <= 3)
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
            return false;
        }
    }
}

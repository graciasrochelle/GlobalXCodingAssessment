using System;
namespace NameSorter.Repositories
{
    public class CheckGivenNameValid
    {
        public CheckGivenNameValid()
        {
        }

        public Boolean IsGivenNamesValid(string[] givenNames){
            try
            {
                if(givenNames.Length >= 1 && givenNames.Length <= 3){
                    return true;
                }
            }
            catch (Exception ex)
            {
                NLog.LogManager.GetCurrentClassLogger().Fatal(ex.Message);
                Console.WriteLine("Error Occured! Check logs for more details.\nExiting program...");
            }
            return false;
        }
    }
}

using System;

namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var logger = NLog.LogManager.GetCurrentClassLogger();
            if (args.Length < 2)
            {
                logger.Error("Please pass valid arguments!");
                logger.Info("\nArgument 1 : name-soter \nArgument 2 : input filename");
                Console.WriteLine("\nArgument 1 : name-soter \nArgument 2 : input filename.\nProgram exiting!");
            }else{
                if (args[0] != null && args[1] != null)
                {

                    var programName = args[0];
                    var inputFileName = args[1];

                    switch (programName)
                    {
                        case "name-sorter":
                            new NameSorterService(inputFileName).StartNameSorter();
                            break;
                        default:
                            Console.WriteLine("Please pass correct arguments!");
                            NLog.LogManager.GetCurrentClassLogger().Fatal("Arguments miss match!\nArgument 1 : name-soter and Argument 2 : input filename");
                            break;
                    }
                }
            }
            NLog.LogManager.Shutdown();
            Console.ResetColor();
        }
    }
}

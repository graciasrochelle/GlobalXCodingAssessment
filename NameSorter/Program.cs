    using System;

    namespace NameSorter
    {
        class Program
        {
            /// <summary>
            /// The entry point of the program, where the program control starts and ends.
            /// </summary>
            /// <param name="args">Takes two command-line arguments :- argument 1 : feature name and argument 2 : input filename</param>
            static void Main(string[] args)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                var logger = NLog.LogManager.GetCurrentClassLogger();

                if (args.Length < 2)
                {
                    string errorMessage = "Please pass valid arguments!\nArgument 1 : name-soter \nArgument 2 : input filename";
                    logger.Error(errorMessage);
                    Console.WriteLine(errorMessage);
                }
                else{
                    if (args[0] != null && args[1] != null)
                    {

                        var programName = args[0];
                        var inputFileName = args[1];

                        switch (programName)
                        {
                            case "name-sorter":
                                new NameSorterService().StartNameSorter(inputFileName);
                                break;
                            default:
                                Console.WriteLine("Please pass correct arguments!\n Set env. variables:: name-sorter ./unsorted-names-list.txt");
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

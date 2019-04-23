using System;
using CoreySutton.PrettyCon;

namespace TestConsoleApp
{
    class Program
    {
        private static PrettyCon pCon;
        static void Main()
        {
            pCon = new PrettyCon();
            Print();

            pCon.EnableStopwatch = true;
            Print();

            pCon.EnableTimestamp = true;
            Print();

            pCon.EnableStopwatch = false;
            Print();

            pCon.EnableTimestamp = false;
            Print();

            Console.WriteLine("Press <Enter> to close");
            Console.ReadLine();
        }

        private static void Print()
        {
            pCon.Debug("This is a debug message");
            pCon.Verbose("This is a verbose message");
            pCon.Info("This is a information message");
            pCon.Info("This is a coloured information message", ConsoleColor.Magenta);
            pCon.Warning("This is a warning message");
            pCon.Error("This is an error message");
            pCon.Exception(new Exception("This is an exception message"));
            pCon.Status("This is a status", "SUCCESS", ConsoleColor.Green);
            pCon.Status("This is a status", "SKIPPED", ConsoleColor.Yellow);
            pCon.Status("This is a status", "FAILURE", ConsoleColor.Red);
            pCon.Status(
                "This is a very very very very very very long status that will " +
                "take up a lot of space in the console output", 
                "SKIPPED", 
                ConsoleColor.Yellow);
            pCon.Status("This is a very very very very very very very very very " +
                "very very very very very very very very very very very very " +
                "very very very very very very very very very very very very " +
                "very very very long status that will take up a lot of space " +
                "in the console output", 
                "FAILURE", 
                ConsoleColor.Red);
            pCon.Break();
        }
    }
}

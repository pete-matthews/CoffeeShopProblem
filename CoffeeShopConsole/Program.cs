using System;

namespace CoffeeShop.Console
{
    public class Program
    {
        public InputHandler InputHandler { get; } = new InputHandler();

        private static void Main()
        {
            var prog = new Program();

            prog.InputHandler.SetupData();
            prog.RunProgram();
        }

        private void RunProgram()
        {
            string command;
            do
            {
                command = System.Console.ReadLine() ?? "";
                ProcessInput(command.ToLower());
            } while (command != "exit");
        }

        private void ProcessInput(string enteredText)
        {
            if (enteredText.Contains("print summary"))
                InputHandler.PrintSummary();
            else if (enteredText.Contains("add general"))
                InputHandler.AddGeneral(enteredText);
            else if (enteredText.Contains("add loyalty"))
                InputHandler.AddLoyalty(enteredText);
            else if (enteredText.Contains("add student"))
                InputHandler.AddStudent(enteredText);
            else if (enteredText.Contains("add employee"))
                InputHandler.AddEmployee(enteredText);
            else if (enteredText.Contains("exit"))
                Exit();
            else
                UnknownInput();
        }

        private void UnknownInput()
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("UNKNOWN INPUT");
            System.Console.ResetColor();
        }

        private void Exit()
        {
            Environment.Exit(1);
        }
    }
}
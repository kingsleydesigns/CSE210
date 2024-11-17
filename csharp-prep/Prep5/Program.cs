using System;

class Program
{
    static void Main(string[] args)
    {
        static void MainFunction()
        {
            DisplayWelcome();
            string userName = PromptUserName();
            int userNumber = PromptUserNumber();
            int square = SquareNumber(userNumber);
            DisplayResult(userName,square);
        }

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            string input = Console.ReadLine();
            int number = int.Parse(input);
            return number;
        }

        static int SquareNumber(int number)
        {
            int square = number * number;
            return square;
        }

        static void DisplayResult(string name, int square)
        {
            Console.WriteLine($"{name},the square of your number is {square}");
        }  

        MainFunction();

    }
}
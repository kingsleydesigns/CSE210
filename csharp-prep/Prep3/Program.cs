using System;

class Program
{
    static void Main(string[] args)
    {   // This is the code block for Core 1 and 2 requirements, where the user specified the magic number
        
        // Console.Write("What is the magic number? ");
        // int magicNumber = int.Parse(Console.ReadLine());


        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);

        Console.Write("What is your guess? ");
        string input = Console.ReadLine();
        int guess = int.Parse(input);

        while (guess != number)
        {
            if (guess > number)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Higher");
            }

            Console.Write("What is your guess? ");
            input = Console.ReadLine();
            guess = int.Parse(input);
        }

        Console.WriteLine("Correct! You guessed the number!");
    }
}
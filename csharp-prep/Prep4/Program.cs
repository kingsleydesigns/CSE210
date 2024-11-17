using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {   // I read online about using system.Linq which helps compute
        // sum and Max functions easily without needing to use a foreach loop.
        // So i went with that


        List <int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        Console.Write("Enter number: ");
        String answer = Console.ReadLine();
        int input = int.Parse(answer);

        while (input != 0)
        {
            numbers.Add(input);
            Console.Write("Enter number: ");
            answer = Console.ReadLine();
            input = int.Parse(answer);
        }


        int total = numbers.Sum();
        float average = ((float) total) / numbers.Count;
        int largest = numbers.Max();

        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}
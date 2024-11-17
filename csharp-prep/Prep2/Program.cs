using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userinput = Console.ReadLine(); 
        int gradePercent = int.Parse(userinput);
        
        string letter = "";

        if (gradePercent>= 90 )
        {
            letter = "A";
        }
        else if (gradePercent >= 80)
        {
            letter = "B";
        }
        else if (gradePercent >= 70)
        {
            letter = "C";
        }
        else if (gradePercent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        
        Console.WriteLine($"Your grade for this course is: {letter}");




        if (gradePercent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Sorry, you didn't pass the course. Work harder next semester and better luck next time!");
        }

    }
}
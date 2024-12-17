using System;

class Program
{
    static void Main(string[] args)
    {
       var Assign1 = new Assignment ("Samuel Bennett", "Multiplication");
       Console.WriteLine(Assign1.GetSummary());
       Console.WriteLine();


       var Math1 = new MathAssignment ("Roberto Rodriguez", "Fractions", "7.3", "8-19");
       Console.WriteLine(Math1.GetSummary());
       Console.WriteLine(Math1.GetHomeworkList());
       Console.WriteLine();


       var Write1 = new WritingAssignment ("Mary Waters", "European History", "The Causes of World War II");
       Console.WriteLine(Write1.GetSummary());
       Console.WriteLine(Write1.GetWritingInformation());
       Console.WriteLine();
    }
}
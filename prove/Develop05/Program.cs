//For creativity, i deceided to keep a log of how many times activities were performed
//and to do so, i made use of an Activity dictionary which i added to the Activity class.
//I also had to create an UpdateActivityLog and a DisplayActivityLog method to act as a getter and setter.
//Finally, i added the option to View the Activity Log in the Menu 

using System;

class Program
{
    static void Main(string[] args)
    {   
        Console.Clear();
        while (true)
            {
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Listing Activity");
                Console.WriteLine("3. Reflection Activity");
                Console.WriteLine("4. View Activity Log");
                Console.WriteLine("5. Quit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    new BreathingActivity().Run();
                    Activity.UpdateActivityLog("Breathing Activity");
                }
                else if (choice == "2")
                {
                    new ListingActivity().Run();
                    Activity.UpdateActivityLog("Listing Activity");
                }
                else if (choice == "3")
                {
                    new ReflectingActivity().Run();
                    Activity.UpdateActivityLog("Reflection Activity");
                }
                else if (choice == "4")
                {
                    Activity.DisplayActivityLog(); // Show activity log
                    Console.WriteLine("Press Enter to return to the menu...");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (choice == "5")
                {
                    Console.Clear();
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    Thread.Sleep(1000);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }

        Activity.ClearActivityLog();
    }
    
}
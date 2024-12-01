//For Creativity, i added time to the Entry attribute/member variable (so it is saved and displayed with each prompt)
// as well as calling it from the datetime structure(In line 21) and saving it to corresponding Entry attribute (line 53)
//I also added seamless experience for the user by letting them know the result of their menu picks such
//as when their entries have been added, if their file has been saved or loaded, as well as handling
//wrong/non-existent menu picks or if they call the display function without making any entries.
//Finally, i also handled loading of different files by clearing the currently saved entries for display when
//loading a new file so if the display option is picked from the menu, only the last loaded file entries are shown


using System;
using System.CodeDom.Compiler;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        //Saving the time to be called as part of my ]creativity
        string timeText = theCurrentTime.ToString("hh:mm tt");

        Console.WriteLine("Welcome to the Journal Program!");
        int ans = 0;

        Journal myJournal = new Journal();

        while (ans != 5)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            string input = Console.ReadLine();
            ans = int.Parse(input);

            if (ans == 1)
            {
                PromptGenerator generate = new PromptGenerator();
                string Prompt = generate.GetRandomPrompt();
                Console.WriteLine(Prompt);
                Console.Write(">");
                string userText = Console.ReadLine();

                Entry userEntry = new Entry();
                userEntry._entryText = userText;
                userEntry._date = dateText;
                userEntry._time = timeText;
                userEntry._promptText = Prompt;

                myJournal.AddEntry(userEntry);

            }

            else if (ans == 2)
            {
                myJournal.DisplayAll();
            }

            else if ( ans == 3)
            {
                Console.WriteLine("What is the filename?");
                string file = Console.ReadLine();
                myJournal.LoadFromFile(file);
            }

            else if ( ans == 4)
            {
                Console.WriteLine("What is the filename?");
                string file = Console.ReadLine();
                myJournal.SaveToFile(file);
            }

            else if (ans == 5)
            {
                Console.WriteLine("End of Journaling");  // Option 5 to quit
                break;  // Break out of the while loop and end the program
            }

            else
            {
                Console.WriteLine("Invalid choice. Please select a valid option.");
            }
        }
    }
}
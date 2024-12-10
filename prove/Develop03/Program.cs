// For creativity, I had my program work with a library of scriptures rather than a single one and then Choose scriptures at random to present to the user.
//To Incorporate this, i created another class called ScriptureLibrary and then accessed it from the Original Scripture class using a Constructor where this Scripture Library
//is passed as a parameter.
//I also created logic to handle the user typing something aside from "quit"


using System;

class Program
{
    static void Main(string[] args)
    {
        var library = new ScriptureLibrary();

        // Add scriptures to the library
        library.AddScripture(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all your heart, and lean not on your own understanding; in all your ways acknowledge him, and he will make straight your paths."
        ));
        library.AddScripture(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
        ));
        library.AddScripture(new Scripture(
            new Reference("Psalm", 23, 1),
            "The Lord is my shepherd; I shall not want."
        ));

        // Instantiate the scripture using the library
        var scripture = new Scripture(library);

        // Memorization logic
        while (!scripture.IsCompletelyHidden()) {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit:");

            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "quit") 
            {
                Console.WriteLine("Program exited.");
                return; // Ends the program immediately
            } 

            else if (string.IsNullOrEmpty(input)) 
            {
                scripture.HideRandomWords(2);
            } 
            
            else 
            {
                Console.WriteLine("Invalid input. Press Enter to continue or type 'quit' to exit.");
                Console.ReadLine();
            }
        }

        // Final message when all words are hidden
        Console.Clear();
        Console.WriteLine("All words are hidden. Program complete.");
    }
}
//Addition of time to the SaveToFile and LoadFromFile method for creativity


using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry (Entry newEntry)
    {
        _entries.Add(newEntry);// Adds the user's entry to the journal
        Console.WriteLine("Entry added to the journal!"); //Tells the user that their entries have been added succesfully
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display."); //Handles case of no entries in the journal befor requesting a display
        }
        else{
            foreach (Entry entry in _entries)
            {
                entry.Display(); // Displays all entries by calling the display method from the entry class
            }
        }
        
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                // Include time in the formatted entry
                string formattedEntry = $"Date: {entry._date} - Prompt: {entry._promptText}\n{entry._entryText}\nTime: {entry._time}\n";
                outputFile.WriteLine(formattedEntry); // Write the formatted entry to the file.
            }
            Console.WriteLine($"Your entries have been saved to {file}!");
        }
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear(); // Clear the existing entries before loading new ones

        string[] lines = System.IO.File.ReadAllLines(file);  // Read all lines from the file

        for (int i = 0; i < lines.Length; i++)
        {
            // Skip empty lines (the blank line after each entry)
            if (string.IsNullOrWhiteSpace(lines[i]))
            {
                continue;
            }

            string dateAndPrompt = lines[i];  // First line: Date and Prompt
            string entryText = "";
            string timeText = "";  // To store the time

            // Get the second line for the entry text
            if (i + 1 < lines.Length && !string.IsNullOrWhiteSpace(lines[i + 1]))
            {
                entryText = lines[++i];  // Second line: Entry Text
            }

            // Check for the time in the next line
            if (i + 1 < lines.Length && lines[i + 1].StartsWith("Time:"))
            {
                timeText = lines[++i].Substring(5).Trim();  // Extract time (after "Time:")
            }

            // Split date and prompt into separate components
            string[] datePromptParts = dateAndPrompt.Split(" - ");
            if (datePromptParts.Length < 2)
            {
                Console.WriteLine($"Malformed entry detected: {dateAndPrompt}");
                continue;  // Skip this entry if invalid
            }

            string entryDate = datePromptParts[0].Trim();
            string promptText = datePromptParts[1].Trim();

            // Create and add the entry to the journal
            Entry userEntry = new Entry
            {
                _entryText = entryText,
                _date = entryDate,
                _promptText = promptText,
                _time = timeText  // Set the time
            };

            _entries.Add(userEntry);  // Add entry to journal
            
        }
        Console.WriteLine($"Your entries have been loaded from {file}!");
    }
}
//Addition of time to the display method for creativity

public class Entry
{
    public string _date;
    public string _time;
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine(_entryText); 
        Console.WriteLine($"Time: {_time}");
        Console.WriteLine();
    }
}
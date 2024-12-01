public class PromptGenerator{
    public List<string> _prompts;

     public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "If I had one thing I could do over today, what would it be?",
            "What was the best part of my day?",
            "What was I most grateful for today?",
            "What was the best part of my day?",
            "What did I do today that I really admired and would do again?"
        };
    }
    public string GetRandomPrompt()
    {

        Random randomprompt = new Random();
        return _prompts[randomprompt.Next(_prompts.Count)];

    }
}
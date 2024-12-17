public class ListingActivity : Activity
    {
        private int _count;
        private List<string> _prompts;

        public ListingActivity()
        {
            _name = "Listing Activity";
            _description = "This activity will help you reflect on the good things in your life by having you list positive things in a certain area of your life.";
            _prompts = new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt happy recently?",
                "Who are some of your personal heroes?"
            };
        }

        public void Run()
        {
            Console.Clear();
            DisplayStartingMessage();

            Console.WriteLine("List as many responses as you can to the following prompt:");
            GetRandomPrompt();
            Console.WriteLine("You have a few seconds to prepare...");
            ShowCountdown(5);

            List<string> userResponses = GetListFromUser();

            _count = userResponses.Count;
            Console.WriteLine($"\nYou listed {_count} items!");

            DisplayEndingMessage();
            Thread.Sleep(500);
            Console.Clear();
        }

        public void GetRandomPrompt()
        {
            Random random = new Random();
            Console.WriteLine(_prompts[random.Next(_prompts.Count)]);
        }

        public List<string> GetListFromUser()
        {
            List<string> responses = new List<string>();
            Console.WriteLine("Start listing items:");

            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                string input = Console.ReadLine();
                responses.Add(input);
            }

            return responses;
        }
    }
public class ReflectingActivity : Activity
    {
        private List<string> _prompts;
        private List<string> _questions;

        public ReflectingActivity()
        {
            _name = "Reflection Activity";
            _description = "This activity will help you reflect on times you have shown strength and resilience.";
            _prompts = new List<string>
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };
            _questions = new List<string>
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What is your favorite thing about this experience?"
            };
        }

        public void Run()
        {
            Console.Clear();
            DisplayStartingMessage();

            DisplayPrompt();

            Console.WriteLine("When you are ready to begin answering questions, press Enter...");
            Console.ReadLine(); // Wait for Enter key input

            Console.WriteLine("Now ponder on the following questions in relation to this experience.");
            Console.WriteLine("You may start in: ");
            ShowCountdown(3);

            Console.Clear();
            DisplayQuestions();

            DisplayEndingMessage();
            Thread.Sleep(500);
            Console.Clear();
        }

        public string GetRandomPrompt()
        {
            Random random = new Random();
            return _prompts[random.Next(_prompts.Count)];
        }

        public void GetRandomQuestion()
        {
            Random random = new Random();
            string question = _questions[random.Next(_questions.Count)];
            Console.WriteLine(question);
        }

        public void DisplayPrompt()
        {
            string prompt = GetRandomPrompt();
            Console.WriteLine(prompt);
            ShowSpinner(5);
        }


        private void DisplayQuestions()
        {
            DateTime endTime = DateTime.Now.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                GetRandomQuestion(); // Displays a random question
                ShowSpinner(7);
            }
        }
    }
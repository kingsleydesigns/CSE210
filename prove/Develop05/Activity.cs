public class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;

        // Static dictionary to keep track of activity counts
        private static Dictionary<string, int> activityLog = new Dictionary<string, int>();

        // Default constructor
        public Activity()
        {
            _name = "Default Activity";
            _description = "This is a default mindfulness activity.";
        }

        // Displays the starting message
        public void DisplayStartingMessage()
        {
            Console.WriteLine($"\nWelcome to the {_name}");
            Console.WriteLine(_description);
            Console.Write("Enter the duration (in seconds): ");
            _duration = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Prepare to begin shortly:");
            ShowSpinner(5);
        }

        // Displays the ending message
        public void DisplayEndingMessage()
        {
            Console.WriteLine("\nWell done!");
            ShowSpinner(5);
            Console.WriteLine("You have completed the activity."); 
            Console.WriteLine($"You spent {_duration} seconds on the {_name}.");
            ShowSpinner(5);
        }

        // Shows a spinner for 'seconds'
        public void ShowSpinner(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.Write("\r       \r");
            Console.WriteLine();
        }

        // Shows a countdown timer for 'seconds'3
        public void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }

        public static void UpdateActivityLog(string activityName)
        {
            if (activityLog.ContainsKey(activityName))
                activityLog[activityName]++;
            else
                activityLog[activityName] = 1;
        }

        public static void DisplayActivityLog()
        {
            Console.WriteLine("\nActivity Log:");
            foreach (var entry in activityLog)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value} time(s)");
            }
            Console.WriteLine();
        }

        public static void ClearActivityLog()
        {
            activityLog.Clear();
        }
    }
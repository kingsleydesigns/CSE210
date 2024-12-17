public class BreathingActivity : Activity
    {
        public BreathingActivity()
        {
            _name = "Breathing Activity";
            _description = "This activity will help you relax by guiding you to breathe in and out slowly. Focus on your breathing.";
        }

        public void Run()
        {
            Console.Clear();
            DisplayStartingMessage();

            for (int i = 0; i < _duration / 6; i++) // 6 seconds per breathing cycle
            {
                Console.WriteLine("Breathe in...");
                ShowCountdown(3);

                Console.WriteLine("Now Breathe out...");
                ShowCountdown(3);
            }

            DisplayEndingMessage();
            Thread.Sleep(500);
            Console.Clear();
        }
    }
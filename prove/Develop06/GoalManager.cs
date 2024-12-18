public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _completedSimpleGoals;
    private int _completedChecklistGoals;
    private int _eternalEventsRecorded;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _completedSimpleGoals = 0;
        _completedChecklistGoals = 0;
        _eternalEventsRecorded = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine(" 1. Display Player Info");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Create Goal");
            Console.WriteLine(" 4. Record Event");
            Console.WriteLine(" 5. Save Goals");
            Console.WriteLine(" 6. Load Goals");
            Console.WriteLine(" 7. Exit");

            Console.Write("Please select a choice from the Menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                DisplayPlayerInfo();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                CreateGoal();
            }
            else if (choice == "4")
            {
                RecordEvent();
            }
            else if (choice == "5")
            {
                SaveGoals();
            }
            else if (choice == "6")
            {
                LoadGoals();
            }
            else if (choice == "7")
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
        Console.WriteLine(GetPlayerTitles());
    }

    private string GetPlayerTitles()
    {
        string simpleTitle = _completedSimpleGoals >= 10 ? "Simple Legend"
                           : _completedSimpleGoals >= 5 ? "Simple Warrior"
                           : _completedSimpleGoals >= 3 ? "Simple Rookie"
                           : "No Title";

        string checklistTitle = _completedChecklistGoals >= 10 ? "Checklist Conqueror"
                              : _completedChecklistGoals >= 5 ? "Checklist Master"
                              : _completedChecklistGoals >= 3 ? "Checklist Rookie"
                              : "No Title";

        string eternalTitle = _eternalEventsRecorded >= 50 ? "Eternal Champion"
                          : _eternalEventsRecorded >= 30 ? "Eternal Defender"
                          : _eternalEventsRecorded >= 10 ? "Eternal Apprentice"
                          : "No Title";

        return $"Titles: \n- SimpleGoal: {simpleTitle}\n- ChecklistGoal: {checklistTitle}\n- EternalGoal: {eternalTitle}";
    }
    
    private void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    private void CreateGoal()
    {
        Console.Write("Choose Goal Type (1: Simple, 2: Eternal, 3: Checklist): ");
        string type = Console.ReadLine();
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("Target: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid type. Goal not created.");
        }
    }

    private void RecordEvent()
    {   
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Select a goal to record (number): ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            Goal selectedGoal = _goals[choice];
            selectedGoal.RecordEvent();

            int pointsEarned = selectedGoal.Points;

            if (selectedGoal is SimpleGoal simple && simple.IsComplete())
            {
                _completedSimpleGoals++;
            }
            else if (selectedGoal is ChecklistGoal checklist)
            {
                if (checklist.AmountCompleted >= checklist.Target)
                {
                    _completedChecklistGoals++;
                    pointsEarned += checklist.Bonus; // Add bonus points for message
                    _score += checklist.Bonus; // Add bonus points to the total score
                }
            }
            else if (selectedGoal is EternalGoal)
            {
                _eternalEventsRecorded++;
            }

            _score += selectedGoal.Points;

            Console.WriteLine($"Recorded! Points Earned: {pointsEarned}");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }


    private void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    private void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            _goals.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                _score = int.Parse(reader.ReadLine());
                _completedSimpleGoals = 0;
                _completedChecklistGoals = 0;
                _eternalEventsRecorded = 0;

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts[0] == "SimpleGoal")
                    {
                        SimpleGoal simpleGoal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        if (bool.Parse(parts[4]))
                        {
                            simpleGoal.RecordEvent();
                            _completedSimpleGoals++;
                        }
                        _goals.Add(simpleGoal);
                    }
                    else if (parts[0] == "EternalGoal")
                    {
                        EternalGoal eternalGoal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                        _goals.Add(eternalGoal);
                        // Assume EternalGoal events are not persisted and need to be restored manually
                    }
                    else if (parts[0] == "ChecklistGoal")
                    {
                        ChecklistGoal checklistGoal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[6]));
                        for (int i = 0; i < int.Parse(parts[4]); i++)
                        {
                            checklistGoal.RecordEvent();
                        }
                        if (checklistGoal.IsComplete())
                        {
                            _completedChecklistGoals++;
                        }
                        _goals.Add(checklistGoal);
                    }
                }
            }

            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
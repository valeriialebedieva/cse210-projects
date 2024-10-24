using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool exit = false;
        while (!exit)
        {
            DisplayPlayerInfo();
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. List Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ListGoalDetails();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    exit = true;
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose a type of goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        string goalType = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;
        if (goalType == "1")
        {
            newGoal = new SimpleGoal(name, description, points);
        }
        else if (goalType == "2")
        {
            newGoal = new EternalGoal(name, description, points);
        }
        else if (goalType == "3")
        {
            Console.Write("Enter target: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            newGoal = new ChecklistGoal(name, description, points, target, bonus);
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
        }
    }

    public void RecordEvent()
{
    Console.WriteLine("Which goal did you accomplish?");
    ListGoalNames();
    int goalIndex = int.Parse(Console.ReadLine()) - 1;

    if (goalIndex >= 0 && goalIndex < _goals.Count)
    {
        _goals[goalIndex].RecordEvent(); 
        _score += _goals[goalIndex].GetPoints(); 

        if (_goals[goalIndex].IsComplete()) 
        {
            Console.WriteLine($"Goal {_goals[goalIndex].GetDetailsString()} completed!");
        }
    }
}

public void SaveGoals()
{
    using (StreamWriter writer = new StreamWriter("goals.txt", false)) 
    {
        writer.WriteLine(_score); 
        int goalNumber = 1;
        foreach (var goal in _goals)
        {
           
            writer.WriteLine($"{goalNumber}. {goal.GetDetailsString()}");
            goalNumber++;
        }
    }
    Console.WriteLine("Goals saved successfully.");
}

public void LoadGoals()
{
    if (File.Exists("goals.txt"))
    {
        using (StreamReader reader = new StreamReader("goals.txt"))
        {
            _score = int.Parse(reader.ReadLine()); 
            _goals.Clear(); 

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                
                int dotIndex = line.IndexOf(". ");
                if (dotIndex > 0)
                {
                    
                    string goalDetails = line.Substring(dotIndex + 2); 
                    string[] detailsParts = goalDetails.Split(':');

                    if (detailsParts.Length >= 2)
                    {
                        string name = detailsParts[0].Trim(); 
                        string description = detailsParts[1].Trim(); 

                        Goal goal = new SimpleGoal(name, description, 0); 
                        _goals.Add(goal);
                    }
                }
                else
                {
                    Console.WriteLine("Error: Invalid format in goals.txt");
                }
            }
        }
        Console.WriteLine("Goals loaded successfully.");
    }
    else
    {
        Console.WriteLine("No saved goals found.");
    }
  }
}
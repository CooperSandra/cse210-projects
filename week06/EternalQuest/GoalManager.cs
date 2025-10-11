using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Enumeration;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;

    public void Start()
    {
        bool quit = false;
        while (!quit)
        {   //Menu options
            Console.WriteLine("\n===Menu Options===");
            Console.WriteLine("1. Create Goals");
            Console.WriteLine("2. List Goal Names");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Display Player Info");
            Console.WriteLine("6. Save Goals");
            Console.WriteLine("7. Load Goals");
            Console.WriteLine("8. Quit");
            Console.WriteLine("Select a choice from the menu. ");
            string userOption = Console.ReadLine();

            switch (userOption)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalNames();
                    break;
                case "3":
                    ListGoalDetails();
                    break;
                case "4":
                    RecordEvent();
                    break;
                case "5":
                    DisplayPlayerInfo();
                    break;
                case "6":
                    SaveGoals();
                    break;
                case "7":
                    LoadGoals();
                    break;
                case "8":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }


    //Display the user stats/info
    public void DisplayPlayerInfo()
    {   //Display user score level
        Console.WriteLine($"Score: {_score}");
        Console.WriteLine($"Level: {_level}");
    }

    //List Goal Names
    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].Name}");
        }
    }

    //List Goal Details
    private void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    //Create Goal
    private void CreateGoal()
    {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.WriteLine("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.WriteLine("What is a short description of your goal? ");
        string description = Console.ReadLine();
        Console.WriteLine("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
            _goals.Add(new SimpleGoal(name, description, points));
        else if (type == "2")
            _goals.Add(new EternalGoal(name, description, points));
        else if (type == "3")
        {
            Console.WriteLine("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new CheckListGoal(name, description, points, target, bonus));

        }
        else
            Console.WriteLine("Invalid type");
    }
    //RecordEvent 
    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record");
            return;
        }

        ListGoalNames();
        Console.WriteLine("Enter the goal number");
        if (!int.TryParse(Console.ReadLine(), out int idx) || idx < 1 || idx > _goals.Count)
        {
            Console.WriteLine("Invalid choice");
            return;
        }

        Goal g = _goals[idx - 1];
        //Before invoking RecordEvent, state is captured. 
        bool wasComplete = g.IsComplete();
        int prevAmount = 0;
        if (g is CheckListGoal cg)
            prevAmount = cg.AmountCompleted;

        g.RecordEvent();
        //Determine points earned and updates the user score
        int earned = 0;
        if (g is EternalGoal)
        {
            earned = g.Points;
        }
        else if (g is SimpleGoal)
        {
            if (!wasComplete && g.IsComplete()) //Award points only if goal was not already completed.
                earned = g.Points;
        }
        else if (g is CheckListGoal cgoal)
        {   //If the count increased, points is awarded.
            if (cgoal.AmountCompleted > prevAmount)
                earned += cgoal.Points; //increment
            if (cgoal.AmountCompleted == cgoal.Target && prevAmount < cgoal.Target)
                earned += cgoal.Bonus; //Bonus points awarded.
        }

        _score += earned; //Update score
        Console.WriteLine($"You earned {earned} points.");
        UpdateLevel(); //Handle level
        CheckMilestones(); //Handle Milestone
    }

    //Level added
    private void UpdateLevel()
    {
        int newLevel = (_score / 1000) + 1;
        if (newLevel > _level)
        {
            _level = newLevel; // 
            Console.WriteLine($"🌟LevelUp! You are now at Level {_level}!🌟");
        }
    }

    //Milestone added
    private void CheckMilestones()
    {
        if (_score >= 10000)
            Console.WriteLine("🏆Milestone: 10,000 points. Congratulations!");
        else if (_score >= 5000)
            Console.WriteLine("⭐Milestone: 5,0000 points. Congratulations!");
        else if (_score >= 1000)
            Console.WriteLine("🎉Milestone 1,000 points. Congratulations!");
    }

    //Saves Goals and user score
    private void SaveGoals()
    {
        Console.WriteLine("What is the filename for the goal file? default: goals.txt: ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename)) filename = "goals.txt";

        using (StreamWriter sw = new StreamWriter(filename))
        {
            sw.WriteLine($"SCORE | {_score}");
            foreach (Goal g in _goals)
            {
                sw.WriteLine(g.GetDetailsRepresentation());
            }
        }
        Console.WriteLine("Your goals have been saved to {filename}");
    }

    //Load User Goals
    private void LoadGoals()
    {
        Console.WriteLine("Enter the filename to load (default: goal.txt): ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename)) filename = "goals.txt";

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found");
            return;
        }
        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();
        _score = 0;
        _level = 1;

        foreach (var line in lines)
        {
            if (line.StartsWith("SCORE|"))
            {
                var parts = line.Split('|');
                if (parts.Length > 1 && int.TryParse(parts[1], out int parsed))
                    _score = parsed;
            }
            else
            {
                var g = CreateGoalFromString(line);
                if (g != null)
                    _goals.Add(g);
            }
        }

        _level = (_score / 1000) + 1;
        Console.WriteLine($"Loaded from {filename}. Score: {_score}, Level: {_level}");
    }

    private Goal CreateGoalFromString(string line)
    {
        var parts = line.Split('|');
        string type = parts[0];
        try
        {
            if (type == "SimpleGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                bool complete = bool.Parse(parts[4]);
                return new SimpleGoal(name, description, points, complete);
            }
            else if (type == "EternalGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                return new EternalGoal(name, description, points);
            }
            else if (type == "CheckListGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                int completed = int.Parse(parts[4]);
                int target = int.Parse(parts[5]);
                int bonus = int.Parse(parts[6]);
                return new CheckListGoal(name, description, points, target, bonus, completed);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Faile to parse line: {line} ->{ex.Message}");
        }
        return null;
    }

}





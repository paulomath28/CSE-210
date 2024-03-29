using System;
using System.Collections.Generic;
using System.IO;

// Base class for all types of goals
public abstract class Goal
{
    public string Name { get; set; }
    public bool IsCompleted { get; protected set; }

    public abstract int RecordEvent();
    public abstract string GetProgress();
}

// Simple goal that can be marked complete
public class SimpleGoal : Goal
{
    public int Points { get; set; }

    public SimpleGoal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public override int RecordEvent()
    {
        IsCompleted = true;
        return Points;
    }

    public override string GetProgress()
    {
        return IsCompleted ? "[X]" : "[ ]";
    }
}

// Eternal goal that is never complete
public class EternalGoal : Goal
{
    public int Points { get; set; }

    public EternalGoal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public override int RecordEvent()
    {
        return Points;
    }

    public override string GetProgress()
    {
        return "Ongoing";
    }
}

// Checklist goal that must be accomplished a certain number of times
public class ChecklistGoal : Goal
{
    public int PointsPerCompletion { get; set; }
    public int TargetCount { get; set; }
    public int CompletionCount { get; protected set; }

    public ChecklistGoal(string name, int pointsPerCompletion, int targetCount)
    {
        Name = name;
        PointsPerCompletion = pointsPerCompletion;
        TargetCount = targetCount;
    }

    public override int RecordEvent()
    {
        CompletionCount++;
        if (CompletionCount >= TargetCount)
        {
            IsCompleted = true;
            return PointsPerCompletion * TargetCount + 500; // Bonus points on completion
        }
        else
        {
            return PointsPerCompletion;
        }
    }

    public override string GetProgress()
    {
        return $"Completed {CompletionCount}/{TargetCount} times";
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();

        bool exitProgram = false;
        while (!exitProgram)
        {
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. Record event");
            Console.WriteLine("3. Display goals");
            Console.WriteLine("4. List goals");
            Console.WriteLine("5. Save goals");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(goals);
                    break;
                case "2":
                    RecordEvent(goals);
                    break;
                case "3":
                    DisplayGoals(goals);
                    break;
                case "4":
                    ListGoals(goals);
                    break;
                case "5":
                    SaveGoals(goals);
                    break;
                case "6":
                    exitProgram = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }

    static void CreateGoal(List<Goal> goals)
    {
        Console.WriteLine("Enter goal type (1. Simple, 2. Eternal, 3. Checklist): ");
        string typeChoice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        switch (typeChoice)
        {
            case "1":
                Console.Write("Enter points for completing the goal: ");
                int points = int.Parse(Console.ReadLine());
                goals.Add(new SimpleGoal(name, points));
                Console.WriteLine("Simple goal created successfully.");
                break;
            case "2":
                Console.Write("Enter points for each event: ");
                int eternalPoints = int.Parse(Console.ReadLine());
                goals.Add(new EternalGoal(name, eternalPoints));
                Console.WriteLine("Eternal goal created successfully.");
                break;
            case "3":
                Console.Write("Enter points per completion: ");
                int pointsPerCompletion = int.Parse(Console.ReadLine());
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, pointsPerCompletion, targetCount));
                Console.WriteLine("Checklist goal created successfully.");
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    static void RecordEvent(List<Goal> goals)
    {
        Console.WriteLine("Select the goal you want to record an event for:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        Console.Write("Enter goal number: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            Goal selectedGoal = goals[goalIndex];
            int pointsEarned = selectedGoal.RecordEvent();
            Console.WriteLine($"Event recorded for {selectedGoal.Name}. Points earned: {pointsEarned}");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    static void DisplayGoals(List<Goal> goals)
    {
        Console.WriteLine("Current Goals:");
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.Name} - Progress: {goal.GetProgress()}");
        }
    }

    static void ListGoals(List<Goal> goals)
    {
        Console.WriteLine("List of Goals:");
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.Name} - Progress: {goal.GetProgress()}");
        }
    }

    static void SaveGoals(List<Goal> goals)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("Goals.txt"))
            {
                foreach (var goal in goals)
                {
                    writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.IsCompleted}");
                }
            }
            Console.WriteLine("Goals saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while saving goals: {ex.Message}");
        }
    }
}

// Each goal can have a level associated with it, and as the user
 //registers more events for that goal, they earn experience.

// When the user reaches certain levels, they can unlock special rewards.  This can be implemented by adding a level property to goals and additional logic to track the user's experience and unlock rewards.

// Example of how the functionality of negative goals can be added:

// In addition to creating goals that grant points, the user can create negative goals that subtract points when an event is logged. This can be useful to discourage unwanted habits. For example, a goal for "Smoking" could subtract points. Every time the user logs a smoking event. This can be implemented by adding an option to create negative goals and adjusting the event logging logic to handle point subtraction.

// Example of how the functionality of special rewards can be added:
// In addition to granting normal points for goal progress, the user can unlock special rewards upon reaching certain milestones or completing certain sets of goals. This could include virtual items, badges, or even discounts on real products. This can be implemented by adding logic to track important milestones and associate rewards with those milestones.

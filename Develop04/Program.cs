using System;
using System.Threading;

public abstract class Activity
{
    protected int duration; // The duration of this part is in seconds

    // This is the constructor to set the duration
    public Activity(int duration)
    {
        this.duration = duration;
    }

    // Method to display starting message 
    protected virtual void DisplayStartingMessage(string activityName, string description)
    {
        Console.WriteLine($"Starting {activityName} Activity:");
        Console.WriteLine(description);
        Console.WriteLine($"Duration: {duration} seconds\n");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    // Method to display ending message 
    protected virtual void DisplayEndingMessage(string activityName)
    {
        Console.WriteLine($"You've completed the {activityName} Activity!");
        Console.WriteLine($"Duration: {duration} seconds\n");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    // Abstract method to be implemented by derived classes
    public abstract void StartActivity();
}

// Breathing activity class
public class BreathingActivity : Activity
{
    public BreathingActivity(int duration) : base(duration) { }

    public override void StartActivity()
    {
        DisplayStartingMessage("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(1000); // Pause for 1 second
            Console.WriteLine("Breathe out...");
            Thread.Sleep(1000); // Pause for 1 second
        }

        DisplayEndingMessage("Breathing");
    }
}

// Reflection activity class
public class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base(duration) { }

    public override void StartActivity()
    {
        DisplayStartingMessage("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        Random rand = new Random();

        for (int i = 0; i < duration; i++)
        {
            string prompt = prompts[rand.Next(prompts.Length)];
            Console.WriteLine(prompt);

            foreach (string question in questions)
            {
                Console.WriteLine(question);
                Thread.Sleep(2000); // Pause for 2 seconds
            }
        }

        DisplayEndingMessage("Reflection");
    }
}

// Listing activity class
public class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base(duration) { }

    public override void StartActivity()
    {
        DisplayStartingMessage("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine(prompt);

        Console.WriteLine("Start listing...");

        // Here is simulating user input to simulate items
        for (int i = 0; i < duration; i++)
        {
            Thread.Sleep(1000); // Pause for 1 second
            Console.WriteLine("Item " + (i + 1));
        }

        Console.WriteLine($"Total items listed: {duration}\n");

        DisplayEndingMessage("Listing");
    }
}

// This is the main class of the program
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program!\n");

        // Menu system
        Console.WriteLine("Choose an activity:");
        Console.WriteLine("1. Breathing");
        Console.WriteLine("2. Reflection");
        Console.WriteLine("3. Listing");

        int choice;
        while (true)
        {
            Console.Write("Enter your choice (1-3): ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice >= 1 && choice <= 3)
                    break;
            }
            Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
        }

        Console.Write("Enter duration (in seconds): ");
        int duration = int.Parse(Console.ReadLine());

        // Based on user choice, start the respective activity
        Activity activity;
        switch (choice)
        {
            case 1:
                activity = new BreathingActivity(duration);
                break;
            case 2:
                activity = new ReflectionActivity(duration);
                break;
            case 3:
                activity = new ListingActivity(duration);
                break;
            default:
                activity = null;
                break;
        }

        // Start the activity
        if (activity != null)
        {
            activity.StartActivity();
        }
        else
        {
            Console.WriteLine("Invalid activity choice.");
        }
    }
}


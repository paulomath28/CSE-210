using System;

class Program
{
    For static void Main(string[] args)
    {
        // Step 1: Ask the user for the magic number.
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        int guess = -1;

        // Step 2: Add a loop that keeps looping as long as the guess does not match the magic number.
        while (guess != magicNumber)
        {
            // Step 2: Ask the user for a guess.
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            // Step 3: Using an if statement, determine if the user needs to guess higher or lower next time, or tell them if they guessed it.
            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}

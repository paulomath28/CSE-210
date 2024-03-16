using System;
using System.Collections.Generic;
using System.Linq;

public class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public override string ToString()
    {
        return IsHidden ? "_ _ _" : Text;
    }
}

public class Reference
{
    public string Text { get; }

    public Reference(string text)
    {
        Text = text;
    }

    public override string ToString()
    {
        return Text;
    }
}

public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;

    public bool AllWordsHidden => _words.All(word => word.IsHidden);

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(_reference);
        foreach (var word in _words)
        {
            Console.Write(word + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        List<Word> nonHiddenWords = _words.Where(word => !word.IsHidden).ToList();
        for (int i = 0; i < count; i++)
        {
            if (nonHiddenWords.Count == 0) // Ensure we have non-hidden words to hide
                break;

            int index = random.Next(nonHiddenWords.Count);
            nonHiddenWords[index].Hide();
            nonHiddenWords.RemoveAt(index);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a scripture
        Reference reference = new Reference("John 3:16");
        string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        Scripture scripture = new Scripture(reference, text);

        // Display the complete scripture
        scripture.Display();

        // Memorization process
        while (!scripture.AllWordsHidden)
        {
            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit:");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            // Clear the console
            Console.Clear();

            // Hide a few random words
            scripture.HideRandomWords(2);

            // Display the scripture with hidden words
            scripture.Display();
        }

        Console.WriteLine("End of memorization process.");
    }
}

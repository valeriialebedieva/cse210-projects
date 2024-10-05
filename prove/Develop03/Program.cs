using System;
using System.Collections.Generic;


//Randomly selected only those words that are not already hidden.
class Program
{
    static void Main(string[] args)
    {
        List<(string reference, string text)> scriptures = new List<(string, string)>()
        {
            ("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            ("Proverbs 3:5-6", "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.")
        };

        Random random = new Random();
        int randomIndex = random.Next(scriptures.Count);
        var selectedScripture = scriptures[randomIndex];

        Reference reference = ParseReference(selectedScripture.reference);
        Scripture scripture = new Scripture(reference, selectedScripture.text);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine("All words are hidden. Program finished.");
    }

    static Reference ParseReference(string referenceText)
    {
        Reference reference;

        if (referenceText.Contains("-"))
        {
            string[] refParts = referenceText.Split(new[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (refParts.Length == 4)
            {
                string book = refParts[0];
                int chapter = int.Parse(refParts[1]);
                int startVerse = int.Parse(refParts[2]);
                int endVerse = int.Parse(refParts[3]);
                reference = new Reference(book, chapter, startVerse, endVerse);
            }
            else
            {
                throw new Exception("Scripture format for range is invalid.");
            }
        }
        else
        {
            string[] refParts = referenceText.Split(new[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (refParts.Length == 3)
            {
                string book = refParts[0];
                int chapter = int.Parse(refParts[1]);
                int verse = int.Parse(refParts[2]);
                reference = new Reference(book, chapter, verse);
            }
            else
            {
                throw new Exception("Scripture format for single verse is invalid.");
            }
        }

        return reference;
    }
}

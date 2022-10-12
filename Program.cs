// Spell Check Starter
// This start code creates two lists
// 1: dictionary: an array containing all of the words from "dictionary.txt"
// 2: aliceWords: an array containing all of the words from "AliceInWonderland.txt"

using System;
using System.Text.RegularExpressions;
using System.Diagnostics;
#nullable disable

class Program
{
    public static void Main(string[] args)
    {
        // Load data files into arrays
        String[] dictionary = System.IO.File.ReadAllLines(@"data-files/dictionary.txt");
        String aliceText = System.IO.File.ReadAllText(@"data-files/AliceInWonderLand.txt");
        String[] aliceWords = Regex.Split(aliceText, @"\s+");
        Stopwatch timer = new Stopwatch();

        // Print first 50 values of each list to verify contents
        // actual program
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"MAIN MENU");
            Console.WriteLine("    1. Spell Check a Word (Linear Search)");
            Console.WriteLine("    2. Spell Check a Word (Binary Search)");
            Console.WriteLine("    3. Spell Check Alice In Wonderland (Linear Search)");
            Console.WriteLine("    4. Spell Check Alice In Wonderland (Binary Search)");
            Console.WriteLine("    5. Exit");
            Console.Write("-> ");
            int mainMenuChoice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if (mainMenuChoice == 1)
            {
                Console.WriteLine("SPELL CHECK A WORD (LINEAR SEARCH)");
                Console.Write("Please enter a word: ");
                string sortWord = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Searching...");
                timer.Start();
                int pos = linearSearch(dictionary, sortWord);
                timer.Stop();
                TimeSpan timeElapsed = timer.Elapsed;
                Console.Clear();
                if (pos != -1)
                {
                    Console.WriteLine(
                        $"'{sortWord}' is IN the dictionary at line #{pos}. ({timeElapsed} seconds)"
                    );
                }
                else
                {
                    Console.WriteLine(
                        $"'{sortWord}' is NOT in the dictionary. ({timeElapsed} seconds)"
                    );
                }
                ;
            }
            if (mainMenuChoice == 2)
            {
                Console.WriteLine("SPELL CHECK A WORD (BINARY SEARCH)");
                string sortWord = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Searching...");
                timer.Start();
                int pos = binarySearch(dictionary, sortWord);
                timer.Stop();
                TimeSpan timeElapsed = timer.Elapsed;
                Console.Clear();
                if (pos != -1)
                {
                    Console.WriteLine(
                        $"'{sortWord}' is IN the dictionary at line #{pos}. ({timeElapsed} seconds)"
                    );
                }
                else
                {
                    Console.WriteLine(
                        $"'{sortWord}' is NOT in the dictionary. ({timeElapsed} seconds)"
                    );
                }
                ;
            }
            if (mainMenuChoice == 3)
            {
                Console.WriteLine("SPELL CHECK A WORD (LINEAR SEARCH)");
                Console.WriteLine("Checking...");
                timer.Start();
                int count = 0;
                for (int i = 0; i < aliceWords.Length; i++)
                {
                    int pos = linearSearch(dictionary, aliceWords[i].ToLower());
                    if (pos == -1)
                    {
                        count++;
                    }
                }
                timer.Stop();
                TimeSpan timeElapsed = timer.Elapsed;
                Console.Clear();
                if (count == 0)
                {
                    Console.WriteLine($"All words seem good! ({timeElapsed})");
                }
                else
                {
                    Console.WriteLine(
                        $"Number of words not found in dictionary: {count} ({timeElapsed})"
                    );
                }
                ;
            }
            if (mainMenuChoice == 4)
            {
                Console.WriteLine("SPELL CHECK A WORD (BINARY SEARCH)");
                Console.WriteLine("Checking...");
                timer.Start();
                int count = 0;
                for (int i = 0; i < aliceWords.Length; i++)
                {
                    int pos = binarySearch(dictionary, aliceWords[i].ToLower());
                    if (pos == -1)
                    {
                        count++;
                    }
                }
                timer.Stop();
                TimeSpan timeElapsed = timer.Elapsed;
                Console.Clear();
                if (count == 0)
                {
                    Console.WriteLine($"All words seem good! ({timeElapsed})");
                }
                else
                {
                    Console.WriteLine(
                        $"Number of words not found in dictionary: {count} ({timeElapsed})"
                    );
                }
                ;
            }
            if (mainMenuChoice == 5)
            {
                Console.Clear();
                break;
            }
            Console.WriteLine("");
            Console.WriteLine("Back to Main Menu?");
            Console.Write("-> ");
            Console.ReadLine();
        }
    }

    public static void printStringArray(String[] array, int start, int stop)
    {
        // Print out array elements at index values from start to stop
        for (int i = start; i < stop; i++)
        {
            Console.WriteLine(array[i]);
        }
    }

    // Search an array for an item using the linear search algorithm.
    // If item found, return index where found, else return -1.
    // string linear search
    public static int linearSearch(string[] anArray, string item)
    {
        for (int i = 0; i < anArray.Length; i++)
        {
            if (anArray[i] == item)
            {
                return i;
            }
        }

        // Went through for loop without finding item, so...
        return -1;
    }

    // Search a SORTED array for an item using the binary search algorithm.
    // If item found, return index where found, else return -1.
    public static int binarySearch(string[] anArray, string item)
    {
        int lowerIndex = 0;
        int upperIndex = anArray.Length - 1;

        while (upperIndex >= lowerIndex)
        {
            int middleIndex = (upperIndex + lowerIndex) / 2;
            if (anArray[middleIndex] == item)
            {
                return middleIndex;
            }
            else if (-1 == String.Compare(item, anArray[middleIndex]))
            {
                upperIndex = middleIndex - 1;
            }
            else
            { // item > than the value at the middle index
                lowerIndex = middleIndex + 1;
            }
        }

        // Went through loop without finding item, so...
        return -1;
    }
}

using System;
using System.Collections.Generic;

namespace hangman
{
    class Program
    {

        static string wordToGuess;
        static string guessedWord;
        static List<char> guesses = new List<char>();
        static int guessesLeft = 5;

        static void Main(string[] args)
        {
            
            char guess = 'r';
            string word = "Sommar";
            Console.WriteLine();
            GuessCompare(guess, word);

            wordToGuess = "Sommar".ToUpper();
            guessedWord = "------";
            RunGame();
        }


        static void RunGame()
        {
            while (guessedWord != wordToGuess && guessesLeft > 0)
            {
                DisplayHangmanGame();
                string input = Console.ReadLine().ToUpper();
                char guess = input[0];


        static void RunGame()
        {
            while (guessedWord != wordToGuess && guessesLeft > 0)
            {
                DisplayHangmanGame();
                string input = Console.ReadLine().ToUpper();
                char guess = input[0];

                if (false) //!ValidInput(input))
                {
                    WriteMessage("Invalid guess", false);
                }
                else if (guesses.Contains(guess))
                {
                    WriteMessage($"You have already guessed '{guess}'", false);
                }
                else
                {
                    guesses.Add(guess);

                    if (wordToGuess.Contains(guess))
                    {
                        WriteMessage("Correct", true);
                        // Update guessedWord
                    }
                    else
                    {
                        WriteMessage("Wrong", false);
                        guessesLeft--;
                    }
                }

                if (guessesLeft > 0)
                {
                    // Wait for user to press any key
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }

            DisplayHangmanGame();
            if (guessesLeft == 0)
            {
                WriteMessage("You lost!", false);
            }
            else
            {
                WriteMessage("You won!", true);
            }
        }


        static void GuessCompare(char guess, string word)
        {
            bool correctGuess = false;
            for (int i = 0; i < word.Length; i++)
            {
                if (guess == word[i])
                {
                    Console.WriteLine(guess);
                    correctGuess = true;
                }

            }
            if (correctGuess == false)
            {
                Console.WriteLine("Not a correct guess");
            }
            else if (correctGuess)
            {
                Console.WriteLine("Correct");
            }
        }


        static void DisplayHangmanGame()
        {
            Console.Clear();
            Console.WriteLine();
            DrawHangman(5 - guessesLeft);
            Console.WriteLine();
            Console.WriteLine($" M--RITZ");
            Console.WriteLine();
            Console.WriteLine($" A S I K B");
            Console.WriteLine();
            Console.WriteLine($" Guesses left: 6");
            if (guessesLeft > 0)
            {
                Console.WriteLine();
                Console.Write($" Your guess: ");
            }
        }

        static void WriteMessage(string message, bool isGood)
        {
            Console.WriteLine();
            if (isGood)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" " + message);
            Console.ResetColor();
        }

        static void DrawHangman(int numberOfInvalidGuesses)
        {
            switch (numberOfInvalidGuesses)
            {
                case 0:
                    Console.WriteLine("   +---+");
                    Console.WriteLine("   |   |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine(" =========");
                    break;
                case 1:
                    Console.WriteLine("   +---+");
                    Console.WriteLine("   |   |");
                    Console.WriteLine("   O   |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine(" =========");
                    break;
                case 2:
                    Console.WriteLine("   +---+");
                    Console.WriteLine("   |   |");
                    Console.WriteLine("   O   |");
                    Console.WriteLine("   |   |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine(" =========");
                    break;
                case 3:
                    Console.WriteLine("   +---+");
                    Console.WriteLine("   |   |");
                    Console.WriteLine("   O   |");
                    Console.WriteLine("  /|   |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine(" =========");
                    break;
                case 4:
                    Console.WriteLine("   +---+");
                    Console.WriteLine("   |   |");
                    Console.WriteLine("   O   |");
                    Console.WriteLine("  /|\\  |");
                    Console.WriteLine("  /    |");
                    Console.WriteLine("       |");
                    Console.WriteLine(" =========");
                    break;
                case 5:
                    Console.WriteLine("   +---+");
                    Console.WriteLine("   |   |");
                    Console.WriteLine("   O   |");
                    Console.WriteLine("  /|\\  |");
                    Console.WriteLine("  / \\  |");
                    Console.WriteLine("       |");
                    Console.WriteLine(" =========");
                    break;
            }
        }
    }

}

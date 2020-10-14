using Hangman.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.App
{
    class Program
    {

        static string wordToGuess;
        static StringBuilder guessedWord = new StringBuilder();
        static List<char> guesses = new List<char>(); // todo: tips "Hash<char>"
        static int guessesLeft = 6;

        /* todo: större
          
           Separera GUI med spelmotorn 
          
           Hangman - motorn (innehåller ingen gui)

           Gui

           var h = new Hangman()
           h.Run();
          
         */
        static void Main(string[] args)
        {
            string word = GenerateRandomWord.RandomWord();
            Console.WriteLine("Word: " + word);

            // Wait for user to press any key
            Console.WriteLine("\nPress any key to start the game...");
            Console.ReadKey();

            wordToGuess = word.ToUpper();
            guessedWord.Append('-', wordToGuess.Length);

            var hangman = new Core.Hangman(wordToGuess, guessesLeft);

            RunGame(hangman);
        }

        // todo: går det att extrahera metoder ur denna?
        // todo: metoder 1-7 långa
        // todo: metoderna ska beskriva sig själva
        static void RunGame(Core.Hangman hangman)
        {

            while (guessedWord.ToString() != wordToGuess && guessesLeft > 0) // todo: ev metod
            {
                DisplayHangmanGame(hangman);
                string input = GetGuessFromUser();

                GuessResult result = hangman.Guess(input);

                switch (result)
                {
                    case GuessResult.AlreadyGuessed:
                        DisplayIncorrectMessage($"You have already guessed '{input}'");
                        break;
                    case GuessResult.CorrectGuess:
                        DisplayCorrectMessage("Correct");
                        break;
                    case GuessResult.IncorrectGuess:
                        DisplayIncorrectMessage("Wrong");
                        break;
                    case GuessResult.InvalidGuess:
                        DisplayIncorrectMessage("Invalid guess");
                        break;
                }

                WaitForUserToContinue();
            }

            DisplayHangmanGame(hangman);
            EndGame();
        }


        static string GetGuessFromUser()
        {
            // Ask user to enter a guess
            Console.WriteLine();
            Console.Write($" Your guess: ");
            return Console.ReadLine().ToUpper();
        }

        static bool ValidInput(string input)
        {
            if (input.Length < 1 || input.Length > 1)
            {
                return false;
            }
            if (ValidateInputChar.IsInputOk(input[0]))
            {
                return true;
            }
            return false;
        }

        static void WaitForUserToContinue()
        {
            if (guessesLeft > 0)
            {
                // Wait for user to press any key
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void AddCorrectGuess(char guess)
        {
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (guess == wordToGuess[i])
                {
                    guessedWord[i] = guess;
                }
            }
        }

        static void DisplayHangmanGame(Core.Hangman hangman)
        {
            // Clear console
            Console.Clear();
            Console.WriteLine();

            // Draw hangman
            int guessesLeft = hangman.GuessesLeft();
            DrawHangman(6 - guessesLeft);
            Console.WriteLine();

            // Write word with placeholders
            Console.WriteLine(" " + hangman.GetGuessedWord());
            Console.WriteLine();

            // Write guessed characters
            foreach (char c in hangman.GetGuesses())
            {
                Console.Write($" {c}");
            }
            Console.WriteLine();
            Console.WriteLine();

            // Write number of guesses remaining
            Console.WriteLine($" Guesses left: {guessesLeft}");
        }

        static void EndGame()
        {
            if (guessesLeft == 0)
                DisplayIncorrectMessage("You lost!");
            else
                DisplayCorrectMessage("You won!");
        }

        static void DisplayCorrectMessage(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" " + message);
            Console.ResetColor();
            Console.WriteLine();
            //Console.Beep(500, 200);
            //Console.Beep(800, 400);
        }

        static void DisplayIncorrectMessage(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" " + message);
            Console.ResetColor();
            Console.WriteLine();
            //Console.Beep(800, 200);
            //Console.Beep(500, 400);
        }

        static void DrawHangman(int numberOfInvalidGuesses)
        {
            switch (numberOfInvalidGuesses)
            {
                case 0:
                    Console.WriteLine("   +---+");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine(" =========");
                    break;
                case 1:
                    Console.WriteLine("   +---+");
                    Console.WriteLine("   |   |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine(" =========");
                    break;
                case 2:
                    Console.WriteLine("   +---+");
                    Console.WriteLine("   |   |");
                    Console.WriteLine("   O   |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine(" =========");
                    break;
                case 3:
                    Console.WriteLine("   +---+");
                    Console.WriteLine("   |   |");
                    Console.WriteLine("   O   |");
                    Console.WriteLine("   |   |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine(" =========");
                    break;
                case 4:
                    Console.WriteLine("   +---+");
                    Console.WriteLine("   |   |");
                    Console.WriteLine("   O   |");
                    Console.WriteLine("  /|   |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine(" =========");
                    break;
                case 5:
                    Console.WriteLine("   +---+");
                    Console.WriteLine("   |   |");
                    Console.WriteLine("   O   |");
                    Console.WriteLine("  /|\\  |");
                    Console.WriteLine("  /    |");
                    Console.WriteLine("       |");
                    Console.WriteLine(" =========");
                    break;
                case 6:
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

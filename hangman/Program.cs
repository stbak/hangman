using Hangman.Core;
using System;
using System.Collections.Generic;

namespace Hangman.App
{
    class Program
    {

        static readonly private int numberOfGuesses = 6;

        static void Main(string[] args)
        {
            // OO: Move this try-catch-block to "Main" or don't use try-catch at all
            try
            {
                // Display splash screen
                SplashScreen.Run();

                // Wait for user to press any key
                Console.WriteLine("\nPress any key to start the game...");
                Console.ReadKey();

                string playAgain;
                do
                {
                    RunGame();

                    // Ask if user wants to play again
                    Console.Write("Do you want to play again (Y/N)? ");
                    playAgain = Console.ReadLine().ToUpper();
                } while (playAgain == "Y");
            }
            catch (Exception)
            {
                Console.WriteLine("\nError: An error occured when trying to run the game.");
                return;
            }
        }

        // todo: går det att extrahera metoder ur denna?
        // todo: metoder 1-7 långa
        // todo: metoderna ska beskriva sig själva
        // OO: This method starts to look really nice :)
        static private void RunGame()
        {
            string wordToGuess = GenerateRandomWord.RandomWord();

            Console.WriteLine("\nHint: " + wordToGuess); // Hint during development
            WaitForUserToContinue();

            // Create an instanse of Hangman, catch any exception
            Core.Hangman hangman = new Core.Hangman(wordToGuess, numberOfGuesses);

            while (!hangman.GameEnded())
            {
                DisplayHangmanGame(hangman);
                string input = GetGuessFromUser();

                GuessResult result = hangman.Guess(input);

                switch (result)
                {
                    case GuessResult.AlreadyGuessed:
                        DisplayIncorrectMessage($"You have already guessed '{input.ToUpper()}'");
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

                if (!hangman.GameEnded())
                    WaitForUserToContinue();
            }

            DisplayHangmanGame(hangman);
            if (hangman.GuessesLeft == 0)
                DisplayIncorrectMessage("You lost!");
            else
                DisplayCorrectMessage("You won!");
        }


        static private string GetGuessFromUser()
        {
            // Ask user to enter a guess
            Console.WriteLine();
            Console.Write($" Your guess: ");
            return Console.ReadLine();
        }

        static private void WaitForUserToContinue()
        {
            // Wait for user to press any key
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static private void DisplayHangmanGame(Core.Hangman hangman)
        {
            // Clear console
            Console.Clear();
            Console.WriteLine();

            // Draw hangman
            DrawHangman(numberOfGuesses - hangman.GuessesLeft);
            Console.WriteLine();

            // Write word with placeholders
            Console.WriteLine(" " + hangman.MaskedWordWithCorrectGuesses);
            Console.WriteLine();

            // Write guessed characters
            foreach (char c in hangman.GuessedCharacters)
            {
                Console.Write($" {c}");
            }
            Console.WriteLine();
            Console.WriteLine();

            // Write number of guesses remaining
            Console.WriteLine($" Guesses left: {hangman.GuessesLeft}");
        }

        static private void DisplayCorrectMessage(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" " + message);
            Console.ResetColor();
            Console.WriteLine();
            //Console.Beep(500, 200);
            //Console.Beep(800, 400);
        }

        static private void DisplayIncorrectMessage(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" " + message);
            Console.ResetColor();
            Console.WriteLine();
            Console.Beep();
            //Console.Beep(800, 200);
            //Console.Beep(500, 400);
        }

        static private void DrawHangman(int numberOfInvalidGuesses)
        {
            var hangmanImage = HangmanImage(numberOfInvalidGuesses);

            foreach (var row in hangmanImage)
            {
                Console.WriteLine(" " + row);
            }
        }

        private static string[] HangmanImage(int numberOfInvalidGuesses)
        {
            var hangmanImages = new List<string[]>()
            {
                new[]
                {
                    "  +---+  ",
                    "  |   |  ",
                    "      |  ",
                    "      |  ",
                    "      |  ",
                    "      |  ",
                    "========="
                },
                new[]
                {
                    "  +---+  ",
                    "  |   |  ",
                    "  O   |  ",
                    "      |  ",
                    "      |  ",
                    "      |  ",
                    "========="
                },
                new[]
                {
                    "  +---+  ",
                    "  |   |  ",
                    "  O   |  ",
                    "  |   |  ",
                    "      |  ",
                    "      |  ",
                    "========="
                },
                new[]
                {
                    "  +---+  ",
                    "  |   |  ",
                    "  O   |  ",
                    " /|   |  ",
                    "      |  ",
                    "      |  ",
                    "========="
                },
                new[]
                {
                    "  +---+  ",
                    "  |   |  ",
                    "  O   |  ",
                    " /|\\  |  ",
                    "      |  ",
                    "      |  ",
                    "========="
                },
                new[]
                {
                    "  +---+  ",
                    "  |   |  ",
                    "  O   |  ",
                    " /|\\  |  ",
                    " /    |  ",
                    "      |  ",
                    "========="
                },
                new[]
                {
                    "  +---+  ",
                    "  |   |  ",
                    "  O   |  ",
                    " /|\\  |  ",
                    " / \\  |  ",
                    "      |  ",
                    "========="
                }
            };

            return hangmanImages[numberOfInvalidGuesses];
        }
    }

}

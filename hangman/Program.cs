using Hangman.Core;
using System;

namespace Hangman.App
{
    class Program
    {

        static readonly private int numberOfGuesses = 6;

        /* todo: större
          
           Separera GUI med spelmotorn 
          
           Hangman - motorn (innehåller ingen gui)

           Gui

           var h = new Hangman()
           h.Run();
          
           
        - Splash screen (Stefan) Klart
        - Play again? Klart
        - Städa Hangman.App (Björn) Klart
        - Skriva test cases (Maja)
        - Snygga till Guess() (Björn) Klart
        - Hantera Retur från user (Björn) Klart
        - Se över namngivning
        - Ta bort ValidateInputChar.cs (Björn) Klart

         */
        static void Main(string[] args)
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

        // todo: går det att extrahera metoder ur denna?
        // todo: metoder 1-7 långa
        // todo: metoderna ska beskriva sig själva
        static private void RunGame()
        {
            string wordToGuess = GenerateRandomWord.RandomWord();

            Console.WriteLine("\nHint: " + wordToGuess); // Hint during development
            WaitForUserToContinue();

            // Create an instanse of Hangman, catch any exception
            Core.Hangman hangman;
            try
            {
                hangman = new Core.Hangman(wordToGuess, numberOfGuesses);
            }
            catch (Exception)
            {
                Console.WriteLine("\nError: An error occured when trying to start the game.");
                return;
            }

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
            Console.WriteLine(" " + hangman.GuessedWord);
            Console.WriteLine();

            // Write guessed characters
            foreach (char c in hangman.Guesses)
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
            //Console.Beep(800, 200);
            //Console.Beep(500, 400);
        }

        static private void DrawHangman(int numberOfInvalidGuesses)
        {

            //Comment Group4: Perhaps you could create an array or list of string that you feed with the first picture and then just replace current position
            //BUt it's easier to understand when you do like below :) 
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

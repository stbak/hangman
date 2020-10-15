using Hangman.Core;
using System;

namespace Hangman.App
{
    class Program
    {

        static private int numberOfGuesses = 6;

        /* todo: större
          
           Separera GUI med spelmotorn 
          
           Hangman - motorn (innehåller ingen gui)

           Gui

           var h = new Hangman()
           h.Run();
          
           
        - Splash screen (Stefan)
        - Play again?
        - Städa Hangman.App (Björn) Klart
        - Skriva test cases (Maja)
        - Snygga till Guess() (Björn)
        - Hantera Retur från user (Björn) Klart
        - Se över namngivning
        - Ta bort ValidateInputChar.cs (Björn) Klart

         */
        static void Main(string[] args)
        {
            SplashScreen.Run();
            
            string wordToGuess = GenerateRandomWord.RandomWord();
            Console.WriteLine("Word: " + wordToGuess);

            // Wait for user to press any key
            Console.WriteLine("\nPress any key to start the game...");
            Console.ReadKey();

            var hangman = new Core.Hangman(wordToGuess, numberOfGuesses);

            RunGame(hangman);
        }

        // todo: går det att extrahera metoder ur denna?
        // todo: metoder 1-7 långa
        // todo: metoderna ska beskriva sig själva
        static private void RunGame(Core.Hangman hangman)
        {

            while (!hangman.GameEnded())
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

                if (!hangman.GameEnded())
                    WaitForUserToContinue();
            }

            DisplayHangmanGame(hangman);
            if (hangman.GetGuessesLeft() == 0)
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
            int guessesLeft = hangman.GetGuessesLeft();
            DrawHangman(numberOfGuesses - hangman.GetGuessesLeft());
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

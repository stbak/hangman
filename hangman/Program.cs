/*
 
Todo:

- Validera: flera tecken eller ett konstigt tecken
- Uppdatera guessedword
- "ttt"-buggen
- Räkna inte ner om användaren gissar konstigt tecken

 
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace hangman
{
    class Program
    {

        static string wordToGuess;
        static StringBuilder guessedWord = new StringBuilder();
        static List<char> guesses = new List<char>();
        static int guessesLeft = 6;

        static void Main(string[] args)
        {
            
             string word = GenerateRandomWord.RandomWord();
            Console.WriteLine("Word: " + word);
            

       
            // Wait for user to press any key
            Console.WriteLine("\nPress any key to start the game...");
            Console.ReadKey();

            wordToGuess = word.ToUpper();
            guessedWord.Append('-', wordToGuess.Length);
            RunGame();
        }

        // todo: går det att extrahera metoder ur denna?
        static void RunGame()
        {
            while (guessedWord.ToString() != wordToGuess && guessesLeft > 0)
            {
                DisplayHangmanGame();
                string input = Console.ReadLine().ToUpper();
                char guess = input[0];

                
                if (input.Length > 1) //!ValidInput(input)
                {
                    DisplayIncorrectMessage("Invalid guess");
                }
                else if (guesses.Contains(guess))
                {
                    DisplayIncorrectMessage($"You have already guessed '{guess}'");
                }
                else
                {
                    if (ValidateInputChar.IsInputOk(guess))
                    {
                        // Add guess to guesses
                        guesses.Add(guess);

                   
                        if (wordToGuess.Contains(guess))
                        {
                            DisplayCorrectMessage("Correct");
                         AddCorrectGuess(guess);
                        }
                        else
                        {
                            DisplayIncorrectMessage("Wrong");
                            guessesLeft--;
                        }
                    }
                    else 
                    {
                        DisplayIncorrectMessage("Invalid guess");
                        guessesLeft--;
                    }
                    
                }

                if (guessesLeft > 0)
                {
                    // Wait for user to press any key
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

                DisplayHangmanGame();
                if (guessesLeft == 0)
                    DisplayIncorrectMessage("You lost!");
                else
                    DisplayCorrectMessage("You won!");
            }
        }


        // todo: metoder 1-7 långa
        // todo: metoderna ska beskriva sig själva
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

      

        static void DisplayHangmanGame()
        {
            // Clear console
            Console.Clear();
            Console.WriteLine();

            // Draw hangman
            DrawHangman(6 - guessesLeft);
            Console.WriteLine();

            // Write word with placeholders
            Console.WriteLine(" " + guessedWord);
            Console.WriteLine();

            // Write guessed characters
            foreach (char c in guesses)
            {
                Console.Write($" {c}");
            }
            Console.WriteLine();
            Console.WriteLine();

            // Write number of guesses remaining
            Console.WriteLine($" Guesses left: {guessesLeft}");

            if (guessesLeft > 0)
            {
                // Ask user to enter a guess
                Console.WriteLine();
                Console.Write($" Your guess: ");
            }
        }

        static void DisplayCorrectMessage(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" " + message);
            Console.ResetColor();
        }

        static void DisplayIncorrectMessage(string message)
        {
            Console.WriteLine();
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


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
           
            wordToGuess = word.ToUpper();
            guessedWord.Append("------");
            
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

                if (false) //!ValidInput(input)
                {
                    WriteMessage("Invalid guess", false);
                }
                else if (guesses.Contains(guess))
                {
                    WriteMessage($"You have already guessed '{guess}'", false);
                }
                else
                {
                    // Add guess to guesses
                    guesses.Add(guess);

                    if (wordToGuess.Contains(guess))
                    {
                        WriteMessage("Correct", true);
                        AddCorrectGuess(guess);
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
            

            //wordToGuess = "Sommar".ToUpper();
           
            //RunGame();
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
            //Console.Clear();
            Console.WriteLine();

            DrawHangman(6 - guessesLeft);

            Console.WriteLine();
            Console.WriteLine(" " + guessedWord);
            Console.WriteLine();
            foreach (char c in guesses)
            {
                Console.Write($" {c}");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($" Guesses left: {guessesLeft}");

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


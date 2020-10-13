using System;

namespace hangman
{
    class Program
    {

        static char[] guesses = new char[10];
        static char[] outputWord;
        static char guess;
        static string guessedChars;
        static void Main(string[] args)
        {
            string word = GenerateRandomWord.RandomWord();
            Console.WriteLine("Word: " + word);
            
            
            do
            {
                Console.Write("Guess a character: ");
                guess = (char)Console.Read();
                if (validateInput(guess, guesses) == true)
                {
                    break;
                }
                else {
                    Console.WriteLine("This is not a valid guess, try again: ");
                    
                }
            } while (true);

    {

            }
            Console.WriteLine(validateInput(guess, guesses)); //just writes out true or false
            Console.WriteLine(guessedChars.Length);
            foreach (char c in guessedChars) {
                Console.Write(c + " ");
            }
            GuessCompare(guess, word);
            WriteHangman();
        }


        static Boolean validateInput(char guess, char[] guesses) {

            
            bool valid = false;
            char[] allowedCharacters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'Å', 'Ä', 'Ö', 'a', 'b', 'c', 'd' , 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'å', 'ä', 'ö' };
            foreach (char c in allowedCharacters) {

                if (guess == c)
                {
                    valid = true;
                    guessedChars = guessedChars + c;
                }
                else {
                    Console.WriteLine($"You have already guessed on {guess}, try again:");
                }
                
            }

            if (valid == true) { 
                
            }
            return valid;
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


        static void WriteHangman()
        {
            //Console.Clear();
            Console.WriteLine();
            DrawHangman(1);
            Console.WriteLine();
            Console.WriteLine($" MAURITZ");
            Console.WriteLine();
            Console.WriteLine($" A S I K B");
            Console.WriteLine();
            Console.WriteLine($" Guesses left: 6");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" You won!");
            Console.ResetColor();
        }

        static void DrawHangman(int image)
        {
            switch (image)
            {
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


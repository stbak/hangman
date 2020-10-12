using System;

namespace hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            char guess = 'o';
            string word = "Sommar";
            Console.WriteLine();
            GuessCompare(guess, word);
        }



        static void GuessCompare(char guess, string word){
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
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace hangman
{
    class TheHangmanWord
    {

        public static void Run() {
            string theWord = "hörlurar";
            string[] allowedCharacters = { "a, b, c, d , e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z, å, ä, ö" };
            string guess;
            Console.SetCursorPosition(10, 5);
            Console.Write("Welcome to the Hangman game, please enter your guess: ");
            guess = Console.ReadLine();

            if (Input(guess, allowedCharacters)) {
                Console.WriteLine($"{guess} is a valid guess");
            }


            

            foreach (char c in theWord) {
                Console.Write("_ ");
            }
        }

        static Boolean Input(string str, string[] strChars) {
            bool validCharacter = false;
            if (str.Length > 1)
            {
                Console.WriteLine($"Invalid input, {str} is not a char!");
            }
            else if (str.Length == 1) { //this is a vaild length of the input

                for (int i = 0; i < strChars.Length; i++) {
                    if (str == strChars[i]) {
                        validCharacter = true;
                        break;
                    }
                }
            
            }

            return validCharacter;
        }

}
}

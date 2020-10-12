using System;

namespace hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            
            PrintTheHill();

            string test = "abcdefgh";

            TheHangmanWord.Run();
        }

        static void PrintTheHill() {
            Console.WriteLine("Width: " + Console.WindowWidth.ToString() + ", height: " + Console.WindowHeight.ToString()
                );
        }
    }
}

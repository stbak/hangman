using System;

namespace hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteHangman();
        }

        static void WriteHangman()
        {
            Console.Clear();
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

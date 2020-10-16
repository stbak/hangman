using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.App
{
    public class SplashScreen
    {
        public static void Run()
        {
            DisplayGraphics();
        }

        // OO: Nice :)
        private static int GetStartingPoint(string str)
        {
            int windowWidth = Console.WindowWidth;
            int strLen = str.Length;
            return (windowWidth / 2) - (strLen / 2);
        }

        private static void DisplayGraphics()
        {

            var graphics = new [] { 
                "XX   XX    XXX    X    XX    XXX    XX   XX    XXX    X    XX",
                "XX   XX   XX XX   XX   XX   XX XX   XXX XXX   XX XX   XX   XX",
                "XX   XX  XX   XX  XXX  XX  XX       XX X XX  XX   XX  XXX  XX",
                "XXXXXXX  XXXXXXX  XX X XX  XX  XXX  XX X XX  XXXXXXX  XX X XX",
                "XX   XX  XX   XX  XX  XXX  XX   XX  XX   XX  XX   XX  XX  XXX",
                "XX   XX  XX   XX  XX   XX   XX XX   XX   XX  XX   XX  XX   XX",
                "XX   XX  XX   XX  XX    X    XXX    XX   XX  XX   XX  XX    X",
                "_____________________________________________________________",
                "",
                "                         __________",
                "                         |      \\ |",
                "                         O       \\|",
                "                        /|\\       |",
                "                         |        |",
                "                        / \\       |",
                "                       /   \\      |",
                "                                  |",
                "                                  |",
                "                            =============",
                "                          ================="
            };

            //int startAt = GetStartingPoint(graphics[0]); //This will center everything on SplashScreen!
            string spaces = new string(' ', GetStartingPoint(graphics[0]) - 1);


            //Output
            Console.SetCursorPosition(0, 3);
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (string s in graphics)
            {
                Console.WriteLine(spaces + s);
            }
            Console.ResetColor();

        }




    }
}

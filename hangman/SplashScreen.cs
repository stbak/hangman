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
            int startAt = GetStartingPoint("XX   XX    XXX    X    XX    XXX    XX   XX    XXX    X    XX"); //This will center everything on SplashScreen!
            string emptyStr = new string(' ', startAt-1);
            DisplayGraphics(emptyStr);
        }

        // OO: Nice :)
        private static int GetStartingPoint(string str)
        {
            int windowWidth = Console.WindowWidth;
            int strLen = str.Length;
            return (windowWidth / 2) - (strLen / 2);
        }

        private static void DisplayGraphics(string spaces)
        {
            String[] graphics = new String[] { 
                spaces + "XX   XX    XXX    X    XX    XXX    XX   XX    XXX    X    XX\n",
                spaces + "XX   XX   XX XX   XX   XX   XX XX   XXX XXX   XX XX   XX   XX\n",
                spaces + "XX   XX  XX   XX  XXX  XX  XX       XX X XX  XX   XX  XXX  XX\n",
                spaces + "XXXXXXX  XXXXXXX  XX X XX  XX  XXX  XX X XX  XXXXXXX  XX X XX\n",
                spaces + "XX   XX  XX   XX  XX  XXX  XX   XX  XX   XX  XX   XX  XX  XXX\n",
                spaces + "XX   XX  XX   XX  XX   XX   XX XX   XX   XX  XX   XX  XX   XX\n",
                spaces + "XX   XX  XX   XX  XX    X    XXX    XX   XX  XX   XX  XX    X\n",
                spaces + "_____________________________________________________________\n",
                spaces + "\n",
                spaces + "                         __________\n",
                spaces + "                         |      \\ |\n",
                spaces + "                         O       \\|\n",
                spaces + "                        /|\\       |\n",
                spaces + "                         |        |\n",
                spaces + "                        / \\       |\n",
                spaces + "                       /   \\      |\n",
                spaces + "                                  |\n",
                spaces + "                                  |\n",
                spaces + "                            =============\n",
                spaces + "                          =================\n"
            };

            //Output
            Console.SetCursorPosition(0, 3);
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (string s in graphics)
            {
                Console.Write(s);
            }
            Console.ResetColor();

        }




    }
}

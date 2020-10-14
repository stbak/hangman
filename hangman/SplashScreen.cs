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
            int startAt = GetStartingPoint("XX   XX    XXX    X    XX    XXX    XX   XX    XXX    X    XX");
            string emptyStr = null;
            for (int i = 0; i < startAt; i++)
            {
                emptyStr = emptyStr + " ";
            }

            Console.SetCursorPosition(0, 3);
            Console.Write("" +
                emptyStr + "XX   XX    XXX    X    XX    XXX    XX   XX    XXX    X    XX\n" +
                emptyStr + "XX   XX   XX XX   XX   XX   XX XX   XXX XXX   XX XX   XX   XX\n" +
                emptyStr + "XX   XX  XX   XX  XXX  XX  XX       XX X XX  XX   XX  XXX  XX\n" +
                emptyStr + "XXXXXXX  XXXXXXX  XX X XX  XX  XXX  XX X XX  XXXXXXX  XX X XX\n" +
                emptyStr + "XX   XX  XX   XX  XX  XXX  XX   XX  XX   XX  XX   XX  XX  XXX\n" +
                emptyStr + "XX   XX  XX   XX  XX   XX   XX XX   XX   XX  XX   XX  XX   XX\n" +
                emptyStr + "XX   XX  XX   XX  XX    X    XXX    XX   XX  XX   XX  XX    X\n" +
                emptyStr + "_____________________________________________________________\n" +
                emptyStr + "\n" +
                emptyStr + "                         __________\n" +
                emptyStr + "                         |      \\ |\n" +
                emptyStr + "                         O       \\|\n" +
                emptyStr + "                        /|\\       |\n" +
                emptyStr + "                         |        |\n" +
                emptyStr + "                        / \\       |\n" +
                emptyStr + "                       /   \\      |\n" +
                emptyStr + "                                  |\n" +
                emptyStr + "                                  |\n" +
                emptyStr + "                            =============\n" +
                emptyStr + "                          =================\n"
                );

        }

        private static int GetStartingPoint(string str)
        {
            int windowWidth = Console.WindowWidth;
            int strLen = str.Length;
            return (windowWidth / 2) - (strLen / 2);
        }




    }
}

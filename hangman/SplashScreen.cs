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
            //Group4Comment: Perhaps add a comment that you trying to center the picture by adding spaces depending on size screen? Hard to understand
            int startAt = GetStartingPoint("XX   XX    XXX    X    XX    XXX    XX   XX    XXX    X    XX");
            string emptyStr = null;
            for (int i = 0; i < startAt; i++)
            {
                emptyStr = emptyStr + " ";   //Group4Comment: Can print like this? emptyStr += " ";
            }
          

            
            Console.SetCursorPosition(0, 3);
            Console.ForegroundColor = ConsoleColor.Yellow;
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
            Console.ForegroundColor = ConsoleColor.White; //  //Group4Comment: Also possible to use resetcolor;
        }

        private static int GetStartingPoint(string str)
        {
            int windowWidth = Console.WindowWidth;
            int strLen = str.Length;
            return (windowWidth / 2) - (strLen / 2);
        }




    }
}

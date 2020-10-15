using System;

namespace Hangman.App
{
    public class GenerateRandomWord
    {

        public static string RandomWord()
        {
            string[] words = { "Sommar", "Vinter", "Vår", "Höst", "Midsommar", "Påsk", "Pingst", "Julafton", "Nyårsafton", "Allhelgona", "Kanelbulle" };

            Random rnd = new Random();
            return words[rnd.Next(0, words.Length - 1)];
        }
    }
}

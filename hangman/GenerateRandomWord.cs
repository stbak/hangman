using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.App
{
    
    public class GenerateRandomWord
    {
        private string _word;
        public static void Run()
        {

            RandomWord();
        
        }

        public void SetWord() {
            _word = RandomWord();
        }

        public string GetWord()
        {
            return _word;
        }

        public static string RandomWord()
        {
            string[] words = { "Sommar", "Vinter", "Vår", "Höst", "Midsommar", "Påsk", "Pingst", "Julafton", "Nyårsafton", "Allhelgona", "Kanelbulle" };
            string rndWord = null;
            Random rnd = new Random();
            double randomNumber = Math.Round(rnd.NextDouble() * 10);
            Console.WriteLine(randomNumber);
            rndWord = words[(int)randomNumber];
            return rndWord;
        }
    }
}

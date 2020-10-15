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
            
            /* Comment Group4: Should be possible to just have 2 lines? Create the Random + Return words[random number 0-10]
            Ex:
            Random rndGroup4 = new Random();
            return  words[rndGroup4.Next(0, 10)];
            */
             string rndWord = null;
            Random rnd = new Random();
            double randomNumber = Math.Round(rnd.NextDouble() * 10); //Comment Group4: use int instead of double
            //Console.WriteLine(randomNumber);
            rndWord = words[(int)randomNumber];
            return rndWord;
            
        }
    }
}

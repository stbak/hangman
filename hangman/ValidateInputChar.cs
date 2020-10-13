using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman
{
    public class ValidateInputChar
    {
        public void Run()
        { 
        
        
        }

        public static Boolean IsInputOk(char guess)
        {

            bool valid = false;
            char[] allowedCharacters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'Å', 'Ä', 'Ö' }; //, 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'å', 'ä', 'ö' };
            foreach (char c in allowedCharacters)
            {

                if (guess == c)
                {
                    valid = true;
                }
            }

            return valid;
        }
    }
}

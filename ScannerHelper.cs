using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
namespace compiler_project
{
    class ScannerHelper
    {
        //2.333 
        static public int compilerisNumber(String s)
        {
            int res, i = 0, chAscii, flagFloat = 0, fractCounter = 0;
            char ch;
            while (i < s.Length)
            {
                ch = s[i];

                chAscii = (int)ch;
                if (i != 0)
                {
                    if ((chAscii >= 48 && chAscii <= 57) || chAscii == 46)
                    {
                        if (chAscii == 46)
                        {
                            flagFloat = 1;
                            fractCounter++; // Must be one fractional point
                        }
                    }
                    else
                        return 0; // Not Number
                }
                //not in 1st index (can not have .)
                else
                {
                    if (chAscii >= 48 && chAscii <= 57 || chAscii == 46)
                    {
                        if (chAscii == 46)
                        {
                            //System.out.println(s.charAt(i) + "for i " + i + " is 2");
                            flagFloat = 1;
                            fractCounter++; // Must be one fractional point
                        }
                    }
                    else
                        return 0; // Not Number
                }

                i++;
            }

            if (flagFloat == 1)
            {
                if (fractCounter == 1)
                    if (s == ".")
                        res = 0;// Not Valid
                    else
                        res = 1; // Float
                else
                    res = 0; // Not Valid
            }

            else
                res = 2; // Int

            return res;
        }
       
        static public int compilerisIdentifier(String lex)
        {
            int chAscii0 = (int)lex[0], chAsciiR = 0;
            int firstCharacter = 0;
            int restOfCharacters = 0;
            int isIdentifier = 0;

            if (lex.Length == 1)
            {//if lex is one character
                if ((chAscii0 >= 65 && chAscii0 <= 90) || (chAscii0 >= 97 && chAscii0 <= 122) || chAscii0 == 95)
                {
                    firstCharacter = 1;
                    restOfCharacters = 1;
                }
            }
            else
            {// if lex is multiple characters
                if ((chAscii0 >= 65 && chAscii0 <= 90) || (chAscii0 >= 97 && chAscii0 <= 122) || chAscii0 == 95)
                {//checking 1st character
                    firstCharacter = 1;
                }
                for (int i = 1; i < lex.Length; i++)
                {
                    chAsciiR = (int)lex[i];
                    //checking rest of characters
                    if ((chAsciiR >= 65 && chAsciiR <= 90) || (chAsciiR >= 97 && chAsciiR <= 122) || chAsciiR == 95 || (chAsciiR >= 48 && chAsciiR <= 57))
                    {
                        restOfCharacters = 1;

                    }
                    else
                    {
                        restOfCharacters = 0;
                        break;
                    }
                }

            }


            if (firstCharacter == 1 && restOfCharacters == 1)
            {
                isIdentifier = 1;
            }
            return isIdentifier;
        }
    }
}

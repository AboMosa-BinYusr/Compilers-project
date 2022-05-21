
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace compiler_project
{
    class CompilerScanner
    {
        static String[,] matric ;
        public  CompilerScanner()
        {
            Excel2D excel = new Excel2D("F:\\College\\3-Third Year\\2-second semester\\Compiler\\project\\t.xlsx", 1);
            matric = excel.getArray();
           
            matric[0, 38] = "+";
            matric[0, 39] = "-";
            matric[0, 40] = "*";
            matric[0, 42] = "=";
            matric[0, 55] = "'";
        }
       
        public Dictionary<string, dynamic> allTextScanner(String text)
        {
            //Dictionary thet will return
            Dictionary<string, dynamic> output = new Dictionary<string, dynamic>();

            List<Dictionary<string, dynamic>> scannarOutPut= new List<Dictionary<string, dynamic>>();

            List<String> Lines = text.Split('\n').ToList(); // carry all lines in the code
            bool isStartComment = false;// multi line comment is close
            int errorCounter = 0;
            foreach (var line in Lines)//to loop on each line in code  1 by 1
            {

                List<String> Words = line.Split(' ').ToList(); // carry all Words in the each line
                 Words.RemoveAll(r => r == "");//remove empty words
                foreach (var word in Words)//to loop on each Word in line  1 by 1
                {
                    //if  multi line comment ended set it close 
                    if (word == "*>")
                    {
                        isStartComment = false;
                    }
                    //if  multi line comment is opend go to next word
                    if (isStartComment) {
                        continue;
                    }
                    // get what this word mach
                    Dictionary<string, dynamic> token = oneWordScanner(word, Lines.IndexOf(line), Words.IndexOf(word));
                    //if token type is "word" it may be  Identifier or error
                    if (token["token type"] == "word")
                    {
                        if (ScannerHelper.compilerisIdentifier(word) == 1)
                        {
                            token["token type"] = "157 Identifier";
                             
                        }
                        else
                        {
                            token["token type"] = "Error";
                            errorCounter++;
                        }
                    }
                    //if  word is singel line comment go to next line
                    if (word == "--")
                    {
                        break;
                    }
                    //if  word is multe line comment set isStartComment true
                    if (word == "<*")
                    {
                        isStartComment = true;

                    }
                    //add new value to lise of Dictionary 
                    scannarOutPut.Add(token);
                }
            }
            //add valus to Dictionary and return it
            output.Add("scannarOutPut", scannarOutPut);
            output.Add("numberOfError",errorCounter);
            return output;
        }
        //if The word is in the language set words
        public Dictionary<string, dynamic> oneWordScanner(String text,int lineNumber,int tokenNumber)
        {
            //Dictionary thet will return
            Dictionary<string, dynamic> wordScannarOutput = new Dictionary<string, dynamic>();

            string word = text;
            string tokenType = "";//carry token type (id,erorr,class,...)
            string token = "";//carrt state number
            int row = 0;
            int i = 0;// number of litter in word

            //check if the word is int or float
            if (ScannerHelper.compilerisNumber(text) != 0)
            {
                tokenType = "1 Constant";
            }
            else
            {
                //loop on columns
                for (int y = 0; y < matric.GetLength(1); y++)
                {
                    //if The first character is in the language set characters
                    if (matric[0, y] == Char.ToString(word[i]))
                    {
                        //take number under token
                        token = matric[1, y];
                    }
                }
                //loop untel break
                while (true)
                {
                    // if first character is not in the language set characters
                    if (token == "")
                    {
                        tokenType = "word";
                        break;
                    }
                    // ensure if token is number(29) not string(45 class)
                    if (ScannerHelper.compilerisNumber(token) == 2)
                    {
                        //loop to get down to the row that token refer to
                        for (int r = 0; r < matric.GetLength(0); r++)
                        {
                            if (matric[r, 0] == token)
                            {
                                row = r;
                                //to go to next character
                                i++;
                            }
                        }
                        //if word ended and not find a end token
                        if (i == word.Length)
                        {
                            tokenType = "word";
                            break;
                        }
                        for (int c = 0; c < matric.GetLength(1); c++)
                        {
                            //check if next character mack token in this row
                            if (matric[0, c] == Char.ToString(word[i]))
                            {
                                //if find tack it
                                token = matric[row, c];
                            }
                        }
                    }
                    //token is string (45 class) (we may find our token)
                    else
                    {
                        // if we fine end token and word ended
                        if (i == (word.Length - 1))
                        {
                            tokenType = token;
                        }
                        // if we fine end token and word is not ended
                        else if (i< (word.Length - 1))
                        {
                            token = token.Split(' ')[0];
                            continue;
                        }
                        // else it may be Identifier or error
                        else
                        {
                            tokenType = "word";
                        }
                        break;
                    }
                }
            }
            //add valus to Dictionary and return it
            wordScannarOutput.Add("line", lineNumber);
            wordScannarOutput.Add("token text", text);
            wordScannarOutput.Add("token type", tokenType);
            wordScannarOutput.Add("token number", tokenNumber);
            return wordScannarOutput;
        }
     }
}

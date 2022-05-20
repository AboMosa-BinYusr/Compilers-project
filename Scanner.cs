
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace compiler_project
{
    class Scanner
    {
        static String[,] matric ;
        public  Scanner(String[,] arr)
        {  
            matric = arr;
            matric[0, 38] = "+";
            matric[0, 39] = "-";
            matric[0, 40] = "*";
            matric[0, 42] = "=";
            matric[0, 55] = "'";
        }
       
        public Dictionary<string, dynamic> scanner(String text)
        {
            Dictionary<string, dynamic> output = new Dictionary<string, dynamic>();

            List<Dictionary<string, dynamic>> scannarOutPut= new List<Dictionary<string, dynamic>>();

            List<String> Lines = text.Split('\n').ToList(); // carry all lines in the code
            bool isStartComment = false;
            int errorCounter = 0;
            foreach (var line in Lines)//to loop on each line in code  1 by 1
            {//Identifier

                List<String> Words = line.Split(' ').ToList(); // carry all Words in the each line
                 Words.RemoveAll(r => r == "");
                foreach (var word in Words)//to loop on each Word in line  1 by 1
                {
                    if (word == "*>")
                    {
                        isStartComment = false;
                    }
                    if (isStartComment) {
                        continue;
                    }
                    Dictionary<string, dynamic> token =wordScanner(word, Lines.IndexOf(line), Words.IndexOf(word));
                    if (token["token type"] != "word")
                    {
                        
                        //Console.WriteLine("Line : " + Lines.IndexOf(line) + ", Token Text: " + word + ", Token Type: " + token);
                    }
                    else
                    {
                        if (ScannerHelper.isIdentifier(word) == 1)
                        {
                            token["token type"] = "157 Identifier";
                            //Console.WriteLine("Line : " + Lines.IndexOf(line) + ", Token Text: " + word + ", Token Type: " + "Identifier");
                        }
                        else
                        {
                            token["token type"] = "Error";
                            //Console.WriteLine("Line : " + Lines.IndexOf(line) + ", Token Text: " + word + ", Token Type: " + "Error Not Found");
                            errorCounter++;
                        }
                    }
                    if (word == "--")
                    {
                        break;
                    }
                    if (word == "<*")
                    {
                        isStartComment = true;

                    }
                    scannarOutPut.Add(token);
                }
                
                //Console.WriteLine("___________________________________________________________");
            }
            //Console.WriteLine("\n Total number of erorr is "+errorCounter);
            output.Add("scannarOutPut", scannarOutPut);
            output.Add("numberOfError",errorCounter);
            return output;
        }
        //if The word is in the language set words
        public Dictionary<string, dynamic> wordScanner(String text,int lineNumber,int tokenNumber)
        {
            Dictionary<string, dynamic> wordScannarOutput = new Dictionary<string, dynamic>();

            string word = text;
            string tokenType = "";
            string token = "";
            int row = 0;
            int i = 0;// number of litter in word

            //check if the word is int or float
            if (ScannerHelper.isNumber(text) != 0)
            {
                //Console.WriteLine("Line : " + lineNumber + ", Token Text: " + text + ", Token Type: " + "Constant");
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
                    }//else return identifier
                }
                while (true)
                {
                    // if first character is not in the language set characters
                    if (token == "")
                    {
                        //Line : 1 Token Text: Program Token Type: Start Statement
                        //Console.WriteLine("Line : " + lineNumber + ", Token Text: " + text + ", Token Type: " + "Identifier");
                        tokenType = "word";
                        break;
                    }
                    // ensure if token is number not string
                    if (ScannerHelper.isNumber(token) == 2)
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
                        if (i == word.Length)
                        {
                            tokenType = "word";
                            //Console.WriteLine("Line : " + lineNumber + ", Token Text: " + text + ", Token Type: " + "Identifier");
                            break;
                        }
                        for (int c = 0; c < matric.GetLength(1); c++)
                        {
                            if (matric[0, c] == Char.ToString(word[i]))
                            {
                                token = matric[row, c];
                            }
                        }
                    }
                    // ensure if token is string  (we may find our token)
                    else
                    {
                        if (i == (word.Length - 1))
                        {
                            //Console.WriteLine(token);
                            tokenType = token;
                            //Console.WriteLine("Line : " + lineNumber + ", Token Text: " + text + ", Token Type: " + token);
                        }
                        else if(i< (word.Length - 1))
                        {
                            token = token.Split(' ')[0];
                            //Console.WriteLine("token is "+token);
                            continue;
                        }
                        else
                        {
                            //Console.WriteLine("Identifier");
                            tokenType = "word";
                            //Console.WriteLine("Line : " + lineNumber + ", Token Text: " + text + ", Token Type: " + "Identifier");
                        }
                        break;
                    }
                }
            }
            wordScannarOutput.Add("line", lineNumber);
            wordScannarOutput.Add("token text", text);
            wordScannarOutput.Add("token type", tokenType);
            wordScannarOutput.Add("token number", tokenNumber);
            return wordScannarOutput;
        }
     }
}

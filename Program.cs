using System;
using System.Collections.Generic;

namespace compiler_project
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                CompilerScanner scanner = new CompilerScanner();

                string text = "End Program \n None ten ( ) { Ilap c = 10 10.10 _1&0we }\n " +
                    "Ilap -- comment \n <* i am \n commented *> \nEnd ";
                // text = "Category Derive If Else Ilap Silap Clop Series Ilapf Silapf None  Logical terminatethis Rotatewhen Continuewhen Replywith Seop Check situationof Program End";
                //text =text+ " +  -  *  /  &&  ||  ~ ==  <  >  !=  <=  >= =  . { } [ ]    \"  \' Using ; ( ) <* *> 10 me";
                
                Dictionary<string, dynamic> scanneroutPut =scanner.allTextScanner(text);
                
                foreach (var dec in scanneroutPut["scannarOutPut"])
                {
                    Console.WriteLine("Line : " +( dec["line"]+1 )+ ", Token Text: " + dec["token text"] + ", Token Type: " + dec["token type"]);
                   
                }
                Console.WriteLine("\n___________________________________________________________\n");
                Console.WriteLine("\nTotal number of erorr is " + scanneroutPut["numberOfError"]);
                Console.ReadKey();
            }
        }
    }
}



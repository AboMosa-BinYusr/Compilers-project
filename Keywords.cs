using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler_project
{
    class Keywords
    {
        static public String classs = "Category";
        static public String inheritance = "Derive";
        static public String integer = "Ilap";
        static public String sInteger = "Silap";
        static public String character = "Clop";
        static public String text = "Series";
        static public String floatt = "Ilapf";
        static public String sFloat = "Silapf";
        static public String voidd = "None";
        static public String boolean = "Logical";
        static public String breakk = "terminatethis";
        static public String returnn = "Replywith";
        static public String structt = "Seop";
        static public String startStatement = "Program";
        static public String endStatement = "End";

        static public String assignmentOperator = "=";
        static public String accessOperator = ".";

        static public String inclusion = "Using";
        static public String ender = ";";

        static public List<String> Condition = new List<String>() { "If", "Else" };
        static public List<String> Loop = new List<String>() { "Rotatewhen", "Continuewhen" };
        static public List<String> Switch = new List<String>() { "Check", "situationof" };
        static public List<String> arithmaticOperations = new List<String>() { "+", "-", "*", "/" };
        static public List<String> logicOperators = new List<String>() { "&&", "||", "~" };
        static public List<String> relationalOperators = new List<String>() { "==", "!=", ">=", "<=", ">", "<" };
        static public List<String> brackets = new List<String>() { "{", "}", "[", "]", "(", ")" };
        static public List<String> quotationMarks = new List<String>() { "\"", "\'" };

        Dictionary<string, string> tokens = new Dictionary<string, string>(){
            {classs, "Class"},
            {inheritance, "Inheritance"},
            {Condition[0], "Condition"},
            {Condition[1], "Condition"},
            {integer, "Integer"},
            {sInteger, "Sinteger"},
            {character, "Character"},
            {floatt, "Float"},
            {sFloat, "Sfloat"},
            {voidd, "Void"},
            {boolean, "Boolean"},
            {returnn, "Return"},
            {breakk, "terminatethis"},
            {Loop[1], "Loop"},
            {Loop[2], "Loop"},
            {structt, "Struct"},
            {Switch[1], "Switch"},
            {Switch[2], "Switch"},
            {startStatement, "Program"},
            {endStatement, "End"},
            {arithmaticOperations[0], "Arithmatic operation"},
            {arithmaticOperations[1], "Arithmatic operation"},
            {arithmaticOperations[2], "Arithmatic operation"},
            {arithmaticOperations[3], "Arithmatic operation"},
            {logicOperators[0], "Logic operator"},
            {logicOperators[1], "Logic operator"},
            {logicOperators[2], "Logic operator"},
            {relationalOperators[0], "relational operator"},
            {relationalOperators[1], "relational operator"},
            {relationalOperators[2], "relational operator"},
            {relationalOperators[3], "relational operator"},
            {relationalOperators[4], "relational operator"},
            {relationalOperators[5], "relational operator"},
            {brackets[0], "Bracket"},
            {brackets[1], "Bracket"},
            {brackets[2], "Bracket"},
            {brackets[3], "Bracket"},
            {inclusion, "Inclusion"},
            {quotationMarks[0], "Quotation mark"},
            {quotationMarks[1], "Quotation mark"},
        };
    }
}

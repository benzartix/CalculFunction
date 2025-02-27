using CalculFonctionQuadratique.Core.Entities;
using System.Text.RegularExpressions;

namespace CalculFonctionQuadratique.Core.Parsing
{
    public class Parsing : IParsing
    {
        public bool Parse(string str, out ValueFonction valueFct)
        {
            valueFct = new ValueFonction();

            if (ParsingConst(str, out int constant))
            {
                valueFct.coef_A = 0;
                valueFct.coef_B = 0;
                valueFct.coef_C = constant;
                return true;
            }

            if (ParsingSquare(str))
            {
                valueFct.coef_A = 1;
                valueFct.coef_B = 0;
                valueFct.coef_C = 0;
                return true;
            }

            if (ParsingLinear(str, out int b, out int c))
            {
                valueFct.coef_A = 0;
                valueFct.coef_B = b;
                valueFct.coef_C = c;
                return true;
            }

            if (ParsinggQuadratic(str, out int a, out int b1, out int c1))
            {
                valueFct.coef_A = a;
                valueFct.coef_B = b1;
                valueFct.coef_C = c1;
                return true;
            }

            return false;
        }

        private bool ParsingConst(string str, out int constant)
        {
            Match match = Regex.Match(str, @"^[a-zA-Z_]*\(x\)=\s*(?<c>-?\d+)$");
            if (match.Success)
            {
                constant = int.Parse(match.Groups["c"].Value);
                return true;
            }
            constant = 0;
            return false;
        }

        private bool ParsingSquare(string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z_]*\(x\)=x(?:\^2|²)$");
        }

        private bool ParsingLinear(string input, out int b, out int c)
        {
            Match match = Regex.Match(input, @"^[a-zA-Z_]*\(x\)=\s*(?<b>-?\d+)x\s*(?<c>[+-]?\d+)?$");
            if (match.Success)
            {
                b = int.Parse(match.Groups["b"].Value);
                c = string.IsNullOrEmpty(match.Groups["c"].Value) ? 0 : int.Parse(match.Groups["c"].Value);
                return true;
            }
            b = c = 0;
            return false;
        }

        private bool ParsinggQuadratic(string input, out int a, out int b1, out int c1)
        {
            Match match = Regex.Match(input, @"^[a-zA-Z]+\s*\(x\)\s*=\s*(?<a>[+-]?\d*)x(?:\^2|²)\s*(?<b>[+-]?\d*)x?\s*(?<c>[+-]?\d+)?$");
            if (match.Success)
            {
                //a
                a = string.IsNullOrEmpty(match.Groups["a"].Value) ? 1 : int.Parse(match.Groups["a"].Value);

                //b
                string bString;
                switch (match.Groups["b"].Value)
                {
                    case "+":
                        bString = "1";
                        break;
                    case "-":
                        bString = "-1";
                        break;
                    default:
                        bString = match.Groups["b"].Value;
                        break;
                }
                b1 = string.IsNullOrEmpty(bString) ? 0 : int.Parse(bString);

                c1 = string.IsNullOrEmpty(match.Groups["c"].Value) ? 0 : int.Parse(match.Groups["c"].Value);

                return true;
            }

            a = 0;
            b1 = 0;
            c1 = 0;
            return false;
        }
    }
}

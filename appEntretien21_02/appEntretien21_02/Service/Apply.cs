using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace appEntretien21_02
{
    public class Apply : IApply
    {
        public int ApplyFunction(string quadraticFunction, int x)
        {
            if (FuncConst(quadraticFunction, out int constantValue))
                return constantValue;

            if (FuncSquare(quadraticFunction))
                return x * x;

            if (FuncLinear(quadraticFunction, out int b, out int c))
                return b * x + c;

            if (FuncPolynome(quadraticFunction, out int a, out b, out c))
                return a * x * x + b * x + c;


            return 0;
        }

        // Const
        private bool FuncConst(string input, out int constantValue)
        {
            Match match = Regex.Match(input, @"^const\(x\)=(?<c>-?\d+)$");
            if (match.Success)
            {
                constantValue = int.Parse(match.Groups["c"].Value);
                return true;
            }
            constantValue = 0;
            return false;
        }

        // x²
        private bool FuncSquare(string input)
        {
            return Regex.IsMatch(input, @"^square\(x\)=x(?:\^2|²)$");
        }

        // bx + c
        private bool FuncLinear(string input, out int b, out int c)
        {
            Match match = Regex.Match(input, @"^linear\s*\(x\)=\s*(?<b>-?\d+)x\s*(?<c>[+-]?\d+)?$");
            if (match.Success)
            {
                b = int.Parse(match.Groups["b"].Value);
                c = string.IsNullOrEmpty(match.Groups["c"].Value) ? 0 : int.Parse(match.Groups["c"].Value);
                return true;
            }
            b = c = 0;
            return false;
        }

        // ax² + bx + c
        private bool FuncPolynome(string input, out int a, out int b, out int c)
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
                b = string.IsNullOrEmpty(bString) ? 0 : int.Parse(bString);

                //c
                c = string.IsNullOrEmpty(match.Groups["c"].Value) ? 0 : int.Parse(match.Groups["c"].Value);

                return true;
            }
            a = b = c = 0;
            return false;
        }

    }
}

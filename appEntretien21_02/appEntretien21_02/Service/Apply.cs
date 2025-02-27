using CalculFonctionQuadratique.Core.Calcul;
using CalculFonctionQuadratique.Core.Entities;
using CalculFonctionQuadratique.Core.Parsing;

namespace CalculFonctionQuadratique
{
    public class Apply : IApply
    {
        private readonly IParsing _parsing;
        private readonly ICalcul _calcul;

        public Apply(IParsing parsing, ICalcul calcul)
        {
            _parsing = parsing;
            _calcul = calcul;
        }

        public int ApplyFunction(string function, int x)
        {
            if (_parsing.Parse(function, out ValueFonction exp))
            {
                return _calcul.Calcul_Fonction(exp, x);
            }
            return 0;
        }

    }
}

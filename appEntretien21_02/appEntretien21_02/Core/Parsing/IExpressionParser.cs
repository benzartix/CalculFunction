using CalculFonctionQuadratique.Core.Entities;

namespace CalculFonctionQuadratique.Core.Parsing
{
    public interface IParsing
    {
        public bool Parse(string input, out ValueFonction exp);
    }
}

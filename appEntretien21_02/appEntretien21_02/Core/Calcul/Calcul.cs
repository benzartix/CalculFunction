
using CalculFonctionQuadratique.Core.Entities;

namespace CalculFonctionQuadratique.Core.Calcul
{
    public class Calcul : ICalcul
    {
        public int Calcul_Fonction(ValueFonction valueFct, int x)
        {
            return valueFct.coef_A * x * x + valueFct.coef_B * x + valueFct.coef_C;
        }

    }
}


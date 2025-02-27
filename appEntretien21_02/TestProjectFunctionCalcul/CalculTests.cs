using CalculFonctionQuadratique.Core.Calcul;
using CalculFonctionQuadratique.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProjectFunctionCalcul
{
    public class CalculTests
    {
        private readonly Calcul _calcul;

        public CalculTests()
        {
            _calcul = new Calcul();
        }

        [Theory]
        [InlineData(0, 0, 5, 3, 5)] //  f(x) = 5            // true
        [InlineData(1, 0, 0, 4, 16)] // f(x) = x²           // true
        [InlineData(0, -3, 7, 2, 1)] // f(x) = -3x + 7      // true
        [InlineData(2, -4, 1, 3, 7)] // f(x) = 2x² - 4x + 1 // true
        public void Evaluate_ShouldReturnCorrectResult(int a, int b, int c, int x, int expected)
        {
            // Arrange
            var expression = new ValueFonction { coef_A = a, coef_B = b, coef_C = c };

            // Act
            int result = _calcul.Calcul_Fonction(expression, x);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, -4, 1, 3, 8)] // f(x) = 2x² - 4x + 1 // false
        public void Evaluate_ShouldReturnFailedResult(int a, int b, int c, int x, int expected)
        {
            // Arrange
            var expression = new ValueFonction { coef_A = a, coef_B = b, coef_C = c };

            // Act
            int result = _calcul.Calcul_Fonction(expression, x);

            // Assert
            Assert.NotEqual(expected, result);
        }
    }
}

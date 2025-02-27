
using CalculFonctionQuadratique.Core.Entities;
using CalculFonctionQuadratique.Core.Parsing;
using Xunit;

namespace TestProjectFunctionCalcul
{
    public class ParsingTests
    {
        private readonly Parsing _parser;

        public ParsingTests()
        {
            _parser = new Parsing();
        }


        [Theory]
        [InlineData("f(x)=5", 0, 0, 5)] // Constante
        [InlineData("f(x)=x²", 1, 0, 0)] // x²
        [InlineData("f(x)=-3x+7", 0, -3, 7)] // bx + c
        [InlineData("f(x)=2x²-4x+1", 2, -4, 1)] // ax² + bx + c
        public void TryParse_ShouldExtractCorrectCoefficients(string function, int a, int b, int c)
        {
            // Act
            bool result = _parser.Parse(function, out ValueFonction fct);

            // Assert
            Assert.True(result);
            Assert.Equal(a, fct.coef_A);
            Assert.Equal(b, fct.coef_B);
            Assert.Equal(c, fct.coef_C);
        }

        [Fact]
        public void TryParse_ShouldFailForInvalidFunction()
        {
            // Arrange
            string invalidFunction = "ahmed(x)=xyesz";

            // Act
            bool result = _parser.Parse(invalidFunction, out ValueFonction fct);

            // Assert
            Assert.False(result);
            Assert.Equal(0, fct.coef_A);
            Assert.Equal(0, fct.coef_B);
            Assert.Equal(0, fct.coef_C);
        }

    }
}

using CalculFonctionQuadratique;
using CalculFonctionQuadratique.Core.Calcul;
using CalculFonctionQuadratique.Core.Entities;
using CalculFonctionQuadratique.Core.Parsing;
using Moq;
using Xunit;

namespace TestProjectFunctionCalcul
{
    public class ApplyTests
    {
        private readonly Mock<IParsing> _mockParsing;
        private readonly Mock<ICalcul> _mockCalcul;
        private readonly Apply _apply;

        public ApplyTests()
        {
            _mockParsing = new Mock<IParsing>();
            _mockCalcul = new Mock<ICalcul>();
            _apply = new Apply(_mockParsing.Object, _mockCalcul.Object);
        }

        [Fact]
        public void ApplyFunction_ShouldReturnComputedValue_WhenParsingSucceeds()
        {
            // Arrange
            string function = "f(x)=2x²+3x+5";
            int x = 4;
            var expression = new ValueFonction { coef_A = 2, coef_B = 3, coef_C = 5 };

            _mockParsing.Setup(x => x.Parse(function, out expression)).Returns(true);
            _mockCalcul.Setup(p => p.Calcul_Fonction(expression, x)).Returns(41);

            // Act
            int result = _apply.ApplyFunction(function, x);

            // Assert
            Assert.Equal(41, result);
        }

        [Fact]
        public void ApplyFunction_ShouldReturnZero_WhenParsingFails()
        {
            // Arrange
            string function = "invalid(x)=xyz";
            ValueFonction expression = new ValueFonction();

            _mockParsing.Setup(p => p.Parse(function, out expression)).Returns(false);

            // Act
            int result = _apply.ApplyFunction(function, 3);

            // Assert
            Assert.Equal(0, result);
            _mockCalcul.Verify(e => e.Calcul_Fonction(It.IsAny<ValueFonction>(), It.IsAny<int>()), Times.Never);
        }
    }
}

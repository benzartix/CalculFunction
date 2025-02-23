using appEntretien21_02;
using System;
using Xunit;

namespace TestProjectFunctionCalcul
{
    public class FunctionEvaluatorTests
    {
        private readonly IApply _apply;

        public FunctionEvaluatorTests()
        {
            _apply = new Apply();
        }

        [Fact]
        public void Test1()
        {
            // Arrange
            string function = "const(x)=42";
            int x = 4; // Peu importe x, c'est une constante

            // Act
            int result = _apply.ApplyFunction(function, x);

            // Assert
            Assert.Equal(42, result);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            string function = "square(x)=x^2";
            int x = 4;

            // Act
            int result = _apply.ApplyFunction(function, x);

            Assert.Equal(16, result);
        }

        [Fact]
        public void Test3()
        {
            // Arrange
            string function = "const(x)=42";
            int x = 42;

            // Act
            int result = _apply.ApplyFunction(function, x);

            Assert.Equal(x, result);
        }

        [Theory]
        [InlineData("f(x)=2x^2+x+1", 4, 37)] 
        [InlineData("func(x)=5x^2-7", 4, 52)] 
        public void Test4(string function, int x, int expected)
        {
            // Act
            int result = _apply.ApplyFunction(function, x);

            // Assert
            Assert.Equal(expected, result);
        }

    }
}

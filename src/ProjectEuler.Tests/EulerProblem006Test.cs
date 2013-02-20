using ProjectEuler.Problems;
using FluentAssertions;
using Xunit;

namespace ProjectEuler.Tests
{
    public class EulerProblem006Test
    {
        [Fact]
        public void TheDifferenceBetweenTheSumOfTheSquaresOfTheFirstTenNaturalNumbersAndTheSquareOfTheSumMustBe2640()
        {
            const int expected = 2640;
            var result = new EulerProblem006(1, 10).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void TheDifferenceBetweenTheSumOfTheSquaresOfTheFirstOneHundredNaturalNumbersAndTheSquareOfTheSumMustBe25164150()
        {
            const int expected = 25164150;
            var result = new EulerProblem006(1, 100).Solve();
            result.Should().Be(expected);
        }
    }
}

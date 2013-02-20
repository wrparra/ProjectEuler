using ProjectEuler.Problems;
using FluentAssertions;
using Xunit;

namespace ProjectEuler.Tests
{
    public class EulerProblem005Test
    {
        [Fact]
        public void TheSmallestNumberThatCanBeDividedByEachOfTheNumbersFrom1To5WithoutAnyRemainderMustBe60()
        {
            const int expected = 60;
            var result = new EulerProblem005(1, 5).Solve();
            result.Should().Be(expected);
        }
        
        [Fact]
        public void TheSmallestNumberThatCanBeDividedByEachOfTheNumbersFrom1To10WithoutAnyRemainderMustBe2520()
        {
            const int expected = 2520;
            var result = new EulerProblem005(1, 10).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void TheSmallestNumberThatCanBeDividedByEachOfTheNumbersFrom1To15WithoutAnyRemainderMustBe360360()
        {
            const int expected = 360360;
            var result = new EulerProblem005(1, 15).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void TheSmallestNumberThatCanBeDividedByEachOfTheNumbersFrom1To20WithoutAnyRemainderMustBe232792560()
        {
            const int expected = 232792560;
            var result = new EulerProblem005(1, 20).Solve();
            result.Should().Be(expected);
        }
    }
}

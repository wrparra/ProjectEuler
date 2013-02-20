using ProjectEuler.Problems;
using FluentAssertions;
using Xunit;

namespace ProjectEuler.Tests
{
    public class EulerProblem007Test
    {
        [Fact]
        public void The6ThPrimeNumberMustBe13()
        {
            const int expected = 13;
            var result = new EulerProblem007(6).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void The10001StPrimeNumberMustBe104743()
        {
            const int expected = 104743;
            var result = new EulerProblem007(10001).Solve();
            result.Should().Be(expected);
        }
    }
}

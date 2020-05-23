using FluentAssertions;
using ProjectEuler.Problems;
using Xunit;

namespace ProjectEuler.Tests
{
    public class EulerProblem010Test
    {

        [Fact]
        public void TheSumOfAllThePrimesBelowTwoMillionMustBe142913828922()
        {
            const long expected = 142913828922;
            var result = new EulerProblem010(2000000).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void TheSumOfAllThePrimesBelow10MustBe17()
        {
            const int expected = 17;
            var result = new EulerProblem010(10).Solve();
            result.Should().Be(expected);
        }
    }
}

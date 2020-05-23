using FluentAssertions;
using ProjectEuler.Problems;
using Xunit;

namespace ProjectEuler.Tests
{
    public class EulerProblem001Test
    {
        [Fact]
        public void WhenWeListAllTheNaturalNumbersBelow10ThatAreMultiplesOf3Or5TheSumMustBe23()
        {
            const int expected = 23;
            var result = new EulerProblem001(1, 9).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void EulerProblem001Test_Solve()
        {
            const int expected = 233168;
            var result = new EulerProblem001().Solve();
            result.Should().Be(expected);
        }
    }
}

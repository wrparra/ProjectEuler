using ProjectEuler.Problems;
using FluentAssertions;
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
        public void WhenWeListAllTheNaturalNumbersBelow1000ThatAreMultiplesOf3Or5TheSumMustBe233168()
        {
            const int expected = 233168;
            var result = new EulerProblem001(1, 999).Solve();
            result.Should().Be(expected);
        }
    }
}

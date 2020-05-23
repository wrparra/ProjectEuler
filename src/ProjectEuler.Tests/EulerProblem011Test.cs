using FluentAssertions;
using ProjectEuler.Problems;
using Xunit;

namespace ProjectEuler.Tests
{
    public class EulerProblem011Test
    {

        [Fact]
        public void TheGreatestProductOfFourAdjacentNumbersInTheSameDirectionUpDownLeftRightOrDiagonallyInThe20X20Grid()
        {
            const long expected = 70600674;
            var result = new EulerProblem011().Solve();
            result.Should().Be(expected);
        }
    }
}

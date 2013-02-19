using ProjectEuler.Problems;
using FluentAssertions;
using Xunit;

namespace ProjectEuler.Tests
{
    public class EulerProblem010Test
    {

        [Fact]
        public void the_sum_of_all_the_primes_below_two_million_must_be_142913828922()
        {
            const long expected = 142913828922;
            var result = new EulerProblem010(2000000).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void the_sum_of_all_the_primes_below_10_must_be_17()
        {
            const int expected = 17;
            var result = new EulerProblem010(10).Solve();
            result.Should().Be(expected);
        }

       

    }
}

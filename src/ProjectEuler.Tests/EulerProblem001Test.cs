using ProjectEuler.Problems;
using FluentAssertions;
using Xunit;

namespace ProjectEuler.Tests
{
    public class EulerProblem001Test
    {
        [Fact]
        public void When_we_list_all_the_natural_numbers_below_10_that_are_multiples_of_3_or_5_the_sum_must_be_23()
        {
            const int expected = 23;
            var result = new EulerProblem001(1, 10).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void When_we_list_all_the_natural_numbers_below_999_that_are_multiples_of_3_or_5_the_sum_must_be_233168()
        {
            const int expected = 233168;
            var result = new EulerProblem001(1, 1000).Solve();
            result.Should().Be(expected);
        }
    }
}

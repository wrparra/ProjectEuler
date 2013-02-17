using ProjectEuler.Problems;
using FluentAssertions;
using Xunit;

namespace ProjectEuler.Tests
{
    public class EulerProblem006Test
    {
        [Fact]
        public void the_difference_between_the_sum_of_the_squares_of_the_first_ten_natural_numbers_and_the_square_of_the_sum_must_be_2640()
        {
            const int expected = 2640;
            var result = new EulerProblem006(1, 10).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void the_difference_between_the_sum_of_the_squares_of_the_first_one_hundred_natural_numbers_and_the_square_of_the_sum_must_be_25164150()
        {
            const int expected = 25164150;
            var result = new EulerProblem006(1, 100).Solve();
            result.Should().Be(expected);
        }
    }
}

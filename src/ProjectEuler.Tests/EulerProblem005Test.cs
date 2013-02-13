using ProjectEuler.Problems;
using FluentAssertions;
using Xunit;

namespace ProjectEuler.Tests
{
    public class EulerProblem005Test
    {
        [Fact]
        public void the_smallest_number_that_can_be_divided_by_each_of_the_numbers_from_1_to_5_without_any_remainder_must_be_60()
        {
            const int expected = 60;
            var result = new EulerProblem005(1, 5).Solve();
            result.Should().Be(expected);
        }
        
        [Fact]
        public void the_smallest_number_that_can_be_divided_by_each_of_the_numbers_from_1_to_10_without_any_remainder_must_be_2520()
        {
            const int expected = 2520;
            var result = new EulerProblem005(1, 10).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void the_smallest_number_that_can_be_divided_by_each_of_the_numbers_from_1_to_15_without_any_remainder_must_be_360360()
        {
            const int expected = 360360;
            var result = new EulerProblem005(1, 15).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void the_smallest_number_that_can_be_divided_by_each_of_the_numbers_from_1_to_20_without_any_remainder_must_be_232792560()
        {
            const int expected = 232792560;
            var result = new EulerProblem005(1, 20).Solve();
            result.Should().Be(expected);
        }
    }
}

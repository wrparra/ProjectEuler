using ProjectEuler.Problems;
using FluentAssertions;
using Xunit;

namespace ProjectEuler.Tests
{
    public class EulerProblem002Test
    {
        [Fact]
        public void The_10_first_numbers_in_Fibonacci_sequence_must_Print_1_2_3_5_8_13_21_34_55_89()
        {
            const string expected = "1, 2, 3, 5, 8, 13, 21, 34, 55, 89";
            var result = new EulerProblem002(1, 89).Print();
            result.Should().Be(expected);
        }

        [Fact]
        public void The_sum_of_even_10_first_terms_in_Fibonacci_sequence_must_be_44()
        {
            const int expected = 44;
            var result = new EulerProblem002(1, 89).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void the_sum_of_even_terms_in_Fibonacci_sequence_whose_values_do_not_exceed_four_million_must_be_4613732()
        {
            const int expected = 4613732;
            var result = new EulerProblem002(1, 4000000).Solve();
            result.Should().Be(expected);
        }
    }
}

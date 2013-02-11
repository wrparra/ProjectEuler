﻿using ProjectEuler.Extensions;
using ProjectEuler.Problems;
using FluentAssertions;
using Xunit;
using System.Linq;

namespace ProjectEuler.Tests
{
    public class EulerProblem002Test
    {
        [Fact]
        public void The_12_first_numbers_in_Fibonacci_sequence_must_Print_0_1_1_2_3_5_8_13_21_34_55_89()
        {
            const string expected = "0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89";
            var numbers =  MathExtensions.FibonacciNumbers().Take(12);
            var result = string.Join(", ", numbers);
            result.Should().Be(expected);
        }

        [Fact]
        public void The_44_first_numbers_in_Fibonacci_sequence()
        {
            var result = MathExtensions.FibonacciNumbers().Take(44);
            result.Should().HaveCount(44);
        }

        [Fact]
        public void The_sum_of_even_10_first_terms_in_Fibonacci_sequence_must_be_44()
        {
            const int expected = 44;
            var result = new EulerProblem002(89).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void the_sum_of_even_terms_in_Fibonacci_sequence_whose_values_do_not_exceed_four_million_must_be_4613732()
        {
            const int expected = 4613732;
            var result = new EulerProblem002(4000000).Solve();
            result.Should().Be(expected);
        }
    }
}

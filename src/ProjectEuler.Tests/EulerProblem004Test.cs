using System.Linq;
using ProjectEuler.Collections;
using ProjectEuler.Extensions;
using ProjectEuler.Problems;
using FluentAssertions;
using Xunit;

namespace ProjectEuler.Tests
{
    public class EulerProblem004Test
    {
        #region Verifying Palindromes

        [Fact]
        public void The_number_9009_must_be_Palindrome()
        {
            9009.IsPalindrome().Should().BeTrue();
        }

        [Fact]
        public void The_number_1234_must_not_be_Palindrome()
        {
            1234.IsPalindrome().Should().BeFalse();
        }

        [Fact]
        public void The_number_1223_must_not_be_Palindrome()
        {
            1223.IsPalindrome().Should().BeFalse();
        }

        [Fact]
        public void The_number_1221_must_be_Palindrome()
        {
            1221.IsPalindrome().Should().BeTrue();
        }

        #endregion

        [Fact]
        public void The_largest_palindrome_made_from_the_product_of_one_digit_numbers_must_be_9()
        {
            const int expected = 9;
            var result = new EulerProblem004(1, 10).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void The_largest_palindrome_made_from_the_product_of_two_digit_numbers_must_be_9009()
        {
            const int expected = 9009;
            var result = new EulerProblem004(10, 100).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void The_largest_palindrome_made_from_the_product_of_three_digit_numbers_must_be_906609()
        {
            const int expected = 906609;
            var result = new EulerProblem004(100, 1000).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void The_largest_palindrome_made_from_the_product_of_four_digit_numbers_must_be_99000099()
        {
            const int expected = 99000099;
            var result = new EulerProblem004(1000, 10000).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void The_largest_palindrome_made_from_the_product_of_five_digit_numbers_must_be_906609()
        {
            const int expected = 6948496;
            var result = new EulerProblem004(568, 2653).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void Palindromes_made_from_the_product_of_three_digit_numbers_must_contains_2470()
        {
            var range = new Range(100, 1000).Reverse();
            var result = (from n in range from x in range let p = (n * x) where p.IsPalindrome() select p);
            result.Should().HaveCount(2470);
        }

        [Fact]
        public void Palindromes_made_from_the_product_of_three_digit_numbers_must_contains_655()
        {
            var range = new Range(100, 1000).Reverse();
            var result = (from n in range from x in range let p = (n * x) where p.IsPalindrome() select p).Distinct();
            result.Should().HaveCount(655);
        }
    }
}

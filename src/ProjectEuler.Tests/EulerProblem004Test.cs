using FluentAssertions;
using ProjectEuler.Collections;
using ProjectEuler.Extensions;
using ProjectEuler.Problems;
using System.Linq;
using Xunit;

namespace ProjectEuler.Tests
{
    public class EulerProblem004Test
    {
        #region Verifying Palindromes

        [Fact]
        public void TheNumber9009MustBePalindrome()
        {
            9009.IsPalindrome().Should().BeTrue();
        }

        [Fact]
        public void TheNumber1234MustNotBePalindrome()
        {
            1234.IsPalindrome().Should().BeFalse();
        }

        [Fact]
        public void TheNumber1223MustNotBePalindrome()
        {
            1223.IsPalindrome().Should().BeFalse();
        }

        [Fact]
        public void TheNumber1221MustBePalindrome()
        {
            1221.IsPalindrome().Should().BeTrue();
        }

        #endregion

        [Fact]
        public void TheLargestPalindromeMadeFromTheProductOfOneDigitNumbersMustBe9()
        {
            const int expected = 9;
            var result = new EulerProblem004(1, 10).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void TheLargestPalindromeMadeFromTheProductOfTwoDigitNumbersMustBe9009()
        {
            const int expected = 9009;
            var result = new EulerProblem004(10, 100).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void TheLargestPalindromeMadeFromTheProductOfThreeDigitNumbersMustBe906609()
        {
            const int expected = 906609;
            var result = new EulerProblem004(100, 1000).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void TheLargestPalindromeMadeFromTheProductOfFourDigitNumbersMustBe99000099()
        {
            const int expected = 99000099;
            var result = new EulerProblem004(1000, 10000).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void TheLargestPalindromeMadeFromTheProductOfFiveDigitNumbersMustBe906609()
        {
            const int expected = 6948496;
            var result = new EulerProblem004(568, 2653).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void PalindromesMadeFromTheProductOfThreeDigitNumbersMustContains2470()
        {
            var range = new Range(100, 1000).Reverse();
            var result = (from n in range from x in range let p = (n * x) where p.IsPalindrome() select p);
            result.Should().HaveCount(2470);
        }

        [Fact]
        public void PalindromesMadeFromTheProductOfThreeDigitNumbersMustContains655()
        {
            var range = new Range(100, 1000).Reverse();
            var result = (from n in range from x in range let p = (n * x) where p.IsPalindrome() select p).Distinct();
            result.Should().HaveCount(655);
        }
    }
}

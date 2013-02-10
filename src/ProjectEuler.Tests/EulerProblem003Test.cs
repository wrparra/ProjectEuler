using System;
using System.Linq;
using ProjectEuler.Extensions;
using ProjectEuler.Problems;
using FluentAssertions;
using Xunit;

namespace ProjectEuler.Tests
{
    public class EulerProblem003Test
    {
        [Fact]
        public void the_largest_prime_factor_of_the_number_13195_must_be_29()
        {
            const int expected = 29;
            var result = new EulerProblem003(13195).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void the_largest_prime_factor_of_the_number_600851475143_must_be_6857()
        {
            const int expected = 6857;
            var result = new EulerProblem003(600851475143).Solve();
            result.Should().Be(expected);
        }
        
        #region Verifying Prime numbers

        [Fact]
        public void The_prime_numbers_below_100()
        {
            const string expected = "2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97";
            var numbers = MathExtensions.PrimeNumbers().TakeWhile(i => i <= 100);
            var result = string.Join(", ", numbers.ToArray());
            result.Should().Be(expected);
        }

        [Fact]
        public void The_number_of_primes_below_104730_must_be_ten_thousand()
        {
            const int expected = 10000;
            var result = MathExtensions.PrimeNumbers().TakeWhile(i => i < 104730).Count();
            result.Should().Be(expected);
        }

        [Fact]
        public void Number_0_must_not_be_Prime()
        {
            0ul.IsPrime().Should().BeFalse();
        }

        [Fact]
        public void Number_1_must_not_be_Prime()
        {
            1ul.IsPrime().Should().BeFalse();
        }

        [Fact]
        public void Number_2_must_be_Prime()
        {
            2ul.IsPrime().Should().BeTrue();
        }

        [Fact]
        public void Number_3_must_be_Prime()
        {
            3ul.IsPrime().Should().BeTrue();
        }

        [Fact]
        public void Number_4_must_not_be_Prime()
        {
            4ul.IsPrime().Should().BeFalse();
        }

        [Fact]
        public void Number_5_must_be_Prime()
        {
            5ul.IsPrime().Should().BeTrue();
        }

        [Fact]
        public void Number_6_must_not_be_Prime()
        {
            6ul.IsPrime().Should().BeFalse();
        }

        [Fact]
        public void Number_7_must_be_Prime()
        {
            7ul.IsPrime().Should().BeTrue();
        }

        [Fact]
        public void Number_8_must_not_be_Prime()
        {
            8ul.IsPrime().Should().BeFalse();
        }

        [Fact]
        public void Number_9_must_not_be_Prime()
        {
            9ul.IsPrime().Should().BeFalse();
        }

        #endregion
    }
}

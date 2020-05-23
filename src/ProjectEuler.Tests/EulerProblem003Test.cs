using FluentAssertions;
using ProjectEuler.Extensions;
using ProjectEuler.Problems;
using System.Linq;
using Xunit;

namespace ProjectEuler.Tests
{
    public class EulerProblem003Test
    {
        [Fact]
        public void TheLargestPrimeFactorOfTheNumber13195MustBe29()
        {
            const int expected = 29;
            var result = new EulerProblem003(13195).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void TheLargestPrimeFactorOfTheNumber600851475143MustBe6857()
        {
            const int expected = 6857;
            var result = new EulerProblem003(600851475143).Solve();
            result.Should().Be(expected);
        }
        
        #region Verifying Prime numbers

        [Fact]
        public void ThePrimeNumbersBelow100()
        {
            const string expected = "2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97";
            var numbers = MathExtensions.PrimeNumbers().TakeWhile(i => i <= 100);
            var result = string.Join(", ", numbers.ToArray());
            result.Should().Be(expected);
        }

        [Fact]
        public void TheNumberOfPrimesBelow104730MustBeTenThousand()
        {
            const int expected = 10000;
            var result = MathExtensions.PrimeNumbers().TakeWhile(i => i < 104730).Count();
            result.Should().Be(expected);
        }

        [Fact]
        public void Number0MustNotBePrime()
        {
            0L.IsPrime().Should().BeFalse();
        }

        [Fact]
        public void Number1MustNotBePrime()
        {
            1L.IsPrime().Should().BeFalse();
        }

        [Fact]
        public void Number2MustBePrime()
        {
            2L.IsPrime().Should().BeTrue();
        }

        [Fact]
        public void Number3MustBePrime()
        {
            3L.IsPrime().Should().BeTrue();
        }

        [Fact]
        public void Number4MustNotBePrime()
        {
            4L.IsPrime().Should().BeFalse();
        }

        [Fact]
        public void Number5MustBePrime()
        {
            5L.IsPrime().Should().BeTrue();
        }

        [Fact]
        public void Number6MustNotBePrime()
        {
            6L.IsPrime().Should().BeFalse();
        }

        [Fact]
        public void Number7MustBePrime()
        {
            7L.IsPrime().Should().BeTrue();
        }

        [Fact]
        public void Number8MustNotBePrime()
        {
            8L.IsPrime().Should().BeFalse();
        }

        [Fact]
        public void Number9MustNotBePrime()
        {
            9L.IsPrime().Should().BeFalse();
        }

        #endregion
    }
}

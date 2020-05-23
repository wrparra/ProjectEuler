using FluentAssertions;
using ProjectEuler.Extensions;
using ProjectEuler.Problems;
using System.Linq;
using Xunit;

namespace ProjectEuler.Tests
{
    public class EulerProblem002Test
    {
        [Fact]
        public void The12FirstNumbersInFibonacciSequenceMustPrint01123581321345589()
        {
            const string expected = "0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89";
            var numbers =  MathExtensions.FibonacciNumbers().Take(12);
            var result = string.Join(", ", numbers);
            result.Should().Be(expected);
        }

        [Fact]
        public void The44FirstNumbersInFibonacciSequence()
        {
            var result = MathExtensions.FibonacciNumbers().Take(44);
            result.Should().HaveCount(44);
        }

        [Fact]
        public void TheSumOfEven10FirstTermsInFibonacciSequenceMustBe44()
        {
            const int expected = 44;
            var result = new EulerProblem002(89).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void TheSumOfEvenTermsInFibonacciSequenceWhoseValuesDoNotExceedFourMillionMustBe4613732()
        {
            const int expected = 4613732;
            var result = new EulerProblem002(4000000).Solve();
            result.Should().Be(expected);
        }
    }
}

using ProjectEuler.Problems;
using FluentAssertions;
using Xunit;

namespace ProjectEuler.Tests
{
    public class EulerProblem009Test
    {

        [Fact]
        public void TheProductOfTheAbcOfThePythagoreanTripletForWhichAPlusBPlusCEquals1000MustBe31875000()
        {
            const int expected = 31875000;
            var result = new EulerProblem009(1000).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void TheProductOfTheAbcOfThePythagoreanTripletForWhichAPlusBPlusCEquals12MustBe60()
        {
            const int expected = 60;
            var result = new EulerProblem009(12).Solve();
            result.Should().Be(expected);
        }

       

    }
}

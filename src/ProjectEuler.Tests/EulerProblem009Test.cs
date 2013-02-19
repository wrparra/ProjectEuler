using ProjectEuler.Problems;
using FluentAssertions;
using Xunit;

namespace ProjectEuler.Tests
{
    public class EulerProblem009Test
    {

        [Fact]
        public void The_product_of_the_abc_of_the_Pythagorean_triplet_for_which_a_plus_b_plus_c_equals_1000_must_be_31875000()
        {
            const int expected = 31875000;
            var result = new EulerProblem009(1000).Solve();
            result.Should().Be(expected);
        }

        [Fact]
        public void The_product_of_the_abc_of_the_Pythagorean_triplet_for_which_a_plus_b_plus_c_equals_12_must_be_60()
        {
            const int expected = 60;
            var result = new EulerProblem009(12).Solve();
            result.Should().Be(expected);
        }

       

    }
}

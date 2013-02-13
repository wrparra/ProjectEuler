using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Extensions;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Smallest multiple
    /// Problem 5
    /// 
    /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    /// </summary>
    /// <see cref="http://pt.wikipedia.org/wiki/Pal%C3%ADndromo"/>
    public class EulerProblem005 : IEulerProblem
    {
        private readonly IEnumerable<int> _range;

        public EulerProblem005(int start, int finish)
        {
            _range = start.To(finish);
        }

        /// <summary>
        /// The lowest integer that contains all the factors is defined by the product of
        /// all Lowest Common Multiplers (LCM) of all the factors.
        /// </summary>
        /// <returns></returns>
        public int Solve()
        {
            return (int)_range.CastToLong().Aggregate(MathExtensions.Lcm);
        }
    }
}

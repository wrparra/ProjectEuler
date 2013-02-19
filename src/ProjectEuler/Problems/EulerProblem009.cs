using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Extensions;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///Special Pythagorean triplet
    /// Problem 9
    /// 
    /// A Pythagorean triplet is a set of three natural numbers, a less b less c, for which, a² + b² = c²
    /// For example, 3² + 4² = 9 + 16 = 25 = 5².
    /// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    /// Find the product abc.
    /// </summary>
    public class EulerProblem009 : IEulerProblem
    {
        private readonly int _s;

        public EulerProblem009(int s)
        {
            _s = s;
        }

        public long Solve()
        {
            return MathExtensions.PythagoreanTriplet(_s).Product();
        }
        
    }
}

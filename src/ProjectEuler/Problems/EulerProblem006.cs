using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Extensions;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Sum square difference
    /// Problem 6
    /// 
    /// The sum of the squares of the first ten natural numbers is, 1² + 2² + ... + 10² = 385 
    /// The square of the sum of the first ten natural numbers is, (1 + 2 + ... + 10)² = 55² = 3025
    /// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 - 385 = 2640.
    /// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    /// </summary>
    public class EulerProblem006 : IEulerProblem
    {
        private readonly IEnumerable<int> _range;

        public EulerProblem006(int start, int finish)
        {
            _range = start.To(finish);
        }

        public int Solve()
        {
            return _range.Sum().Square() - _range.Sum(i => i.Square());
        }
    }
}

﻿using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Extensions;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Multiples of 3 and 5
    /// Problem 1
    /// 
    /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    /// 
    /// Find the sum of all the multiples of 3 or 5 below 1000.
    /// </summary>
    public class EulerProblem001 : IEulerProblem
    {
        private readonly IEnumerable<int> _range;

        public EulerProblem001(int start, int finish)
        {
            _range = start.To(finish);
        }

        public EulerProblem001() : this(1, 999) { }

        public long Solve()
        {
            return _range.Where(n => n % 3 == 0 || n % 5 == 0).Sum();
        }
    }
}

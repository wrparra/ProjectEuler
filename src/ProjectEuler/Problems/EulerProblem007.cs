using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Extensions;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// 10001st prime
    /// Problem 7
    /// 
    /// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
    /// What is the 10 001st prime number?
    /// </summary>
    public class EulerProblem007 : IEulerProblem
    {
        private readonly int _count;

        public EulerProblem007(int count)
        {
            _count = count;
        }

        public int Solve()
        {
            return (int)MathExtensions.PrimeNumbers().Take(_count).Last();
        }
    }
}

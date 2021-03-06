﻿using System.Linq;
using ProjectEuler.Collections;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Summation of primes
    /// Problem 10
    /// 
    /// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
    /// Find the sum of all the primes below two million.
    /// </summary>
    public class EulerProblem010 : IEulerProblem
    {
        private readonly int _limit;

        public EulerProblem010(int limit)
        {
            _limit = limit;
        }

        public long Solve()
        {
            return new PrimeNumbers(_limit).SieveOfEratosthenes().Sum();
        }
        
    }
}

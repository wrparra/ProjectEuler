﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectEuler.Collections;
using ProjectEuler.Extensions;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Largest prime factor
    /// Problem 3
    /// 
    /// The prime factors of 13195 are 5, 7, 13 and 29.
    /// 
    /// What is the largest prime factor of the number 600851475143 ?
    /// </summary>
    /// <see cref="http://pt.wikipedia.org/wiki/N%C3%BAmero_primo"/>
    public class EulerProblem003 : IEulerProblem
    {
        private readonly ulong _number;

        public EulerProblem003(ulong number)
        {
            _number = number;
        }

        public int Solve()
        {
            return (int)MathExtensions.PrimeNumbers().Factorize(_number).Max();
        }
    }
}
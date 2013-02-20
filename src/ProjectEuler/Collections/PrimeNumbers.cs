using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjectEuler.Collections
{
    public class PrimeNumbers
    {
        private readonly int _limit;

        public PrimeNumbers(int limit)
        {
            _limit = limit;
        }

        #region Sieve Of Eratosthenes

        public long[] SieveOfEratosthenes()
        {
            var sieveBound = (_limit - 1) / 2;
            var upperSqrt = ((int)Math.Sqrt(_limit) - 1) / 2;

            var primeBits = new BitArray(sieveBound + 1, true);

            for (var i = 1; i <= upperSqrt; i++)
            {
                if (primeBits.Get(i))
                {
                    for (var j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
                    {
                        primeBits.Set(j, false);
                    }
                }
            }

            var capacity = (int)(_limit / (Math.Log(_limit) - 1.08366));
            var numbers = new List<long>(capacity) { 2 };
            for (var i = 1; i <= sieveBound; i++)
            {
                if (primeBits.Get(i))
                    numbers.Add(2 * i + 1);
            }

            return numbers.ToArray();
        }

        #endregion
        
        #region Sieve of Atkin
        
        public long[] SieveOfAtkin()
        {
            var primeBits = new BitArray(_limit + 1, false);
            var upperSqrt = (int)Math.Sqrt(_limit);

            for (var i = 1; i <= upperSqrt; i++)
            {
                for (var j = 1; j <= upperSqrt; j++)
                {
                    var n = 4 * i * i + j * j;

                    if (n <= _limit && (n % 12 == 1 || n % 12 == 5))
                        primeBits.Set(n, !primeBits.Get(n));

                    n = 3 * i * i + j * j;
                    
                    if (n <= _limit && (n % 12 == 7))
                        primeBits.Set(n, !primeBits.Get(n));

                    n = 3 * i * i - j * j;
                    
                    if (i > j && n <= _limit && (n % 12 == 11))
                        primeBits.Set(n, !primeBits.Get(n));
                }
            }

            for (var i = 5; i <= upperSqrt; i++)
            {
                if (primeBits.Get(i))
                {
                    for (var j = i * i; j <= _limit; j += i * i)
                    {
                        primeBits.Set(j, false);
                    }
                }
            }

            var numbers = new List<long> {2, 3};
            for (var i = 5; i <= _limit; i += 2)
            {
                if (primeBits.Get(i))
                    numbers.Add(i);
            }

            return numbers.ToArray();
        }

        #endregion
    }
}

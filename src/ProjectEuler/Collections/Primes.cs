using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Collections
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="http://stackoverflow.com/questions/1042902/most-elegant-way-to-generate-prime-numbers"/>
    public class Primes
    {
        private readonly int _limit;

        public Primes(int limit)
        {
            _limit = limit;
        }

        public IEnumerable<int> GeneratePrimes()
        {
            throw new NotImplementedException();
        }

        #region Standard


        public static List<int> GeneratePrimesNaive(int n)
        {
            List<int> primes = new List<int>();
            primes.Add(2);
            int nextPrime = 3;
            while (primes.Count < n)
            {
                int sqrt = (int)Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; (int)primes[i] <= sqrt; i++)
                {
                    if (nextPrime % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(nextPrime);
                }
                nextPrime += 2;
            }
            return primes;
        }

        #endregion

        #region Sieve Of Eratosthenes

        public static int ApproximateNthPrime(int nn)
        {
            double n = nn;
            double p;
            if (nn >= 7022)
            {
                p = n * Math.Log(n) + n * (Math.Log(Math.Log(n)) - 0.9385);
            }
            else if (nn >= 6)
            {
                p = n * Math.Log(n) + n * Math.Log(Math.Log(n));
            }
            else if (nn > 0)
            {
                p = new[] { 2, 3, 5, 7, 11 }[nn - 1];
            }
            else
            {
                p = 0;
            }
            return (int)p;
        }

        // Find all primes up to and including the limit
        public static BitArray SieveOfEratosthenes(int limit)
        {
            var bits = new BitArray(limit + 1, true);
            bits[0] = false;
            bits[1] = false;
            for (var i = 0; i * i <= limit; i++)
            {
                if (bits[i])
                {
                    for (var j = i * i; j <= limit; j += i)
                    {
                        bits[j] = false;
                    }
                }
            }
            return bits;
        }

        public static List<int> GeneratePrimesSieveOfEratosthenes(int n)
        {
            var limit = ApproximateNthPrime(n);
            var bits = SieveOfEratosthenes(limit);
            var primes = new List<int>();
            for (int i = 0, found = 0; i < limit && found < n; i++)
            {
                if (bits[i])
                {
                    primes.Add(i);
                    found++;
                }
            }
            return primes;
        }

        #endregion

        #region Sieve of Sundaram

        public static BitArray SieveOfSundaram(int limit)
        {
            limit /= 2;
            var bits = new BitArray(limit + 1, true);
            for (var i = 1; 3 * i + 1 < limit; i++)
            {
                for (var j = 1; i + j + 2 * i * j <= limit; j++)
                {
                    bits[i + j + 2 * i * j] = false;
                }
            }
            return bits;
        }

        public static List<int> GeneratePrimesSieveOfSundaram(int n)
        {
            var limit = ApproximateNthPrime(n);
            var bits = SieveOfSundaram(limit);
            var primes = new List<int> {2};
            for (int i = 1, found = 1; 2 * i + 1 <= limit && found < n; i++)
            {
                if (bits[i])
                {
                    primes.Add(2 * i + 1);
                    found++;
                }
            }
            return primes;
        }

        #endregion
        
    }
}

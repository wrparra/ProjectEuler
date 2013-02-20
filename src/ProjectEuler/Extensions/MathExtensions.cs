using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProjectEuler.Extensions
{
    public static class MathExtensions
    {
        #region Prime Numbers

        public static IEnumerable<long> PrimeNumbers()
        {
            return Numbers(i => i == 2 || i.IsPrime());
        }
        
        /// <summary>
        /// Verifica se o número informado é um número Primo
        /// </summary>
        public static bool IsPrime(this long number)
        {
            if (number == 0) return false;
            if (number == 1) return false;
            if (number == 2) return true;
            if (number == 3) return true;
            if (number.IsEven()) return false;

            for (long i = 3; i <= Math.Sqrt(number); i += 2)
                if (number.IsMultipleOf(i)) return false;

            return true;
        }

        public static IEnumerable<long> Factorize(this IEnumerable<long> primes, long number)
        {
            return primes.TakeWhile(i => i <= Math.Sqrt(number)).Where(i => number % i == 0);
        }

        #endregion

        #region Fibonacci

        /// <summary>
        /// A sucessão de Fibonacci ou sequência de Fibonacci é uma sequência de números naturais, 
        /// na qual os primeiros dois termos são 0 e 1, e cada termo subsequente corresponde à soma dos dois precedentes.
        /// </summary>
        /// <see cref="http://pt.wikipedia.org/wiki/N%C3%BAmero_de_Fibonacci"/>
        /// <seealso cref="http://en.wikibooks.org/wiki/Fibonacci_number_program"/>
        /// <param name="number">Indíce da sequência a ser calculado</param>
        public static int Fibonacci(int number)
        {
            return (number < 2) ? number : Fibonacci(number - 1) + Fibonacci(number - 2);
        }

        /// <summary>
        /// Método para cálculo de números da sequência de Fibonacci utilizando "Memoization".
        /// A idéia por trás memoização é acelerar os programas, evitando cálculos repetitivos para as entradas de função processadas anteriormente. 
        /// </summary>
        public static int FibonacciMemoized(int number)
        {
            Func<int, int> fib = null;
            fib = new Func<int, int>(n => n < 2 ? n : fib(n - 1) + fib(n - 2)).Memoize();
            return fib(number);
        }

        /// <summary>
        /// Generate infinite fibonacci lazy list
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> FibonacciNumbers(int start = 0)
        {
            var count = start;
            while (true)
            {
                yield return FibonacciMemoized(count++);
            }
        }

        #endregion

        #region Palindromes

        public static bool IsPalindrome(this int number)
        {
            return number == number.Reverse();
        }

        public static int Reverse(this int number)
        {
            var result = 0;
            while (number > 0)
            {
                result = (result * 10) + (number % 10);
                number /= 10;
            }
            return result;
        }

        #endregion

        #region Numbers
       
        public static bool IsEven(this long number)
        {
            return number % 2 == 0;
        }

        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }

        public static bool IsOdd(this long number)
        {
            return number % 2 != 0;
        }

        public static bool IsOdd(this int number)
        {
            return number % 2 != 0;
        }

        public static bool IsMultipleOf(this long number, long multiple)
        {
            return number % multiple == 0;
        }

        public static bool IsMultipleOf(this int number, int multiple)
        {
            return number % multiple == 0;
        }

        public static IEnumerable<long> Numbers(Predicate<long> predicate, long start = 0)
        {
            var index = start;
            while (true)
            {
                if (predicate.Invoke(index))
                    yield return index;

                index++;
            }
        }

        public static IEnumerable<long> EvenNumbers(long start = 0, long limit = long.MaxValue)
        {
            return Numbers(i => i.IsEven(), start).TakeWhile(i => i < limit);
        }

        public static IEnumerable<long> OddNumbers(long start = 0, long limit = long.MaxValue)
        {
            return Numbers(i => i.IsOdd(), start).TakeWhile(i => i < limit);
        }

        public static int Square(this int number)
        {
            return (int) Math.Pow(number, 2);
        }

        #endregion

        #region GCD & LCM
        
        /// <summary>
        /// Find the Greatest Common Divisor
        /// </summary>
        public static long Gcd(long a, long b)
        {
            while (b != 0)
            {
                var remainder = a % b;
                a = b;
                b = remainder;
            }

            return a;
        }

        /// <summary>
        /// Find the Least Common Multiple
        /// </summary>
        public static long Lcm(long a, long b)
        {
            return (a * b) / Gcd(a, b);
        }
        
        #endregion

        #region Pythagorean Triplet

        public static int[] PythagoreanTriplet(int sumLimit)
        {
            int a = 0, b = 0, c = 0;
            int s = sumLimit;
            bool found = false;
            for (a = 1; a < s / 3; a++)
            {
                for (b = a; b < s / 2; b++)
                {
                    c = s - a - b;

                    if ((a * a + b * b == c * c) && (a < b && b < c))
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    break;
                }
            }

            return new[] { a, b, c };
        }

        #endregion

        /// <summary>
        /// Em computação, memoização é uma técnica de otimização usada principalmente para acelerar programas de computador 
        /// evitando a repetição de cálculos já processados anteriormente. 
        /// </summary>
        /// <see cref="http://en.wikipedia.org/wiki/Memoization"/>
        /// <seealso cref="http://codebetter.com/matthewpodwysocki/2008/08/01/recursing-into-recursion-memoization/"/>
        /// <seealso cref="http://blogs.msdn.com/b/wesdyer/archive/2007/01/26/function-memoization.aspx"/>
        /// <seealso cref="http://elemarjr.net/2012/01/05/produzindo-codigo-mais-elegante-com-combinators-em-c/"/>
        /// <seealso cref="http://elemarjr.net/2011/11/17/functional-programming-memoization-em-javascript/"/>
        public static Func<T, TResult> Memoize<T, TResult>(this Func<T, TResult> func)
        {
            var memo = new Dictionary<T, TResult>();
            return n =>
            {
                if (memo.ContainsKey(n))
                    return memo[n];

                var result = func(n);
                memo.Add(n, result);
                return result;
            };
        }
    }
}

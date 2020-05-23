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
        public static int Fibonacci(this int number)
        {
            return (number < 2) ? number : Fibonacci(number - 1) + Fibonacci(number - 2);
        }

        /// <summary>
        /// Método para cálculo de números da sequência de Fibonacci utilizando "Memoization".
        /// A idéia por trás memoização é acelerar os programas, evitando cálculos repetitivos para as entradas de função processadas anteriormente. 
        /// </summary>
        public static int MemoizedFibonacci(this int number)
        {
            Func<int, int> fib = null;
            fib = new Func<int, int>(n => n < 2 ? n : fib(n - 1) + fib(n - 2)).Memoize();
            return fib(number);
        }


        /// <summary>
        /// Fibonacci Binets Formula
        /// https://stackoverflow.com/questions/1525521/nth-fibonacci-number-in-sublinear-time
        /// https://elemarjr.wordpress.com/2014/04/01/fibonacci-na-velocidade-da-luz-binets-formula/
        /// </summary>
        public static int BinetFibonacci(this int nth)
        {
            if (nth < 2)
                return nth;

            //const double inverseSqrt5 = 0.44721359549995793928183473374626;
            //const double phi = 1.6180339887498948482045868343656;
            double sqrt5 = Math.Sqrt(5);
            double inverseSqrt5 = 1 / sqrt5;
            double phi = (1 + sqrt5) / 2;

            return (int)Math.Abs(Math.Pow(phi, nth) * inverseSqrt5 + 0.5);
        }

        public static int IterativeFibonacci(this int n)
        {
            if (n < 2)
                return n;

            var i = 1;
            var a = 0;
            var b = 0;
            var c = 1;

            while (i < n)
            {
                a = b;
                b = c;
                c = a + b;
                i++;
            }

            return c;
        }

        /// <summary>
        /// Divide And Conquer Fibonacci
        /// </summary>
        public static int DivideAndConquerFibonacci(this int n)
        {
            if (n < 2)
                return n;

            var i = n - 1;
            var a = 1d;
            var b = 0d;
            var c = 0d;
            var d = 1d;
            var aux1 = 0d;
            var aux2 = 0d;
            while (i > 0)
            {
                if (i.IsOdd())
                {
                    aux1 = d * b + c * a;
                    aux2 = d * (b + a) + c * b;
                    a = aux1;
                    b = aux2;
                }

                aux1 = Math.Pow(c, 2) + Math.Pow(d, 2);
                aux2 = d * (2 * c + d);
                c = aux1;
                d = aux2;
                i = i / 2;
            }

            return (int)Math.Abs(a + b);
        }

        /// <summary>
        /// Generate infinite fibonacci lazy list
        /// </summary>
        public static IEnumerable<int> FibonacciNumbers(int start = 0)
        {
            var count = start;
            while (true)
            {
                //yield return Fibonacci(count++);
                //yield return FibonacciMemoized(count++);
                //yield return BinetFibonacci(count++);
                //yield return DivideAndConquerFibonacci(count++);
                yield return IterativeFibonacci(count++);
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

        /// <summary>
        /// É Par
        /// </summary>
        public static bool IsEven(this long number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// É Par
        /// </summary>
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// É Ímpar
        /// </summary>
        public static bool IsOdd(this long number)
        {
            return number % 2 != 0;
        }

        /// <summary>
        /// É Ímpar
        /// </summary>
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
            return (int)Math.Pow(number, 2);
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

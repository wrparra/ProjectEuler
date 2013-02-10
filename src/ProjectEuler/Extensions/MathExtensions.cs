using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Extensions
{
    public static class MathExtensions
    {
        public static IEnumerable<ulong> PrimeNumbers()
        {
            //ulong number = 2;
            //while (true)
            //{
            //    if (number.IsPrime())
            //        yield return number;

            //    number++;
            //}

            return Numbers(i => i == 2 || i.IsPrime());
        }

        /// <summary>
        /// Verifica se o número informado é um número Primo
        /// </summary>
        public static bool IsPrime(this ulong number)
        {
            if (number == 0) return false;
            if (number == 1) return false;
            if (number == 2) return true;
            if (number == 3) return true;
            if (number.IsEven()) return false;

            for (ulong i = 3; i <= Math.Sqrt(number); i += 2)
                if (number.IsMultipleOf(i)) return false;

            return true;
        }

        public static bool IsEven(this ulong number)
        {
            return number % 2 == 0;
        }

        public static bool IsOdd(this ulong number)
        {
            return number % 2 != 0;
        }

        public static bool IsMultipleOf(this ulong number, ulong multiple)
        {
            return number % multiple == 0;
        }

        public static IEnumerable<ulong> Numbers(Predicate<ulong> predicate, ulong start = 0)
        {
            var index = start;
            while (true)
            {
                if (predicate.Invoke(index))
                    yield return index;

                index++;
            }
        }

        public static IEnumerable<ulong> EvenNumbers(ulong start = 0, ulong limit = ulong.MaxValue)
        {
            return Numbers(i => i.IsEven(), start).TakeWhile(i => i < limit);
        }

        public static IEnumerable<ulong> OddNumbers(ulong start = 0, ulong limit = ulong.MaxValue)
        {
            return Numbers(i => i.IsOdd(), start).TakeWhile(i => i < limit);
        }

        public static IEnumerable<ulong> Factorize(this IEnumerable<ulong> primes, ulong number)
        {
            return primes.TakeWhile(i => i <= Math.Sqrt(number)).Where(i => number % i == 0);
        }

        /// <summary>
        /// A sucessão de Fibonacci ou sequência de Fibonacci é uma sequência de números naturais, 
        /// na qual os primeiros dois termos são 0 e 1, e cada termo subsequente corresponde à soma dos dois precedentes.
        /// </summary>
        /// <see cref="http://pt.wikipedia.org/wiki/N%C3%BAmero_de_Fibonacci"/>
        /// <param name="index">Indíce da sequência a ser calculado</param>
        public static int Fibonacci(int index)
        {
            if (index == 0) return 0;
            if (index == 1) return 1;
            return Fibonacci(index - 1) + Fibonacci(index - 2);
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
                yield return Fibonacci(count++);
            }
        }

    }
}

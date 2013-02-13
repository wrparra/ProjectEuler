using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Extensions
{
    public static class CollectionsExtensions
    {
        /// <summary>
        /// Initializes a new Range that starts at <paramref name="start"/> and ends at <paramref name="finish"/>.
        /// </summary>
        /// <param name="start">The starting value of the range.</param>
        /// <param name="finish">The ending value of the range.</param>
        public static IEnumerable<int> To(this int start, int finish)
        {
            var count = (finish - start) + 1;
            return Enumerable.Range(start, count);
        }
        
        /// <summary>
        /// Initializes a new Range that starts at <paramref name="start"/> and ends at <paramref name="finish"/>.
        /// </summary>
        /// <param name="start">The starting value of the range.</param>
        /// <param name="finish">The ending value of the range.</param>
        public static IEnumerable<long> To(this long start, long finish)
        {
            var count = (finish - start) + 1;
            for (var i = start; i <= count; i++)
            {
                yield return i;
            }
        }

        /// <summary>
        /// Casts the elements of an System.Collections.IEnumerable of int to the long type.
        /// </summary> 
        public static IEnumerable<long> CastToLong(this IEnumerable<int> source)
        {
            return source.Select(i => (long)i);
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true.
        /// </summary>
        /// <see cref="http://stackoverflow.com/questions/4334375/how-to-get-the-item-before-current-and-after-current-in-a-list-with-linq-c"/>
        /// <seealso cref="http://stackoverflow.com/questions/3683105/calculate-difference-from-previous-item-with-linq"/>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence to return elements from.</param>
        /// <param name="predicate">A function to test each previous and current elements for a condition.</param>
        /// <returns>An System.Collections.Generic.IEnumerable that contains the elements from the input sequence that occur before the element at which the test no longer passes.</returns>
        /// <exception>System.ArgumentNullException: source or predicate is null."></exception>
        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Func<T, T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (predicate == null)
                throw new ArgumentNullException("predicate");

            // Actually yield "the previous two" as well as the current one - this
            // is easier to implement than "previous and next" but they're equivalent
            using (var iterator = source.GetEnumerator())
            {
                if (!iterator.MoveNext())
                {
                    yield break;
                }
                var previous = iterator.Current;
                if (!iterator.MoveNext())
                {
                    yield break;
                }
                var current = iterator.Current;
                while (iterator.MoveNext() && predicate(previous, current))
                {
                    yield return previous;
                    previous = current;
                    current = iterator.Current;
                }
                yield return previous;
                yield return current;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Extensions
{
    public static class CollectionsExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <see cref="http://stackoverflow.com/questions/4334375/how-to-get-the-item-before-current-and-after-current-in-a-list-with-linq-c"/>
        /// <seealso cref="http://stackoverflow.com/questions/3683105/calculate-difference-from-previous-item-with-linq"/>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Func<T, T, bool> predicate)
        {
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

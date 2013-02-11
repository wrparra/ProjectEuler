using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Collections;
using ProjectEuler.Extensions;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Largest palindrome product
    /// Problem 4
    /// 
    /// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 99.
    /// Find the largest palindrome made from the product of two 3-digit numbers.
    /// </summary>
    /// <see cref="http://pt.wikipedia.org/wiki/Pal%C3%ADndromo"/>
    public class EulerProblem004 : IEulerProblem
    {
        private readonly IEnumerable<int> _range;

        public EulerProblem004(int start, int finish)
        {
            _range = new Range(start, finish).Reverse();
        }

        public int Solve()
        {
            //brute-force
            //return (from n in _range from x in _range let p = (n * x) where p.IsPalindrome() select p).Distinct().Max();
            
            //optimized
            return Palindromes().Max();
        }

        /// <summary>
        /// Optimized way to generate Palindromic Numbers
        /// </summary>
        public IEnumerable<int> Palindromes()
        {
            var higherX = 0;

            foreach (var n in _range)
            {
                foreach (var x in _range)
                {
                    var p = n * x;
                    if (p.IsPalindrome() && higherX < x)
                    {
                        yield return p;
                        higherX = x;
                        break;
                    }
                }
            }
        }
    }
}

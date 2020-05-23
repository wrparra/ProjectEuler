using ProjectEuler.Extensions;
using System;
using System.Diagnostics;
using System.Linq;

namespace ProjectEuler.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var nth = 46;
            var stopWatch = new Stopwatch();
            var elapsedTime = new TimeSpan();
            var fib = 0L;

            do
            {
                // stopWatch.Restart();
                // fib = nth.Fibonacci();
                // stopWatch.Stop();
                // elapsedTime = stopWatch.Elapsed;
                // Console.WriteLine("Recursive Fibonacci {0} RunTime: {1}ms", fib, elapsedTime.TotalMilliseconds);

                stopWatch.Restart();
                fib = nth.MemoizedFibonacci();
                stopWatch.Stop();
                elapsedTime = stopWatch.Elapsed;
                Console.WriteLine("Memoized Fibonacci {0} RunTime: {1}ms", fib, elapsedTime.TotalMilliseconds);

                stopWatch.Restart();
                fib = nth.DivideAndConquerFibonacci();
                stopWatch.Stop();
                elapsedTime = stopWatch.Elapsed;
                Console.WriteLine("DivideAndConquer Fibonnaci {0} RunTime: {1}ms", fib, elapsedTime.TotalMilliseconds);

                stopWatch.Restart();
                fib = nth.IterativeFibonacci();
                stopWatch.Stop();
                elapsedTime = stopWatch.Elapsed;
                Console.WriteLine("Iterative Fibonnaci {0} RunTime: {1}ms", fib, elapsedTime.TotalMilliseconds);

                stopWatch.Restart();
                fib = nth.BinetFibonacci();
                stopWatch.Stop();
                elapsedTime = stopWatch.Elapsed;
                Console.WriteLine("Binets Fibonacci {0} RunTime: {1}ms", fib, elapsedTime.TotalMilliseconds);

            } while (Console.ReadLine() != "q");

        }
    }
}

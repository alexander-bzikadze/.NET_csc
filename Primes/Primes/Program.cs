using System;
using System.Numerics;
using System.Threading;

namespace Primes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var primeGetter = new PrimeGetter();
            BigInteger i;
            do
            {
                i = BigInteger.Parse(Console.ReadLine());
                var primeResultGetter = new PrimeResultGetter();
                primeGetter.GetPrime(primeResultGetter, new PrimeArgs(i));
                Thread.Sleep(100);
                Console.WriteLine(primeResultGetter.IsPrime);
            } while (i != 0);
        }
    }
}
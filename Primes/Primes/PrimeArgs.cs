using System;
using System.Numerics;
using System.Threading;

namespace Primes
{
    public class PrimeArgs : EventArgs
    {
        public PrimeArgs(BigInteger isItPrime)
        {
            IsItPrime = isItPrime;
        }
        
        public BigInteger IsItPrime { get; }
    }
}
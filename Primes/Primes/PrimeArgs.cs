using System;
using System.Numerics;

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
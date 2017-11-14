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

        public CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();
        public BigInteger IsItPrime { get; }
    }
}
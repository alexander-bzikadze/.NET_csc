using System.Collections.Generic;
using System.Numerics;
using System.Threading;

namespace Primes
{
    public class PrimeLogic
    {
        private List<CancellationTokenSource> cancelSource = new List<CancellationTokenSource>();

        public void RunEvaluation(BigInteger value, PrimeForm primeForm)
        {
            var primeResultGetter = new PrimeResultGetter(cancelSource.Count, primeForm);
            var (_, cancellationTokenSource) = primeGetter.GetPrime(primeResultGetter, new PrimeArgs(value));
            cancelSource.Add(cancellationTokenSource);
        }

        public void CancelEvaluation(int value)
        {
            if (value < cancelSource.Count)
            {
                cancelSource[value].Cancel();
            }
        }

        PrimeGetter primeGetter = new PrimeGetter();
    }
}

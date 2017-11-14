using System.Collections.Generic;
using System.Numerics;
using System.Threading;

namespace Primes
{
    public class PrimeLogic
    {
        private readonly List<CancellationTokenSource> _cancelSource = new List<CancellationTokenSource>();

        public void RunEvaluation(BigInteger value, PrimeForm primeForm)
        {
            var primeResultGetter = new PrimeResultGetter(_cancelSource.Count, primeForm);
            var (_, cancellationTokenSource) = _primeGetter.GetPrime(primeResultGetter, new PrimeArgs(value));
            _cancelSource.Add(cancellationTokenSource);
        }

        public void CancelEvaluation(int value)
        {
            if (value < _cancelSource.Count)
            {
                _cancelSource[value].Cancel();
            }
        }

        private readonly PrimeGetter _primeGetter = new PrimeGetter();
    }
}

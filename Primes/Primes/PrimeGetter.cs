using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Primes
{
    public class PrimeGetter
    {
        public (Task, CancellationTokenSource) GetPrime(object sender, PrimeArgs args)
        {
            if (!(sender is PrimeResultGetter result))
            {
                throw new ArgumentException("sender is not PrimeResultGetter!");
            }
            result.Number = args.IsItPrime;
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            var task = Task.Run(() =>
                {
                    result.StartedEvaluation = true;
                    result.IsPrime = result.Number >= 1 && CalculatePrime(args.IsItPrime, result, cancellationToken);
                    result.IsEvaluated = true;
                }, cancellationToken)
                .ContinueWith(_ => result.IsCanceled = true, TaskContinuationOptions.OnlyOnCanceled);
            return (task, cancellationTokenSource);
        }

        private static bool CalculatePrime(BigInteger x, PrimeResultGetter result, CancellationToken cancellationToken)
        {
            if (x < 1)
            {
                throw new ArgumentException("Argument should be positive!");
            }
            if (x == 1) // 1 is not a prime number
            {
                return false;
            }

            var upperBound = Math.Sqrt((double) x);
            
            for (var i = 2L; i <= upperBound; ++i)
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (x % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
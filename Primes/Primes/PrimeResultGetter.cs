using System.Numerics;

namespace Primes
{
    public class PrimeResultGetter
    {
        public BigInteger Number { get; set; }
        public bool StartedEvaluation { get; set; }
        public bool IsEvaluated { get; set; }
        public bool IsPrime { get; set; }
        public double Progress { get; set; }
        public bool IsCanceled { get; set; }
    }
}
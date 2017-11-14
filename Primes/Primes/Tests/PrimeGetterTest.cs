using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Primes.Tests
{
    [TestFixture]
    public class PrimeGetterTest
    {
        [TestCase(1, ExpectedResult=false)]
        [TestCase(2, ExpectedResult=true)]
        [TestCase(3, ExpectedResult=true)]
        [TestCase(4, ExpectedResult=false)]
        [TestCase(5, ExpectedResult=true)]
        [TestCase(6, ExpectedResult=false)]
        [TestCase(7, ExpectedResult=true)]
        [TestCase(8, ExpectedResult=false)]
        [TestCase(9, ExpectedResult=false)]
        [TestCase(10, ExpectedResult=false)]
        [TestCase(17, ExpectedResult=true)]
        [TestCase(113, ExpectedResult=true)]
        public bool SimpleTest(int i)
        {
            var primeGetter = new PrimeGetter();
            var primeResultGetter = new PrimeResultGetter();
            
            primeGetter.GetPrime(primeResultGetter, new PrimeArgs(i));
            Thread.Sleep(50);
            
            Assert.IsTrue(primeResultGetter.IsEvaluated);
            return primeResultGetter.IsPrime;
        }
        
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(17)]
        [TestCase(113)]
        public void SimpleNoTimeTest(int i)
        {
            var primeGetter = new PrimeGetter();
            var primeResultGetter = new PrimeResultGetter();
            
            primeGetter.GetPrime(primeResultGetter, new PrimeArgs(i));
            
            // Is it correct to test that way that there is a task starting that need time?
            Assert.IsFalse(primeResultGetter.IsEvaluated);
        }
        
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(17)]
        [TestCase(113)]
        public async Task SimpleCancelTest(int i)
        {
            var primeGetter = new PrimeGetter();
            var primeResultGetter = new PrimeResultGetter();

            var (task, cancellationTokenSource) = primeGetter.GetPrime(primeResultGetter, new PrimeArgs(i));
            try
            {
                await task;
                cancellationTokenSource.Cancel();
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Cancelled");
            }

            Assert.IsTrue(primeResultGetter.IsCanceled || primeResultGetter.IsEvaluated);
        }

        [Test]
        public void NegativeTest()
        {
            var primeGetter = new PrimeGetter();
            for (var i = -100; i < 0; ++i)
            {
                var primeResultGetter = new PrimeResultGetter();
                primeGetter.GetPrime(primeResultGetter, new PrimeArgs(i));
                Thread.Sleep(20);
                Assert.IsTrue(primeResultGetter.IsEvaluated);
                Assert.IsFalse(primeResultGetter.IsPrime);
            }
        }

        [Test]
        public void ParallelEvaluationTest()
        {
            var primeGetter = new PrimeGetter();
            var valuePairs = Enumerable
                .Range(1, 500)
                .Select(i => new PrimeArgs(i))
                .Select(i => (new PrimeResultGetter(), i))
                .ToList();
            valuePairs.ForEach(x => primeGetter.GetPrime(x.Item1, x.Item2));
            Thread.Sleep(50);
            valuePairs.ForEach(x => Assert.IsTrue(x.Item1.IsEvaluated));
        }
    }
}
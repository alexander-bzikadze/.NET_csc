using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace Multithreading.Tests
{
    [TestFixture]
    public class PhilosophersTests
    {   
        [Test, Timeout(1000)]
        public void TestPhilosophers([Range( 2, 10, 2 )] int numberOfPhils)
        {
            var threads = new List<Thread>();
            var philosophers = new Philosophers(numberOfPhils);
            var numberOfStartedEathinPhils = 0;
            var numberOfFinishedEathinPhils = 0;
            for (var i = 0; i < numberOfPhils; ++i)
            {
                // Why resharper marks it as a problem?
                var i1 = i;
                threads.Add(new Thread(() =>
                {
                    var thread = new Thread(x => philosophers.StartEating((int) x));
                    thread.Start(i1);
                    Thread.Sleep(50);
                    thread.Join();
                    Interlocked.Increment(ref numberOfStartedEathinPhils);
                    thread = new Thread(x => philosophers.StopEating((int) x));
                    thread.Start(i1);
                    thread.Join();
                    Interlocked.Increment(ref numberOfFinishedEathinPhils);
                }));
                threads.Last().Start();
            }
            threads.ForEach(thread => thread.Join());
            
            Assert.AreEqual(numberOfPhils, numberOfStartedEathinPhils);
            Assert.AreEqual(numberOfPhils, numberOfFinishedEathinPhils);
        }

        [Test, Timeout(1000)]
        public void TestRandomPhilosophers([Range( 2, 10, 2 )] int numberOfPhils)
        {
            var threads = new List<Thread>();
            var philosophers = new Philosophers(numberOfPhils);
            var numberOfStartedEathinPhils = 0;
            var numberOfFinishedEathinPhils = 0;
            var random = new Random();
            for (var i = 0; i < numberOfPhils * 10; ++i)
            {
                var i1 = random.Next(0, numberOfPhils);
                threads.Add(new Thread(() =>
                {
                    var thread = new Thread(x => philosophers.StartEating((int) x));
                    thread.Start(i1);
                    Thread.Sleep(50);
                    thread.Join();
                    Interlocked.Increment(ref numberOfStartedEathinPhils);
                    thread = new Thread(x => philosophers.StopEating((int) x));
                    thread.Start(i1);
                    thread.Join();
                    Interlocked.Increment(ref numberOfFinishedEathinPhils);
                }));
                threads.Last().Start();
            }
            threads.ForEach(thread => thread.Join());
            
            Assert.AreEqual(numberOfPhils * 10, numberOfStartedEathinPhils);
            Assert.AreEqual(numberOfPhils * 10, numberOfFinishedEathinPhils);
        }
    }
}
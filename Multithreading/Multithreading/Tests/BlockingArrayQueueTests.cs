using System;
using System.Threading;
using NUnit.Framework;

namespace Multithreading.Tests
{
    [TestFixture(typeof(LockBasedBlockingArrayQueue<int>))]
    [TestFixture(typeof(LockFreeBlockingArrayQueue<int>))]
    public class BlockingArrayQueueTests<TQueueToTest> where TQueueToTest : IBlockingArrayQueue<int>, new()
    {
        private readonly TQueueToTest _queue;

        public BlockingArrayQueueTests()
        {
            _queue = new TQueueToTest();
        }

        [TearDown]
        public void Clear()
        {
            _queue.Clear();
        }

        [Test]
        public void TestAdd()
        {
            const int threadNumber = 20;
            var threads = new Thread[threadNumber];
            for (var i = 0; i < threadNumber; ++i)
            {
                threads[i] = new Thread(x => _queue.Enqueue((int) x));
                threads[i].Start(1);
            }
            for (var i = 0; i < threadNumber; ++i)
            {
                threads[i].Join();
            }
            Assert.AreEqual(threadNumber, _queue.Size());
        }

        [Test,  Timeout(2000)]
        public void TestAddAndDelete()
        {
            const int threadNumber = 50;
            var threads = new Thread[threadNumber];
            var threadsDelete = new Thread[threadNumber];
            for (var i = 0; i < threadNumber; ++i)
            {
                threads[i] = new Thread(x => _queue.Enqueue((int) x));
                threads[i].Start(1);
                threadsDelete[i] = new Thread(() => _queue.Dequeue());
                threadsDelete[i].Start();
            }
            for (var i = 0; i < threadNumber; ++i)
            {
                threads[i].Join();
                threadsDelete[i].Join();
            }
            Assert.AreEqual(0, _queue.Size());
        }

        [Test,  Timeout(2000)]
        public void TestDeleteAndAdd()
        {
            const int threadNumber = 50;
            var threads = new Thread[threadNumber];
            var threadsDelete = new Thread[threadNumber];
            for (var i = 0; i < threadNumber; ++i)
            {
                threadsDelete[i] = new Thread(() => _queue.Dequeue());
                threadsDelete[i].Start();
            }
            for (var i = 0; i < threadNumber; ++i)
            {
                threads[i] = new Thread(x => _queue.Enqueue((int) x));
                threads[i].Start(1);
            }
            for (var i = 0; i < threadNumber; ++i)
            {
                threads[i].Join();
            }
            for (var i = 0; i < threadNumber; ++i)
            {
                threadsDelete[i].Join();
            }
            Assert.AreEqual(0, _queue.Size());
        }
    }
}
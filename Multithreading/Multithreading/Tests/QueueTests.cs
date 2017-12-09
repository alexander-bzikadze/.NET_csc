using System;
using NUnit.Framework;

namespace Multithreading.Tests
{
    [TestFixture]
    public class QueueTests
    {
        private Queue<int> _queue;
        
        [SetUp]
        public void SetUp()
        {
            _queue = new Queue<int>(5);
        }

        [Test]
        public void TestSimpleAdd()
        {
            for (var i = 0; i < 1; ++i)
            {
                _queue.Enqueue(i);
            }
        }

        [Test]
        public void TestAdd()
        {
            for (var i = 0; i < _queue.BufferSize(); ++i)
            {
                _queue.Enqueue(i);
            }
        }

        [Test]
        public void TestAddTooMuch()
        {
            for (var i = 0; i < _queue.BufferSize(); ++i)
            {
                _queue.Enqueue(i);
            }
            Assert.Throws<InvalidOperationException>(() => _queue.Enqueue(5));
        }

        [Test]
        public void TestSimpleDelete()
        {
            for (var i = 0; i < 1; ++i)
            {
                _queue.Enqueue(i);
            }
            Assert.AreEqual(_queue.Dequeue(), 0);
        }

        [Test]
        public void TestDelete()
        {
            for (var i = 0; i < _queue.BufferSize(); ++i)
            {
                _queue.Enqueue(i);
            }
            
            for (var i = 0; i < _queue.BufferSize(); ++i)
            {
                Assert.AreEqual(_queue.Dequeue(), i);
            }
        }

        [Test]
        public void TestDeleteEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => _queue.Dequeue());
        }

        [Test]
        public void TestDeleteAfterFull()
        {
            for (var i = 0; i < _queue.BufferSize(); ++i)
            {
                _queue.Enqueue(i);
            }
            
            for (var i = 0; i < _queue.BufferSize(); ++i)
            {
                Assert.AreEqual(_queue.Dequeue(), i);
            }
            
            for (var i = 0; i < _queue.BufferSize(); ++i)
            {
                _queue.Enqueue(i);
            }
        }

        [Test]
        public void TestDeleteEmptyAfterFull()
        {
            for (var i = 0; i < _queue.BufferSize(); ++i)
            {
                _queue.Enqueue(i);
            }
            
            for (var i = 0; i < _queue.BufferSize(); ++i)
            {
                Assert.AreEqual(_queue.Dequeue(), i);
            }
            
            Assert.Throws<InvalidOperationException>(() => _queue.Dequeue());
        }

        [Test]
        public void TestAddFullAfterFull()
        {
            for (var i = 0; i < _queue.BufferSize(); ++i)
            {
                _queue.Enqueue(i);
            }
            
            for (var i = 0; i < _queue.BufferSize(); ++i)
            {
                Assert.AreEqual(_queue.Dequeue(), i);
            }
            
            for (var i = 0; i < _queue.BufferSize(); ++i)
            {
                _queue.Enqueue(i);
            }
            
            Assert.Throws<InvalidOperationException>(() => _queue.Enqueue(5));
        }
    }
}
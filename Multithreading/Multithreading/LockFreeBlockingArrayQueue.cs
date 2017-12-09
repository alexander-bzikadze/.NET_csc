using System.Threading;

namespace Multithreading
{
    public class LockFreeBlockingArrayQueue<T> : IBlockingArrayQueue<T>
    {
        private Queue<T> _queue;
        public const int BufferSize = 1000;

        private int _numberOfDone;
        private int _numberOfAll;

        public LockFreeBlockingArrayQueue()
        {
            _queue = new Queue<T>(BufferSize);
        }
        
        public IBlockingArrayQueue<T> Enqueue(T e)
        {
            while (!TryEnqueue(e).Item1)
            {
            }
            return this;
        }

        public (bool, IBlockingArrayQueue<T>) TryEnqueue(T e)
        {
            var currentNumber = _numberOfAll; 
            Interlocked.Increment(ref _numberOfAll);
            while (currentNumber > _numberOfDone)
            {
            }
            var success = _queue.Size() != _queue.BufferSize();
            if (success)
            {
                _queue.Enqueue(e);
            }
            Interlocked.Increment(ref _numberOfDone);
            return (success, this);
        }

        public T Dequeue()
        {
            var (success, value) = TryDequeue();
            while (!success)
            {
                (success, value) = TryDequeue();
            }
            return value;
        }

        public (bool, T) TryDequeue()
        {
            var currentNumber = _numberOfAll; 
            Interlocked.Increment(ref _numberOfAll);
            while (currentNumber > _numberOfDone)
            {
            }
            var d = default(T);
            var success = !_queue.Empty();
            if (success)
            {
                d = _queue.Dequeue();
            }
            Interlocked.Increment(ref _numberOfDone);
            return (success, d);
        }

        public string Mes { get; private set;  }

        public IBlockingArrayQueue<T> Clear()
        {
            var currentNumber = _numberOfAll; 
            Interlocked.Increment(ref _numberOfAll);
            while (currentNumber > _numberOfDone)
            {
            }
            _queue.Clear();
            Interlocked.Increment(ref _numberOfDone);
            return this;
        }

        public (bool, IBlockingArrayQueue<T>) TryClear()
        {
            var originalQueue = _queue;
            var modifiedQueue = new Queue<T>(_queue.BufferSize());
            Interlocked.CompareExchange(ref _queue, modifiedQueue, originalQueue);
            return (_queue == modifiedQueue, this);
        }

        public int Size => _queue.Size();
    }
}
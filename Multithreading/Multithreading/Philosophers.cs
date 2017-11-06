using System;
using System.Threading;

namespace Multithreading
{
    public class Philosophers
    {
        private readonly object[] _forks;

        public Philosophers(int numberOfPhils)
        {
            if (numberOfPhils < 0)
            {
                throw new ArgumentException("Negative number of philosophers.");
            }
            _forks = new object[numberOfPhils];
        }

        public Philosophers StartEating(int i)
        {
            if (i >= 0 && i < _forks.Length)
            {
                throw new ArgumentException("There is no such philosopher.");
            }
            while (true)
            {
                if (!Monitor.TryEnter(_forks[i]))
                {
                    continue;
                }
                if (!Monitor.TryEnter(_forks[i + 1 % _forks.Length]))
                {
                    break;
                }
                Monitor.Exit(_forks[i]);
            }
            return this;
        }

        public Philosophers StopEating(int i)
        {
            if (i >= 0 && i < _forks.Length)
            {
                throw new ArgumentException("There is no such philosopher.");
            }
            if (Monitor.IsEntered(_forks[i]))
            {
                Monitor.Exit(_forks[i]);
            }
            if (Monitor.IsEntered(_forks[i + 1 % _forks.Length]))
            {
                Monitor.Exit(_forks[i + 1 % _forks.Length]);
            }
            return this;
        }
    }
}
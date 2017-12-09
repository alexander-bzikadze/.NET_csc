using System;
using System.Linq;
using System.Threading;

namespace Multithreading
{
    public class Philosophers
    {
        private readonly object[] _forks;

        public Philosophers(int numberOfPhils)
        {
            if (numberOfPhils < 1)
            {
                throw new ArgumentException("Negative number of philosophers.");
            }
            _forks = Enumerable.Range(0, numberOfPhils).Select(_ => new object()).ToArray();
        }

        private void CheckArgument(int i)
        {
            if (i < 0 && i >= _forks.Length)
            {
                throw new ArgumentException("There is no such philosopher.");
            }
        }

        public Philosophers StartEating(int i)
        {
            CheckArgument(i);
            while (true)
            {
                try
                {
                    if (!Monitor.TryEnter(_forks[i]))
                    {
                        continue;
                    }
                    try
                    {
                        if (!Monitor.TryEnter(_forks[(i + 1) % _forks.Length]))
                        {
                            continue;
                        }
                        break;
                    }
                    finally
                    {
                        Monitor.Exit(_forks[(i + 1) % _forks.Length]);
                    }
                }
                finally
                {
                    Monitor.Exit(_forks[i]);
                }
            }
            return this;
        }

        public Philosophers StopEating(int i)
        {
            CheckArgument(i);
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
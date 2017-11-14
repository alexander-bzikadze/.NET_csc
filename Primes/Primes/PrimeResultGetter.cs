using System;
using System.Numerics;
using System.Windows.Forms;

namespace Primes
{
    public class PrimeResultGetter
    {
        private PrimeForm primeForm;
        delegate void StringAndNumberReturnVoidDelegate(int number, string text);

        public PrimeResultGetter() { }

        public PrimeResultGetter(int taskNumber, PrimeForm primeForm)
        {
            TaskNumber = taskNumber;
            this.primeForm = primeForm;
        }

        public int TaskNumber { get; set; }
        public BigInteger Number { get; set; }
        public bool StartedEvaluation
        {
            get => StartedEvaluation;
            set
            {
                if (value)
                {
                    if (primeForm.InvokeRequired)
                    {
                        StringAndNumberReturnVoidDelegate d = new StringAndNumberReturnVoidDelegate(primeForm.SetTextForTask);
                        primeForm.Invoke(d, new object[] { TaskNumber, string.Format("Task {1}: {0} is in progress.", Number, TaskNumber)});
                    }
                    else
                    {
                        primeForm.SetTextForTask(TaskNumber, string.Format("Task {1}: {0} is in progress.", Number, TaskNumber));
                    }
                }
            }
        }
        public bool IsEvaluated
        {
            get => IsEvaluated;
            set
            {
                if (value)
                {
                    if (primeForm.InvokeRequired)
                    {
                        StringAndNumberReturnVoidDelegate d = new StringAndNumberReturnVoidDelegate(primeForm.SetTextForTask);
                        primeForm.Invoke(d, new object[] { TaskNumber, string.Format("Task {2}: {0} is evaluated. Result: {1}.", Number, IsPrime, TaskNumber) });
                    }
                    else
                    {
                        primeForm.SetTextForTask(TaskNumber, string.Format("Task {2}: {0} is evaluated. Result: {1}.", Number, IsPrime, TaskNumber));
                    }
                }
            }
        }

        public bool IsPrime { get; set; }
        public bool IsCanceled
        {
            get => IsCanceled;
            set
            {
                if (value)
                {
                    if (primeForm.InvokeRequired)
                    {
                        StringAndNumberReturnVoidDelegate d = new StringAndNumberReturnVoidDelegate(primeForm.SetTextForTask);
                        primeForm.Invoke(d, new object[] { TaskNumber, string.Format("Task {1}: {0} is canceled.", Number, TaskNumber) });
                    }
                    else
                    {
                        primeForm.SetTextForTask(TaskNumber, string.Format("Task {1}: {0} is canceled.", Number, TaskNumber));
                    }
                }
            }
        }
    }
}
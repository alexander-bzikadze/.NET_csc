using System.Numerics;

namespace Primes
{
    public class PrimeResultGetter
    {
        private readonly PrimeForm _primeForm;

        private delegate void StringAndNumberReturnVoidDelegate(int number, string text);

        public PrimeResultGetter() { }

        public PrimeResultGetter(int taskNumber, PrimeForm primeForm = null)
        {
            TaskNumber = taskNumber;
            _primeForm = primeForm;
        }

        public int TaskNumber { get; set; }
        public BigInteger Number { get; set; }
        public bool StartedEvaluation
        {
            set
            {
                if (!value || _primeForm == null)
                {
                    return;
                }
                if (_primeForm.InvokeRequired)
                {
                    StringAndNumberReturnVoidDelegate d = _primeForm.SetTextForTask;
                    _primeForm.Invoke(d, TaskNumber, string.Format("Task {1}: {0} is in progress.", Number, TaskNumber));
                }
                else
                {
                    _primeForm.SetTextForTask(TaskNumber, string.Format("Task {1}: {0} is in progress.", Number, TaskNumber));
                }
            }
        }

        private bool _isEvaluated;
        public bool IsEvaluated
        {
            get => _isEvaluated;
            set
            {
                _isEvaluated = true;
                if (!value || _primeForm == null)
                {
                    return;
                }
                if (_primeForm.InvokeRequired)
                {
                    StringAndNumberReturnVoidDelegate d = _primeForm.SetTextForTask;
                    _primeForm.Invoke(d, TaskNumber, string.Format("Task {2}: {0} is evaluated. Result: {1}.", Number, IsPrime, TaskNumber));
                }
                else
                {
                    _primeForm.SetTextForTask(TaskNumber, string.Format("Task {2}: {0} is evaluated. Result: {1}.", Number, IsPrime, TaskNumber));
                }
            }
        }

        public bool IsPrime { get; set; }

        private bool _isCalceled;
        public bool IsCanceled
        {
            get => _isCalceled;
            set
            {
                _isCalceled = value;
                if (!value || _primeForm == null)
                {
                    return;
                }
                if (_primeForm.InvokeRequired)
                {
                    StringAndNumberReturnVoidDelegate d = _primeForm.SetTextForTask;
                    _primeForm.Invoke(d, TaskNumber, string.Format("Task {1}: {0} is canceled.", Number, TaskNumber));
                }
                else
                {
                    _primeForm.SetTextForTask(TaskNumber, string.Format("Task {1}: {0} is canceled.", Number, TaskNumber));
                }
            }
        }
    }
}
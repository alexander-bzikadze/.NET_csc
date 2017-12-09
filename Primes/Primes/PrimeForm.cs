using System;
using System.Numerics;
using System.Windows.Forms;

namespace Primes
{
    public partial class PrimeForm : Form
    {
        private readonly PrimeLogic _logic = new PrimeLogic();
        private readonly object _locker = new object();

        public PrimeForm()
        {
            InitializeComponent();
            listOfTasks.Sorted = false;
        }

        private void NewTaskEvaluation(object sender, EventArgs args)
        {
            BigInteger value;
            var textInTextBox = inputTextBox.Text;
            if (BigInteger.TryParse(textInTextBox, out value))
            {
                listOfTasks.Items.Add(string.Format("Task {1}: {0} waits a thread", value, listOfTasks.Items.Count));
                _logic.RunEvaluation(value, this);
            }
            else
            {
                inputTextBox.Text = $@"Cannot parse this value: {textInTextBox}!";
            }
        }

        private void TaskCanceled(object sender, EventArgs args)
        {
            string curItem = listOfTasks.SelectedItem.ToString();
            int index = listOfTasks.FindString(curItem);
            _logic.CancelEvaluation(index);
        }

        internal void SetTextForTask(int taskNumber, string v)
        {
            lock(_locker)
            {
                listOfTasks.Items.RemoveAt(taskNumber);
                listOfTasks.Items.Insert(taskNumber, v);
            }
        }
    }
}

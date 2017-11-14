using System;
using System.Numerics;
using System.Windows.Forms;

namespace Primes
{
    public partial class PrimeForm : Form
    {
        private PrimeLogic logic = new PrimeLogic();
        private object locker = new object();

        public PrimeForm()
        {
            InitializeComponent();
            listOfTasks.Sorted = false;
        }

        private void NewTaskEvaluation(object sender, EventArgs args)
        {
            var value = new BigInteger();
            var textInTextBox = inputTextBox.Text;
            if (BigInteger.TryParse(textInTextBox, out value))
            {
                listOfTasks.Items.Add(string.Format("Task {1}: {0} waits a thread", value, listOfTasks.Items.Count));
                logic.RunEvaluation(value, this);
            }
            else
            {
                inputTextBox.Text = string.Format("Cannot parse this value: {0}!", textInTextBox);
            }
        }

        private void TaskCanceled(object sender, EventArgs args)
        {
            string curItem = listOfTasks.SelectedItem.ToString();
            int index = listOfTasks.FindString(curItem);
            logic.CancelEvaluation(index);
        }

        internal void SetTextForTask(int taskNumber, string v)
        {
            lock(locker)
            {
                listOfTasks.Items.RemoveAt(taskNumber);
                listOfTasks.Items.Insert(taskNumber, v);
            }
        }
    }
}

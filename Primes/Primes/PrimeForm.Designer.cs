using System.ComponentModel;
using System.Windows.Forms;

namespace Primes
{
    partial class PrimeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.EnterNewValueButton = new System.Windows.Forms.Button();
            this.listOfTasks = new System.Windows.Forms.ListBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.canselTaskButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.27273F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.72727F));
            this.tableLayoutPanel1.Controls.Add(this.EnterNewValueButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listOfTasks, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.canselTaskButton, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.59091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.40909F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(438, 176);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // EnterNewValueButton
            // 
            this.EnterNewValueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EnterNewValueButton.Location = new System.Drawing.Point(3, 129);
            this.EnterNewValueButton.Name = "EnterNewValueButton";
            this.EnterNewValueButton.Size = new System.Drawing.Size(288, 44);
            this.EnterNewValueButton.TabIndex = 0;
            this.EnterNewValueButton.Text = "Enter new value from text box";
            this.EnterNewValueButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.EnterNewValueButton.UseVisualStyleBackColor = true;
            this.EnterNewValueButton.Click += new System.EventHandler(this.NewTaskEvaluation);
            // 
            // listOfTasks
            // 
            this.listOfTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listOfTasks.FormattingEnabled = true;
            this.listOfTasks.Location = new System.Drawing.Point(3, 3);
            this.listOfTasks.Name = "listOfTasks";
            this.listOfTasks.Size = new System.Drawing.Size(288, 108);
            this.listOfTasks.TabIndex = 1;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputTextBox.Location = new System.Drawing.Point(297, 3);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(138, 20);
            this.inputTextBox.TabIndex = 2;
            this.inputTextBox.Text = "Enter new task here!";
            // 
            // canselTaskButton
            // 
            this.canselTaskButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canselTaskButton.Location = new System.Drawing.Point(297, 129);
            this.canselTaskButton.Name = "canselTaskButton";
            this.canselTaskButton.Size = new System.Drawing.Size(138, 44);
            this.canselTaskButton.TabIndex = 3;
            this.canselTaskButton.Text = "Cancel current task from list of tasks";
            this.canselTaskButton.UseVisualStyleBackColor = true;
            this.canselTaskButton.Click += new System.EventHandler(this.TaskCanceled);
            // 
            // PrimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 200);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PrimeForm";
            this.Text = "PrimeForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ListBox listOfTasks;
        private Button EnterNewValueButton;
        private TextBox inputTextBox;
        private Button canselTaskButton;
    }
}
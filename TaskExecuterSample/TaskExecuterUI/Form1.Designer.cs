namespace TaskExecuterUI
{
    partial class TasksForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.TasksProgressBar = new System.Windows.Forms.ProgressBar();
            this.StartButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TasksProgressBar
            // 
            this.TasksProgressBar.Location = new System.Drawing.Point(46, 47);
            this.TasksProgressBar.Name = "TasksProgressBar";
            this.TasksProgressBar.Size = new System.Drawing.Size(485, 23);
            this.TasksProgressBar.TabIndex = 0;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(537, 47);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Enabled = false;
            this.CancelButton.Location = new System.Drawing.Point(618, 47);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // TasksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 115);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.TasksProgressBar);
            this.Name = "TasksForm";
            this.Text = "Task Executer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TasksForm_FormClosing);
            this.Load += new System.EventHandler(this.TasksForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar TasksProgressBar;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button CancelButton;
    }
}


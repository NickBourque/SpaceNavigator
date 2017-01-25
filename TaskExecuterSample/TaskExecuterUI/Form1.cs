using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TasksLib;

namespace TaskExecuterUI
{
    public partial class TasksForm : Form
    {
        Executor executer = new Executor();



        public TasksForm()
        {
            executer.ProgressChanged += new TasksLib.ProgressChangedEventHandler(Executer_ProgressChanged);
            executer.ProgressComplete += new TasksLib.ProgressCompleteEventHandler(Executer_ProgressComplete);
            InitializeComponent();
        }


        private void Executer_ProgressComplete()
        {
            if(StartButton.InvokeRequired)
            {
                MethodInvoker invoker = new MethodInvoker(delegate ()
                {
                    StartButton.Enabled = true;
                });

                StartButton.Invoke(invoker);
                
            }
            else
            {
                StartButton.Enabled = true;
            }




            StartButton.Enabled = true;
        }


        private void Executer_ProgressChanged(int progress)
        {
            if(TasksProgressBar.InvokeRequired)
            {
                MethodInvoker invoker = new MethodInvoker(delegate () {
                    //update progress bar
                    TasksProgressBar.Value = progress;
                });

                TasksProgressBar.Invoke(invoker);

            }
            else
            {
                //update progress bar
                TasksProgressBar.Value = progress;
            }
            
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Thread workerThread = new Thread(executer.DoSomethingThatTakesAWhile);
            workerThread.Name = "MyWorkerThread";
            workerThread.Start();
            StartButton.Enabled = false;
        }
    }
}

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
        Thread workerThread;



        public TasksForm()
        {
            executer.ProgressChanged += new TasksLib.ProgressChangedEventHandler(Executer_ProgressChanged);
            executer.ProgressComplete += new TasksLib.ProgressCompleteEventHandler(Executer_ProgressComplete);
            InitializeComponent();
        }


        private void Executer_ProgressComplete(object sender, EventArgs e)
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


        private void Executer_ProgressChanged(object sender, TasksLib.ProgressChangedEventArgs e)
        {
            if(TasksProgressBar.InvokeRequired)
            {
                MethodInvoker invoker = new MethodInvoker(delegate () {
                    //update progress bar
                    TasksProgressBar.Value = e.Progress;
                });

                TasksProgressBar.BeginInvoke(invoker);

            }
            else
            {
                //update progress bar
                TasksProgressBar.Value = e.Progress;
            }
            
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            workerThread = new Thread(executer.DoSomethingThatTakesAWhile);
            workerThread.Name = "MyWorkerThread";
            workerThread.Start();
            StartButton.Enabled = false;
            CancelButton.Enabled = true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //prematurely cancel workerThread
            //workerThread.Abort(); //don't do this!!!!!!!!

            executer.stopExecution = true; //do this instead

            StartButton.Enabled = true;
            CancelButton.Enabled = false;
        }

        private void TasksForm_Load(object sender, EventArgs e)
        {

        }

        private void TasksForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //close the workerThread, if it's active

            if(workerThread != null && workerThread.IsAlive) { 
                executer.stopExecution = true;
                workerThread.Join();
            }
        }
    }
}

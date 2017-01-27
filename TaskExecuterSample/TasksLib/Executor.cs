using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TasksLib
{
    public class Executor
    {
        public event ProgressChangedEventHandler ProgressChanged;
        public event ProgressCompleteEventHandler ProgressComplete;

        public bool stopExecution = false;

        public void DoSomethingThatTakesAWhile()
        {
            for(int i=1; i<=100; i++)
            {
                if (stopExecution) break;

                //do work
                Thread.Sleep(100);

                //broadcast that some work was done 
                //i.e. raise and event
                ProgressChanged(this, new ProgressChangedEventArgs(i));
                
            }

            //when for loop done, raise an event to broadcast that task is complete.
            if (!stopExecution)
            { 
                ProgressComplete(this, EventArgs.Empty);
            }

            stopExecution = false;

        }
    }
}

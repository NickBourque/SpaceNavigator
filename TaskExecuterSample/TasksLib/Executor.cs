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

        public void DoSomethingThatTakesAWhile()
        {
            for(int i=1; i<=100; i++)
            {
                //do work
                Thread.Sleep(100);

                //broadcast that some work was done 
                //i.e. raise and event
                ProgressChanged(i);
                
            }
            //when for loop done:
            ProgressComplete();
            
        }
    }
}

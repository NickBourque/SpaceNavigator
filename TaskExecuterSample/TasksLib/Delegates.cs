using System;

namespace TasksLib
{
    public delegate void ProgressChangedEventHandler(object sender, ProgressChangedEventArgs e);

    public delegate void ProgressCompleteEventHandler(object sender, EventArgs e);
}
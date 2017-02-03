using System;

namespace ChatLibrary
{
    /// <summary>
    /// Holds the incoming message.
    /// </summary>
    public class MessageReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Sets Message property to incoming message.
        /// </summary>
        /// <param name="message">The incoming message.</param>
        public MessageReceivedEventArgs(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Holds the incoming message.
        /// </summary>
        public string Message { get; }
    }
}

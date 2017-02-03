
namespace ChatLibrary
{
    /// <summary>
    /// Handles the event of receiving a message.
    /// </summary>
    /// <param name="sender">Client object</param>
    /// <param name="e">An incoming message</param>
    public delegate void MessageReceivedEventHandler(object sender, MessageReceivedEventArgs e);
}
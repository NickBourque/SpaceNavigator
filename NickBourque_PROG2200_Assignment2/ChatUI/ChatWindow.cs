using ChatLibrary;
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

namespace ChatUI
{
    public partial class ChatWindow : Form
    {
        Client Client = new Client();
        Thread ListeningThread;
        bool Connected;

        public ChatWindow()
        {
            Client.MessageReceived += new MessageReceivedEventHandler(Client_MessageReceived);
            InitializeComponent();
        }

        public void Client_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            if (ConversationTextBox.InvokeRequired)
            {
                MethodInvoker invoker = new MethodInvoker(delegate () {
                    //update convo
                    ConversationTextBox.AppendText("\r\nServer: " + e.Message);
                });

                ConversationTextBox.BeginInvoke(invoker);

            }
            else
            {
                //update convo
                ConversationTextBox.AppendText("\r\nServer: " + e.Message);
            }
            
            ConversationTextBox.AppendText("\nServer: " + e.Message);
        }

        private void ChatWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string message = MessageTextBox.Text;

            Client.SendMessage(message);
            ConversationTextBox.AppendText("\r\nYou: " + message);

            MessageTextBox.Clear();
        }

        private void ConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connected = Client.Connect();
            if (Connected)
            {
                Client.OpenStream();
                ListeningThread = new Thread(Client.ListenForMessages);
                ListeningThread.Name = "ListeningThread";
                ListeningThread.Start();
            }
            else
            {

            }
        }
    }
}

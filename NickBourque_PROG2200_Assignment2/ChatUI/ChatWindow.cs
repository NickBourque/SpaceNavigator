using ChatLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                    //update conversation
                    ConversationTextBox.AppendText("\r\nServer: " + e.Message);
                });

                ConversationTextBox.BeginInvoke(invoker);

            }
            else
            {
                //update conversation --> this will probably never happen.
                ConversationTextBox.AppendText("\r\nServer: " + e.Message);
            }
            
        }

        private void ChatWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (Connected)
            {
                try
                {
                    string message = MessageTextBox.Text;
                    Client.SendMessage(message);
                    ConversationTextBox.AppendText("\r\nYou: " + message);
                    MessageTextBox.Clear();
                }
                catch(IOException ioEx)
                {
                    DisplayErrorMessage("Uh oh! Your connection to the server was lost.");
                }
            }
            else
            {
                DisplayErrorMessage("Please connect to the server before trying to send a message.");
            }
        }

        private void ConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Connected)
            {
                Connected = Client.Connect();
                if (Connected)
                {
                    Client.OpenStream();
                    ListeningThread = new Thread(Client.ListenForMessages);
                    ListeningThread.Name = "ListeningThread";
                    ListeningThread.Start();
                    DisplayDialog("Connected Successfully!");
                }
                else
                {
                    DisplayErrorMessage("Could not establish a connection to the server. Please try again later.");
                }
            }
            else
            {
                DisplayErrorMessage("You're already connected, you silly goose.");
            }
        }


        private void DisplayErrorMessage(string message)
        {
            MessageBox.Show(this,
                message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }


        private void DisplayDialog(string message)
        {
            MessageBox.Show(this,
                message,
                "",
                MessageBoxButtons.OK,
                MessageBoxIcon.None);
        }

        private void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Connected)
            {
                
                Connected = Client.Disconnect();
                if (!Connected)
                {
                    DisplayDialog("Disconnected Successfully!");
                }
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Connected)
            {
                Connected = Client.Disconnect();
            }
            Environment.Exit(0);
        }

        private void ChatWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Connected)
            {
                Connected = Client.Disconnect();
            }
        }
    }
}

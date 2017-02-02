using ChatLibrary;
using System;
using System.IO;
using System.Threading;
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
                    Connected = Client.Disconnect();
                    StatusLabel.Text = "Closed";
                    StatusLabel.ForeColor = System.Drawing.Color.Red;
                    ConnectToolStripMenuItem.Enabled = true;
                    DisconnectToolStripMenuItem.Enabled = false;
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
                    ConnectToolStripMenuItem.Enabled = false;
                    DisconnectToolStripMenuItem.Enabled = true;
                    StatusLabel.Text = "Open";
                    StatusLabel.ForeColor = System.Drawing.Color.Green;
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



        private void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Connected)
            {
                
                Connected = Client.Disconnect();
                if (!Connected)
                {
                    ConnectToolStripMenuItem.Enabled = true;
                    DisconnectToolStripMenuItem.Enabled = false;
                    StatusLabel.Text = "Closed";
                    StatusLabel.ForeColor = System.Drawing.Color.Red;
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

        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendButton_Click(this, e);
            }
        }
    }
}

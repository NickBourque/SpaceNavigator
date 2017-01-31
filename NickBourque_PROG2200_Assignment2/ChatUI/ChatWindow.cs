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
        Client client = new Client();
        

        public ChatWindow()
        {
            client.MessageReceived += new MessageReceivedEventHandler(Client_MessageReceived);
            InitializeComponent();
        }

        public void Client_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            ConversationTextBox.AppendText("\nServer: " + e.Message);
        }

        private void ChatWindow_Load(object sender, EventArgs e)
        {
            client.Connect();
            client.OpenStream();
        }
    }
}

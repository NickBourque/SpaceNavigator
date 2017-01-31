namespace ChatUI
{
    partial class ChatWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DisconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConversationLabel = new System.Windows.Forms.Label();
            this.ConversationTextBox = new System.Windows.Forms.TextBox();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.MainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.NetworkToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(665, 24);
            this.MainMenuStrip.TabIndex = 4;
            this.MainMenuStrip.Text = "Hello";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.CloseToolStripMenuItem.Text = "Close";
            // 
            // NetworkToolStripMenuItem
            // 
            this.NetworkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectToolStripMenuItem,
            this.DisconnectToolStripMenuItem});
            this.NetworkToolStripMenuItem.Name = "NetworkToolStripMenuItem";
            this.NetworkToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.NetworkToolStripMenuItem.Text = "Network";
            // 
            // ConnectToolStripMenuItem
            // 
            this.ConnectToolStripMenuItem.Name = "ConnectToolStripMenuItem";
            this.ConnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ConnectToolStripMenuItem.Text = "Connect";
            // 
            // DisconnectToolStripMenuItem
            // 
            this.DisconnectToolStripMenuItem.Name = "DisconnectToolStripMenuItem";
            this.DisconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.DisconnectToolStripMenuItem.Text = "Disconnect";
            // 
            // ConversationLabel
            // 
            this.ConversationLabel.AutoSize = true;
            this.ConversationLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConversationLabel.Location = new System.Drawing.Point(23, 44);
            this.ConversationLabel.Name = "ConversationLabel";
            this.ConversationLabel.Size = new System.Drawing.Size(80, 15);
            this.ConversationLabel.TabIndex = 0;
            this.ConversationLabel.Text = "Conversation:";
            // 
            // ConversationTextBox
            // 
            this.ConversationTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.ConversationTextBox.Location = new System.Drawing.Point(26, 60);
            this.ConversationTextBox.Multiline = true;
            this.ConversationTextBox.Name = "ConversationTextBox";
            this.ConversationTextBox.ReadOnly = true;
            this.ConversationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConversationTextBox.Size = new System.Drawing.Size(613, 268);
            this.ConversationTextBox.TabIndex = 3;
            this.ConversationTextBox.TabStop = false;
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLabel.Location = new System.Drawing.Point(23, 342);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(111, 15);
            this.MessageLabel.TabIndex = 0;
            this.MessageLabel.Text = "Type Your Message:";
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Location = new System.Drawing.Point(26, 358);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessageTextBox.Size = new System.Drawing.Size(520, 52);
            this.MessageTextBox.TabIndex = 1;
            // 
            // SendButton
            // 
            this.SendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendButton.Location = new System.Drawing.Point(564, 358);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 52);
            this.SendButton.TabIndex = 2;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(665, 422);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.ConversationTextBox);
            this.Controls.Add(this.ConversationLabel);
            this.Controls.Add(this.MainMenuStrip);
            this.Name = "ChatWindow";
            this.Text = "Nick\'s Chat App";
            this.Load += new System.EventHandler(this.ChatWindow_Load);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DisconnectToolStripMenuItem;
        private System.Windows.Forms.Label ConversationLabel;
        private System.Windows.Forms.TextBox ConversationTextBox;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Button SendButton;
    }
}


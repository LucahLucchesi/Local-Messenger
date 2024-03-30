
namespace LocalMessenger
{
    partial class Messenger
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
            this.chatWindow = new System.Windows.Forms.TextBox();
            this.msgInputBox = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.userGroupBox = new System.Windows.Forms.GroupBox();
            this.usersList = new System.Windows.Forms.ListBox();
            this.userGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // chatWindow
            // 
            this.chatWindow.AcceptsReturn = true;
            this.chatWindow.Location = new System.Drawing.Point(12, 12);
            this.chatWindow.Multiline = true;
            this.chatWindow.Name = "chatWindow";
            this.chatWindow.ReadOnly = true;
            this.chatWindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatWindow.Size = new System.Drawing.Size(539, 400);
            this.chatWindow.TabIndex = 2;
            // 
            // msgInputBox
            // 
            this.msgInputBox.Location = new System.Drawing.Point(12, 419);
            this.msgInputBox.Name = "msgInputBox";
            this.msgInputBox.Size = new System.Drawing.Size(468, 20);
            this.msgInputBox.TabIndex = 0;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(486, 418);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(65, 20);
            this.sendBtn.TabIndex = 1;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // userGroupBox
            // 
            this.userGroupBox.Controls.Add(this.usersList);
            this.userGroupBox.Location = new System.Drawing.Point(557, 12);
            this.userGroupBox.Name = "userGroupBox";
            this.userGroupBox.Size = new System.Drawing.Size(155, 426);
            this.userGroupBox.TabIndex = 3;
            this.userGroupBox.TabStop = false;
            this.userGroupBox.Text = "Users (0/0)";
            // 
            // usersList
            // 
            this.usersList.Enabled = false;
            this.usersList.FormattingEnabled = true;
            this.usersList.Location = new System.Drawing.Point(6, 19);
            this.usersList.Name = "usersList";
            this.usersList.Size = new System.Drawing.Size(143, 394);
            this.usersList.TabIndex = 0;
            // 
            // Messenger
            // 
            this.AcceptButton = this.sendBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 450);
            this.Controls.Add(this.userGroupBox);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.msgInputBox);
            this.Controls.Add(this.chatWindow);
            this.Name = "Messenger";
            this.Text = "Lobby Name (0/0)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Messenger_FormClosing);
            this.userGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox chatWindow;
        private System.Windows.Forms.TextBox msgInputBox;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.GroupBox userGroupBox;
        private System.Windows.Forms.ListBox usersList;
    }
}
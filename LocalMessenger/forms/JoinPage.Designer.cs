﻿
namespace LocalMessenger
{
    partial class JoinPage
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
            this.ipLbl = new System.Windows.Forms.Label();
            this.portLbl = new System.Windows.Forms.Label();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.joinBtn = new System.Windows.Forms.Button();
            this.usrNameTextBox = new System.Windows.Forms.TextBox();
            this.usrNameLbl = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.portBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ipLbl
            // 
            this.ipLbl.AutoSize = true;
            this.ipLbl.Location = new System.Drawing.Point(21, 15);
            this.ipLbl.Name = "ipLbl";
            this.ipLbl.Size = new System.Drawing.Size(23, 13);
            this.ipLbl.TabIndex = 0;
            this.ipLbl.Text = "IP: ";
            // 
            // portLbl
            // 
            this.portLbl.AutoSize = true;
            this.portLbl.Location = new System.Drawing.Point(12, 40);
            this.portLbl.Name = "portLbl";
            this.portLbl.Size = new System.Drawing.Size(32, 13);
            this.portLbl.TabIndex = 1;
            this.portLbl.Text = "Port: ";
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(52, 12);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(130, 20);
            this.ipTextBox.TabIndex = 3;
            // 
            // joinBtn
            // 
            this.joinBtn.Location = new System.Drawing.Point(12, 90);
            this.joinBtn.Name = "joinBtn";
            this.joinBtn.Size = new System.Drawing.Size(170, 23);
            this.joinBtn.TabIndex = 4;
            this.joinBtn.Text = "Join";
            this.joinBtn.UseVisualStyleBackColor = true;
            this.joinBtn.Click += new System.EventHandler(this.joinBtn_Click);
            // 
            // usrNameTextBox
            // 
            this.usrNameTextBox.Location = new System.Drawing.Point(52, 64);
            this.usrNameTextBox.Name = "usrNameTextBox";
            this.usrNameTextBox.Size = new System.Drawing.Size(130, 20);
            this.usrNameTextBox.TabIndex = 5;
            // 
            // usrNameLbl
            // 
            this.usrNameLbl.AutoSize = true;
            this.usrNameLbl.Location = new System.Drawing.Point(6, 67);
            this.usrNameLbl.Name = "usrNameLbl";
            this.usrNameLbl.Size = new System.Drawing.Size(38, 13);
            this.usrNameLbl.TabIndex = 6;
            this.usrNameLbl.Text = "Name:";
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(52, 38);
            this.portBox.Maximum = new decimal(new int[] {
            49151,
            0,
            0,
            0});
            this.portBox.Minimum = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(130, 20);
            this.portBox.TabIndex = 7;
            this.portBox.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // JoinPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 121);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.usrNameLbl);
            this.Controls.Add(this.usrNameTextBox);
            this.Controls.Add(this.joinBtn);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.portLbl);
            this.Controls.Add(this.ipLbl);
            this.Name = "JoinPage";
            this.Text = "Join";
            ((System.ComponentModel.ISupportInitialize)(this.portBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ipLbl;
        private System.Windows.Forms.Label portLbl;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.Button joinBtn;
        private System.Windows.Forms.TextBox usrNameTextBox;
        private System.Windows.Forms.Label usrNameLbl;
        private System.Windows.Forms.NumericUpDown portBox;
    }
}
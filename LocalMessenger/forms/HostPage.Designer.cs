
namespace LocalMessenger
{
    partial class HostPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.roomNameBox = new System.Windows.Forms.TextBox();
            this.usrNameBox = new System.Windows.Forms.TextBox();
            this.hostBtn = new System.Windows.Forms.Button();
            this.roomSizeBox = new System.Windows.Forms.NumericUpDown();
            this.portBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.roomSizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Room Name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Room Size: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "User Name: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Port:";
            // 
            // roomNameBox
            // 
            this.roomNameBox.Location = new System.Drawing.Point(82, 12);
            this.roomNameBox.Name = "roomNameBox";
            this.roomNameBox.Size = new System.Drawing.Size(100, 20);
            this.roomNameBox.TabIndex = 4;
            // 
            // usrNameBox
            // 
            this.usrNameBox.Location = new System.Drawing.Point(82, 64);
            this.usrNameBox.Name = "usrNameBox";
            this.usrNameBox.Size = new System.Drawing.Size(100, 20);
            this.usrNameBox.TabIndex = 6;
            // 
            // hostBtn
            // 
            this.hostBtn.Location = new System.Drawing.Point(7, 116);
            this.hostBtn.Name = "hostBtn";
            this.hostBtn.Size = new System.Drawing.Size(175, 23);
            this.hostBtn.TabIndex = 8;
            this.hostBtn.Text = "Host";
            this.hostBtn.UseVisualStyleBackColor = true;
            this.hostBtn.Click += new System.EventHandler(this.hostBtn_Click);
            // 
            // RoomSizeBox
            // 
            this.roomSizeBox.Location = new System.Drawing.Point(82, 38);
            this.roomSizeBox.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.roomSizeBox.Name = "RoomSizeBox";
            this.roomSizeBox.Size = new System.Drawing.Size(100, 20);
            this.roomSizeBox.TabIndex = 9;
            this.roomSizeBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // PortBox
            // 
            this.portBox.Location = new System.Drawing.Point(82, 90);
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
            this.portBox.Name = "PortBox";
            this.portBox.Size = new System.Drawing.Size(100, 20);
            this.portBox.TabIndex = 10;
            this.portBox.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // HostPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 150);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.roomSizeBox);
            this.Controls.Add(this.hostBtn);
            this.Controls.Add(this.usrNameBox);
            this.Controls.Add(this.roomNameBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HostPage";
            this.Text = "Host";
            ((System.ComponentModel.ISupportInitialize)(this.roomSizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox roomNameBox;
        private System.Windows.Forms.TextBox usrNameBox;
        private System.Windows.Forms.Button hostBtn;
        private System.Windows.Forms.NumericUpDown roomSizeBox;
        private System.Windows.Forms.NumericUpDown portBox;
    }
}
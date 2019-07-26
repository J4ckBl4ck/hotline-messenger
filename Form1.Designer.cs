using System;

namespace hotline_messenger
{
    partial class Form1
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
        protected override void OnClosed(EventArgs e)
        {
            this.sc.ShutDown();
            base.OnClosed(e);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.chatMessage = new System.Windows.Forms.TextBox();
            this.chatSend = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contactsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.c1 = new System.Windows.Forms.Button();
            this.c2 = new System.Windows.Forms.Button();
            this.c3 = new System.Windows.Forms.Button();
            this.c4 = new System.Windows.Forms.Button();
            this.c5 = new System.Windows.Forms.Button();
            this.c6 = new System.Windows.Forms.Button();
            this.c7 = new System.Windows.Forms.Button();
            this.c8 = new System.Windows.Forms.Button();
            this.c9 = new System.Windows.Forms.Button();
            this.c10 = new System.Windows.Forms.Button();
            this.c11 = new System.Windows.Forms.Button();
            this.c12 = new System.Windows.Forms.Button();
            this.addContact = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.contactsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(217, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chat";
            // 
            // chatBox
            // 
            this.chatBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chatBox.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatBox.Location = new System.Drawing.Point(220, 29);
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(568, 383);
            this.chatBox.TabIndex = 3;
            this.chatBox.TabStop = false;
            this.chatBox.Text = "";
            // 
            // chatMessage
            // 
            this.chatMessage.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatMessage.Location = new System.Drawing.Point(220, 418);
            this.chatMessage.Name = "chatMessage";
            this.chatMessage.Size = new System.Drawing.Size(487, 27);
            this.chatMessage.TabIndex = 4;
            this.chatMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChatMessage_KeyDown);
            // 
            // chatSend
            // 
            this.chatSend.Location = new System.Drawing.Point(713, 418);
            this.chatSend.Name = "chatSend";
            this.chatSend.Size = new System.Drawing.Size(75, 27);
            this.chatSend.TabIndex = 5;
            this.chatSend.Text = "Send";
            this.chatSend.UseVisualStyleBackColor = true;
            this.chatSend.Click += new System.EventHandler(this.ChatSend_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.contactsPanel);
            this.groupBox1.Controls.Add(this.addContact);
            this.groupBox1.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 425);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contacts";
            // 
            // contactsPanel
            // 
            this.contactsPanel.Controls.Add(this.c1);
            this.contactsPanel.Controls.Add(this.c2);
            this.contactsPanel.Controls.Add(this.c3);
            this.contactsPanel.Controls.Add(this.c4);
            this.contactsPanel.Controls.Add(this.c5);
            this.contactsPanel.Controls.Add(this.c6);
            this.contactsPanel.Controls.Add(this.c7);
            this.contactsPanel.Controls.Add(this.c8);
            this.contactsPanel.Controls.Add(this.c9);
            this.contactsPanel.Controls.Add(this.c10);
            this.contactsPanel.Controls.Add(this.c11);
            this.contactsPanel.Controls.Add(this.c12);
            this.contactsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.contactsPanel.Location = new System.Drawing.Point(7, 68);
            this.contactsPanel.Name = "contactsPanel";
            this.contactsPanel.Size = new System.Drawing.Size(185, 351);
            this.contactsPanel.TabIndex = 1;
            // 
            // c1
            // 
            this.c1.Location = new System.Drawing.Point(3, 3);
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(182, 23);
            this.c1.TabIndex = 0;
            this.c1.TabStop = false;
            this.c1.Text = "c1";
            this.c1.UseVisualStyleBackColor = true;
            this.c1.Visible = false;
            this.c1.Click += new System.EventHandler(this.C1_Click);
            // 
            // c2
            // 
            this.c2.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c2.Location = new System.Drawing.Point(3, 32);
            this.c2.Name = "c2";
            this.c2.Size = new System.Drawing.Size(182, 23);
            this.c2.TabIndex = 1;
            this.c2.TabStop = false;
            this.c2.Text = "c2";
            this.c2.UseVisualStyleBackColor = true;
            this.c2.Visible = false;
            this.c2.Click += new System.EventHandler(this.C2_Click);
            // 
            // c3
            // 
            this.c3.Location = new System.Drawing.Point(3, 61);
            this.c3.Name = "c3";
            this.c3.Size = new System.Drawing.Size(182, 23);
            this.c3.TabIndex = 2;
            this.c3.TabStop = false;
            this.c3.Text = "c3";
            this.c3.UseVisualStyleBackColor = true;
            this.c3.Visible = false;
            this.c3.Click += new System.EventHandler(this.C3_Click);
            // 
            // c4
            // 
            this.c4.Location = new System.Drawing.Point(3, 90);
            this.c4.Name = "c4";
            this.c4.Size = new System.Drawing.Size(182, 23);
            this.c4.TabIndex = 3;
            this.c4.TabStop = false;
            this.c4.Text = "c4";
            this.c4.UseVisualStyleBackColor = true;
            this.c4.Visible = false;
            this.c4.Click += new System.EventHandler(this.C4_Click);
            // 
            // c5
            // 
            this.c5.Location = new System.Drawing.Point(3, 119);
            this.c5.Name = "c5";
            this.c5.Size = new System.Drawing.Size(182, 23);
            this.c5.TabIndex = 4;
            this.c5.TabStop = false;
            this.c5.Text = "c5";
            this.c5.UseVisualStyleBackColor = true;
            this.c5.Visible = false;
            this.c5.Click += new System.EventHandler(this.C5_Click);
            // 
            // c6
            // 
            this.c6.Location = new System.Drawing.Point(3, 148);
            this.c6.Name = "c6";
            this.c6.Size = new System.Drawing.Size(182, 23);
            this.c6.TabIndex = 5;
            this.c6.TabStop = false;
            this.c6.Text = "c6";
            this.c6.UseVisualStyleBackColor = true;
            this.c6.Visible = false;
            this.c6.Click += new System.EventHandler(this.C6_Click);
            // 
            // c7
            // 
            this.c7.Location = new System.Drawing.Point(3, 177);
            this.c7.Name = "c7";
            this.c7.Size = new System.Drawing.Size(182, 23);
            this.c7.TabIndex = 6;
            this.c7.TabStop = false;
            this.c7.Text = "c7";
            this.c7.UseVisualStyleBackColor = true;
            this.c7.Visible = false;
            this.c7.Click += new System.EventHandler(this.C7_Click);
            // 
            // c8
            // 
            this.c8.Location = new System.Drawing.Point(3, 206);
            this.c8.Name = "c8";
            this.c8.Size = new System.Drawing.Size(182, 23);
            this.c8.TabIndex = 7;
            this.c8.TabStop = false;
            this.c8.Text = "c8";
            this.c8.UseVisualStyleBackColor = true;
            this.c8.Visible = false;
            this.c8.Click += new System.EventHandler(this.C8_Click);
            // 
            // c9
            // 
            this.c9.Location = new System.Drawing.Point(3, 235);
            this.c9.Name = "c9";
            this.c9.Size = new System.Drawing.Size(182, 23);
            this.c9.TabIndex = 8;
            this.c9.TabStop = false;
            this.c9.Text = "c9";
            this.c9.UseVisualStyleBackColor = true;
            this.c9.Visible = false;
            this.c9.Click += new System.EventHandler(this.C9_Click);
            // 
            // c10
            // 
            this.c10.Location = new System.Drawing.Point(3, 264);
            this.c10.Name = "c10";
            this.c10.Size = new System.Drawing.Size(182, 23);
            this.c10.TabIndex = 9;
            this.c10.TabStop = false;
            this.c10.Text = "c10";
            this.c10.UseVisualStyleBackColor = true;
            this.c10.Visible = false;
            this.c10.Click += new System.EventHandler(this.C10_Click);
            // 
            // c11
            // 
            this.c11.Location = new System.Drawing.Point(3, 293);
            this.c11.Name = "c11";
            this.c11.Size = new System.Drawing.Size(182, 23);
            this.c11.TabIndex = 10;
            this.c11.TabStop = false;
            this.c11.Text = "c11";
            this.c11.UseVisualStyleBackColor = true;
            this.c11.Visible = false;
            this.c11.Click += new System.EventHandler(this.C11_Click);
            // 
            // c12
            // 
            this.c12.Location = new System.Drawing.Point(3, 322);
            this.c12.Name = "c12";
            this.c12.Size = new System.Drawing.Size(182, 23);
            this.c12.TabIndex = 11;
            this.c12.TabStop = false;
            this.c12.Text = "c12";
            this.c12.UseVisualStyleBackColor = true;
            this.c12.Visible = false;
            this.c12.Click += new System.EventHandler(this.C12_Click);
            // 
            // addContact
            // 
            this.addContact.Location = new System.Drawing.Point(6, 16);
            this.addContact.Name = "addContact";
            this.addContact.Size = new System.Drawing.Size(186, 36);
            this.addContact.TabIndex = 0;
            this.addContact.Text = "Add Contact";
            this.addContact.UseVisualStyleBackColor = true;
            this.addContact.Click += new System.EventHandler(this.AddContact_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AcceptButton = this.chatSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chatSend);
            this.Controls.Add(this.chatMessage);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "hotline-messenger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.contactsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.TextBox chatMessage;
        private System.Windows.Forms.Button chatSend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addContact;
        private System.Windows.Forms.FlowLayoutPanel contactsPanel;
        private System.Windows.Forms.Button c1;
        private System.Windows.Forms.Button c2;
        private System.Windows.Forms.Button c3;
        private System.Windows.Forms.Button c4;
        private System.Windows.Forms.Button c5;
        private System.Windows.Forms.Button c6;
        private System.Windows.Forms.Button c7;
        private System.Windows.Forms.Button c8;
        private System.Windows.Forms.Button c9;
        private System.Windows.Forms.Button c10;
        private System.Windows.Forms.Button c11;
        private System.Windows.Forms.Button c12;
        private System.Windows.Forms.Timer timer1;
    }
}


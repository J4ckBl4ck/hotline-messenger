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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.chatMessage = new System.Windows.Forms.TextBox();
            this.chatSend = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addContact = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            this.chatBox.Text = "";
            // 
            // chatMessage
            // 
            this.chatMessage.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatMessage.Location = new System.Drawing.Point(220, 418);
            this.chatMessage.Name = "chatMessage";
            this.chatMessage.Size = new System.Drawing.Size(487, 27);
            this.chatMessage.TabIndex = 4;
            this.chatMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chatMessage_KeyDown);
            // 
            // chatSend
            // 
            this.chatSend.Location = new System.Drawing.Point(713, 418);
            this.chatSend.Name = "chatSend";
            this.chatSend.Size = new System.Drawing.Size(75, 27);
            this.chatSend.TabIndex = 5;
            this.chatSend.Text = "Send";
            this.chatSend.UseVisualStyleBackColor = true;
            this.chatSend.Click += new System.EventHandler(this.chatSend_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addContact);
            this.groupBox1.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 425);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contacts";
            // 
            // addContact
            // 
            this.addContact.Location = new System.Drawing.Point(6, 16);
            this.addContact.Name = "addContact";
            this.addContact.Size = new System.Drawing.Size(186, 23);
            this.addContact.TabIndex = 0;
            this.addContact.Text = "Add Contact";
            this.addContact.UseVisualStyleBackColor = true;
            this.addContact.Click += new System.EventHandler(this.addContact_Click);
            // 
            // Form1
            // 
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
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.TextBox chatMessage;
        private System.Windows.Forms.Button chatSend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addContact;
    }
}


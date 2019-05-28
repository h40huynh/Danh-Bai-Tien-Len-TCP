namespace Client
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.ptbCards = new System.Windows.Forms.PictureBox();
            this.ptbCardRight = new System.Windows.Forms.PictureBox();
            this.ptbCardUp = new System.Windows.Forms.PictureBox();
            this.lblRoomId = new System.Windows.Forms.Label();
            this.btnFight = new System.Windows.Forms.Button();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlChat = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSendChat = new System.Windows.Forms.Button();
            this.txtChatBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCardRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCardUp)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // ptbCards
            // 
            this.ptbCards.BackColor = System.Drawing.Color.Transparent;
            this.ptbCards.Location = new System.Drawing.Point(44, 164);
            this.ptbCards.Name = "ptbCards";
            this.ptbCards.Size = new System.Drawing.Size(77, 110);
            this.ptbCards.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbCards.TabIndex = 0;
            this.ptbCards.TabStop = false;
            // 
            // ptbCardRight
            // 
            this.ptbCardRight.BackColor = System.Drawing.Color.Transparent;
            this.ptbCardRight.Location = new System.Drawing.Point(843, 164);
            this.ptbCardRight.Name = "ptbCardRight";
            this.ptbCardRight.Size = new System.Drawing.Size(77, 110);
            this.ptbCardRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbCardRight.TabIndex = 2;
            this.ptbCardRight.TabStop = false;
            // 
            // ptbCardUp
            // 
            this.ptbCardUp.BackColor = System.Drawing.Color.Transparent;
            this.ptbCardUp.Location = new System.Drawing.Point(443, -64);
            this.ptbCardUp.Name = "ptbCardUp";
            this.ptbCardUp.Size = new System.Drawing.Size(77, 110);
            this.ptbCardUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbCardUp.TabIndex = 3;
            this.ptbCardUp.TabStop = false;
            // 
            // lblRoomId
            // 
            this.lblRoomId.AutoSize = true;
            this.lblRoomId.BackColor = System.Drawing.Color.Transparent;
            this.lblRoomId.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomId.ForeColor = System.Drawing.Color.Yellow;
            this.lblRoomId.Location = new System.Drawing.Point(19, 20);
            this.lblRoomId.Name = "lblRoomId";
            this.lblRoomId.Size = new System.Drawing.Size(121, 26);
            this.lblRoomId.TabIndex = 4;
            this.lblRoomId.Text = "lblRoomId";
            // 
            // btnFight
            // 
            this.btnFight.Enabled = false;
            this.btnFight.Location = new System.Drawing.Point(719, 366);
            this.btnFight.Name = "btnFight";
            this.btnFight.Size = new System.Drawing.Size(75, 23);
            this.btnFight.TabIndex = 5;
            this.btnFight.Text = "Fight";
            this.btnFight.UseVisualStyleBackColor = true;
            this.btnFight.Click += new System.EventHandler(this.BtnFight_Click);
            // 
            // btnIgnore
            // 
            this.btnIgnore.Enabled = false;
            this.btnIgnore.Location = new System.Drawing.Point(796, 366);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(75, 23);
            this.btnIgnore.TabIndex = 6;
            this.btnIgnore.Text = "Ignore";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new System.EventHandler(this.BtnIgnore_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lblRoomId);
            this.panel1.Location = new System.Drawing.Point(731, -11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 92);
            this.panel1.TabIndex = 7;
            // 
            // pnlChat
            // 
            this.pnlChat.BackColor = System.Drawing.Color.Black;
            this.pnlChat.Controls.Add(this.txtChatBox);
            this.pnlChat.Controls.Add(this.btnSendChat);
            this.pnlChat.Controls.Add(this.txtMessage);
            this.pnlChat.ForeColor = System.Drawing.Color.White;
            this.pnlChat.Location = new System.Drawing.Point(0, 406);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(308, 138);
            this.pnlChat.TabIndex = 8;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.ForeColor = System.Drawing.Color.White;
            this.txtMessage.Location = new System.Drawing.Point(0, 118);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(256, 20);
            this.txtMessage.TabIndex = 9;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMessage_KeyDown);
            // 
            // btnSendChat
            // 
            this.btnSendChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSendChat.FlatAppearance.BorderSize = 0;
            this.btnSendChat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSendChat.Location = new System.Drawing.Point(253, 117);
            this.btnSendChat.Name = "btnSendChat";
            this.btnSendChat.Size = new System.Drawing.Size(55, 23);
            this.btnSendChat.TabIndex = 10;
            this.btnSendChat.Text = "Send";
            this.btnSendChat.UseVisualStyleBackColor = false;
            this.btnSendChat.Click += new System.EventHandler(this.BtnSendChat_Click);
            // 
            // txtChatBox
            // 
            this.txtChatBox.BackColor = System.Drawing.Color.Black;
            this.txtChatBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChatBox.ForeColor = System.Drawing.Color.White;
            this.txtChatBox.Location = new System.Drawing.Point(3, 3);
            this.txtChatBox.Name = "txtChatBox";
            this.txtChatBox.Size = new System.Drawing.Size(302, 108);
            this.txtChatBox.TabIndex = 11;
            this.txtChatBox.Text = "";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(932, 545);
            this.Controls.Add(this.pnlChat);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.btnFight);
            this.Controls.Add(this.ptbCardUp);
            this.Controls.Add(this.ptbCardRight);
            this.Controls.Add(this.ptbCards);
            this.DoubleBuffered = true;
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCardRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCardUp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlChat.ResumeLayout(false);
            this.pnlChat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbCards;
        private System.Windows.Forms.PictureBox ptbCardRight;
        private System.Windows.Forms.PictureBox ptbCardUp;
        private System.Windows.Forms.Label lblRoomId;
        private System.Windows.Forms.Button btnFight;
        private System.Windows.Forms.Button btnIgnore;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.RichTextBox txtChatBox;
        private System.Windows.Forms.Button btnSendChat;
    }
}
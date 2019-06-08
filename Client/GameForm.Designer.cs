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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.lblRoomId = new System.Windows.Forms.Label();
            this.btnFight = new System.Windows.Forms.Button();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.pnlChat = new System.Windows.Forms.Panel();
            this.txtChatBox = new System.Windows.Forms.RichTextBox();
            this.btnSendChat = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.ptbAvatar1 = new System.Windows.Forms.PictureBox();
            this.pnInfo1 = new System.Windows.Forms.Panel();
            this.lblMoney1 = new System.Windows.Forms.Label();
            this.lblName1 = new System.Windows.Forms.Label();
            this.pnInfo2 = new System.Windows.Forms.Panel();
            this.lblMoney2 = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.ptbAvatar2 = new System.Windows.Forms.PictureBox();
            this.pnInfo3 = new System.Windows.Forms.Panel();
            this.lblMoney3 = new System.Windows.Forms.Label();
            this.lblName3 = new System.Windows.Forms.Label();
            this.ptbAvatar3 = new System.Windows.Forms.PictureBox();
            this.ptbAvatar0 = new System.Windows.Forms.PictureBox();
            this.timerCountdown = new System.Windows.Forms.Timer(this.components);
            this.lblTimeLeft0 = new System.Windows.Forms.Label();
            this.pnlChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar1)).BeginInit();
            this.pnInfo1.SuspendLayout();
            this.pnInfo2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar2)).BeginInit();
            this.pnInfo3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar0)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRoomId
            // 
            this.lblRoomId.AutoSize = true;
            this.lblRoomId.BackColor = System.Drawing.Color.Transparent;
            this.lblRoomId.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomId.ForeColor = System.Drawing.Color.Yellow;
            this.lblRoomId.Location = new System.Drawing.Point(12, 9);
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
            // ptbAvatar1
            // 
            this.ptbAvatar1.BackColor = System.Drawing.Color.Transparent;
            this.ptbAvatar1.Location = new System.Drawing.Point(0, 3);
            this.ptbAvatar1.Name = "ptbAvatar1";
            this.ptbAvatar1.Size = new System.Drawing.Size(80, 80);
            this.ptbAvatar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbAvatar1.TabIndex = 10;
            this.ptbAvatar1.TabStop = false;
            // 
            // pnInfo1
            // 
            this.pnInfo1.BackColor = System.Drawing.Color.Transparent;
            this.pnInfo1.Controls.Add(this.lblMoney1);
            this.pnInfo1.Controls.Add(this.lblName1);
            this.pnInfo1.Controls.Add(this.ptbAvatar1);
            this.pnInfo1.Location = new System.Drawing.Point(760, 170);
            this.pnInfo1.Name = "pnInfo1";
            this.pnInfo1.Size = new System.Drawing.Size(160, 110);
            this.pnInfo1.TabIndex = 11;
            // 
            // lblMoney1
            // 
            this.lblMoney1.AutoSize = true;
            this.lblMoney1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney1.ForeColor = System.Drawing.Color.Yellow;
            this.lblMoney1.Location = new System.Drawing.Point(86, 43);
            this.lblMoney1.Name = "lblMoney1";
            this.lblMoney1.Size = new System.Drawing.Size(48, 16);
            this.lblMoney1.TabIndex = 12;
            this.lblMoney1.Text = "$3000";
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName1.ForeColor = System.Drawing.Color.Yellow;
            this.lblName1.Location = new System.Drawing.Point(86, 27);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(49, 16);
            this.lblName1.TabIndex = 11;
            this.lblName1.Text = "Name";
            // 
            // pnInfo2
            // 
            this.pnInfo2.BackColor = System.Drawing.Color.Transparent;
            this.pnInfo2.Controls.Add(this.lblMoney2);
            this.pnInfo2.Controls.Add(this.lblName2);
            this.pnInfo2.Controls.Add(this.ptbAvatar2);
            this.pnInfo2.Location = new System.Drawing.Point(387, 6);
            this.pnInfo2.Name = "pnInfo2";
            this.pnInfo2.Size = new System.Drawing.Size(160, 110);
            this.pnInfo2.TabIndex = 12;
            // 
            // lblMoney2
            // 
            this.lblMoney2.AutoSize = true;
            this.lblMoney2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney2.ForeColor = System.Drawing.Color.Yellow;
            this.lblMoney2.Location = new System.Drawing.Point(86, 43);
            this.lblMoney2.Name = "lblMoney2";
            this.lblMoney2.Size = new System.Drawing.Size(48, 16);
            this.lblMoney2.TabIndex = 12;
            this.lblMoney2.Text = "$3000";
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName2.ForeColor = System.Drawing.Color.Yellow;
            this.lblName2.Location = new System.Drawing.Point(86, 27);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(49, 16);
            this.lblName2.TabIndex = 11;
            this.lblName2.Text = "Name";
            // 
            // ptbAvatar2
            // 
            this.ptbAvatar2.BackColor = System.Drawing.Color.Transparent;
            this.ptbAvatar2.Location = new System.Drawing.Point(0, 3);
            this.ptbAvatar2.Name = "ptbAvatar2";
            this.ptbAvatar2.Size = new System.Drawing.Size(80, 80);
            this.ptbAvatar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbAvatar2.TabIndex = 10;
            this.ptbAvatar2.TabStop = false;
            // 
            // pnInfo3
            // 
            this.pnInfo3.BackColor = System.Drawing.Color.Transparent;
            this.pnInfo3.Controls.Add(this.lblMoney3);
            this.pnInfo3.Controls.Add(this.lblName3);
            this.pnInfo3.Controls.Add(this.ptbAvatar3);
            this.pnInfo3.Location = new System.Drawing.Point(17, 170);
            this.pnInfo3.Name = "pnInfo3";
            this.pnInfo3.Size = new System.Drawing.Size(160, 110);
            this.pnInfo3.TabIndex = 13;
            // 
            // lblMoney3
            // 
            this.lblMoney3.AutoSize = true;
            this.lblMoney3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney3.ForeColor = System.Drawing.Color.Yellow;
            this.lblMoney3.Location = new System.Drawing.Point(86, 43);
            this.lblMoney3.Name = "lblMoney3";
            this.lblMoney3.Size = new System.Drawing.Size(48, 16);
            this.lblMoney3.TabIndex = 12;
            this.lblMoney3.Text = "$3000";
            // 
            // lblName3
            // 
            this.lblName3.AutoSize = true;
            this.lblName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName3.ForeColor = System.Drawing.Color.Yellow;
            this.lblName3.Location = new System.Drawing.Point(86, 27);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(49, 16);
            this.lblName3.TabIndex = 11;
            this.lblName3.Text = "Name";
            // 
            // ptbAvatar3
            // 
            this.ptbAvatar3.BackColor = System.Drawing.Color.Transparent;
            this.ptbAvatar3.Location = new System.Drawing.Point(0, 3);
            this.ptbAvatar3.Name = "ptbAvatar3";
            this.ptbAvatar3.Size = new System.Drawing.Size(80, 80);
            this.ptbAvatar3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbAvatar3.TabIndex = 10;
            this.ptbAvatar3.TabStop = false;
            // 
            // ptbAvatar0
            // 
            this.ptbAvatar0.BackColor = System.Drawing.Color.Transparent;
            this.ptbAvatar0.Location = new System.Drawing.Point(840, 453);
            this.ptbAvatar0.Name = "ptbAvatar0";
            this.ptbAvatar0.Size = new System.Drawing.Size(80, 80);
            this.ptbAvatar0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbAvatar0.TabIndex = 14;
            this.ptbAvatar0.TabStop = false;
            // 
            // timerCountdown
            // 
            this.timerCountdown.Enabled = true;
            this.timerCountdown.Interval = 1000;
            this.timerCountdown.Tick += new System.EventHandler(this.TimerCountdown_Tick);
            // 
            // lblTimeLeft0
            // 
            this.lblTimeLeft0.AutoSize = true;
            this.lblTimeLeft0.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeLeft0.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLeft0.ForeColor = System.Drawing.Color.White;
            this.lblTimeLeft0.Location = new System.Drawing.Point(427, 338);
            this.lblTimeLeft0.Name = "lblTimeLeft0";
            this.lblTimeLeft0.Size = new System.Drawing.Size(64, 24);
            this.lblTimeLeft0.TabIndex = 15;
            this.lblTimeLeft0.Text = "Timer";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(932, 545);
            this.Controls.Add(this.lblTimeLeft0);
            this.Controls.Add(this.ptbAvatar0);
            this.Controls.Add(this.lblRoomId);
            this.Controls.Add(this.pnInfo3);
            this.Controls.Add(this.pnInfo2);
            this.Controls.Add(this.pnInfo1);
            this.Controls.Add(this.pnlChat);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.btnFight);
            this.DoubleBuffered = true;
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.pnlChat.ResumeLayout(false);
            this.pnlChat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar1)).EndInit();
            this.pnInfo1.ResumeLayout(false);
            this.pnInfo1.PerformLayout();
            this.pnInfo2.ResumeLayout(false);
            this.pnInfo2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar2)).EndInit();
            this.pnInfo3.ResumeLayout(false);
            this.pnInfo3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblRoomId;
        private System.Windows.Forms.Button btnFight;
        private System.Windows.Forms.Button btnIgnore;
        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.RichTextBox txtChatBox;
        private System.Windows.Forms.Button btnSendChat;
        private System.Windows.Forms.PictureBox ptbAvatar1;
        private System.Windows.Forms.Panel pnInfo1;
        private System.Windows.Forms.Label lblMoney1;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Panel pnInfo2;
        private System.Windows.Forms.Label lblMoney2;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.PictureBox ptbAvatar2;
        private System.Windows.Forms.Panel pnInfo3;
        private System.Windows.Forms.Label lblMoney3;
        private System.Windows.Forms.Label lblName3;
        private System.Windows.Forms.PictureBox ptbAvatar3;
        private System.Windows.Forms.PictureBox ptbAvatar0;
        private System.Windows.Forms.Timer timerCountdown;
        private System.Windows.Forms.Label lblTimeLeft0;
    }
}
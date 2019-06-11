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
            this.ptbSun = new System.Windows.Forms.PictureBox();
            this.timerSunAnimation = new System.Windows.Forms.Timer(this.components);
            this.lblChat3 = new System.Windows.Forms.Label();
            this.lblChat2 = new System.Windows.Forms.Label();
            this.lblChat1 = new System.Windows.Forms.Label();
            this.lblChat0 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSendChat = new System.Windows.Forms.Button();
            this.prbTimerCount = new System.Windows.Forms.ProgressBar();
            this.lblWiner = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar1)).BeginInit();
            this.pnInfo1.SuspendLayout();
            this.pnInfo2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar2)).BeginInit();
            this.pnInfo3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSun)).BeginInit();
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
            this.pnInfo1.Size = new System.Drawing.Size(160, 83);
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
            this.pnInfo2.Size = new System.Drawing.Size(160, 85);
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
            this.pnInfo3.Size = new System.Drawing.Size(160, 83);
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
            this.lblTimeLeft0.Size = new System.Drawing.Size(0, 24);
            this.lblTimeLeft0.TabIndex = 15;
            // 
            // ptbSun
            // 
            this.ptbSun.BackColor = System.Drawing.Color.Transparent;
            this.ptbSun.Location = new System.Drawing.Point(742, 328);
            this.ptbSun.Name = "ptbSun";
            this.ptbSun.Size = new System.Drawing.Size(32, 32);
            this.ptbSun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbSun.TabIndex = 17;
            this.ptbSun.TabStop = false;
            // 
            // timerSunAnimation
            // 
            this.timerSunAnimation.Interval = 200;
            this.timerSunAnimation.Tick += new System.EventHandler(this.TimerSunAnimation_Tick);
            // 
            // lblChat3
            // 
            this.lblChat3.AutoSize = true;
            this.lblChat3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChat3.Location = new System.Drawing.Point(22, 144);
            this.lblChat3.Name = "lblChat3";
            this.lblChat3.Size = new System.Drawing.Size(0, 16);
            this.lblChat3.TabIndex = 18;
            // 
            // lblChat2
            // 
            this.lblChat2.AutoSize = true;
            this.lblChat2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChat2.Location = new System.Drawing.Point(553, 33);
            this.lblChat2.Name = "lblChat2";
            this.lblChat2.Size = new System.Drawing.Size(0, 16);
            this.lblChat2.TabIndex = 19;
            // 
            // lblChat1
            // 
            this.lblChat1.AutoSize = true;
            this.lblChat1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChat1.Location = new System.Drawing.Point(757, 144);
            this.lblChat1.Name = "lblChat1";
            this.lblChat1.Size = new System.Drawing.Size(0, 16);
            this.lblChat1.TabIndex = 20;
            // 
            // lblChat0
            // 
            this.lblChat0.AutoSize = true;
            this.lblChat0.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChat0.Location = new System.Drawing.Point(86, 390);
            this.lblChat0.Name = "lblChat0";
            this.lblChat0.Size = new System.Drawing.Size(0, 16);
            this.lblChat0.TabIndex = 21;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.ForeColor = System.Drawing.Color.White;
            this.txtMessage.Location = new System.Drawing.Point(3, 522);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(256, 20);
            this.txtMessage.TabIndex = 9;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMessage_KeyDown);
            // 
            // btnSendChat
            // 
            this.btnSendChat.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSendChat.FlatAppearance.BorderSize = 0;
            this.btnSendChat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSendChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendChat.Location = new System.Drawing.Point(256, 519);
            this.btnSendChat.Name = "btnSendChat";
            this.btnSendChat.Size = new System.Drawing.Size(55, 31);
            this.btnSendChat.TabIndex = 10;
            this.btnSendChat.Text = "Send";
            this.btnSendChat.UseVisualStyleBackColor = false;
            this.btnSendChat.Click += new System.EventHandler(this.BtnSendChat_Click);
            // 
            // prbTimerCount
            // 
            this.prbTimerCount.Location = new System.Drawing.Point(387, 95);
            this.prbTimerCount.Maximum = 15;
            this.prbTimerCount.Name = "prbTimerCount";
            this.prbTimerCount.Size = new System.Drawing.Size(80, 13);
            this.prbTimerCount.TabIndex = 22;
            // 
            // lblWiner
            // 
            this.lblWiner.AutoSize = true;
            this.lblWiner.BackColor = System.Drawing.Color.Transparent;
            this.lblWiner.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWiner.ForeColor = System.Drawing.Color.Yellow;
            this.lblWiner.Location = new System.Drawing.Point(-96, 288);
            this.lblWiner.Name = "lblWiner";
            this.lblWiner.Size = new System.Drawing.Size(95, 29);
            this.lblWiner.TabIndex = 23;
            this.lblWiner.Text = "Winner";
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Location = new System.Drawing.Point(431, 328);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 24;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(932, 545);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblWiner);
            this.Controls.Add(this.prbTimerCount);
            this.Controls.Add(this.lblChat0);
            this.Controls.Add(this.btnSendChat);
            this.Controls.Add(this.lblChat1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblChat2);
            this.Controls.Add(this.lblChat3);
            this.Controls.Add(this.ptbSun);
            this.Controls.Add(this.lblTimeLeft0);
            this.Controls.Add(this.ptbAvatar0);
            this.Controls.Add(this.lblRoomId);
            this.Controls.Add(this.pnInfo3);
            this.Controls.Add(this.pnInfo2);
            this.Controls.Add(this.pnInfo1);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.btnFight);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.Load += new System.EventHandler(this.GameForm_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.ptbSun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblRoomId;
        private System.Windows.Forms.Button btnFight;
        private System.Windows.Forms.Button btnIgnore;
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
        private System.Windows.Forms.PictureBox ptbSun;
        private System.Windows.Forms.Timer timerSunAnimation;
        private System.Windows.Forms.Label lblChat3;
        private System.Windows.Forms.Label lblChat2;
        private System.Windows.Forms.Label lblChat1;
        private System.Windows.Forms.Label lblChat0;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSendChat;
        private System.Windows.Forms.ProgressBar prbTimerCount;
        private System.Windows.Forms.Label lblWiner;
        private System.Windows.Forms.Button btnPlay;
    }
}
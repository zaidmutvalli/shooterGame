namespace SurviveTillDawn
{
    partial class GameScreenDesign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreenDesign));
            this.prgHealth = new System.Windows.Forms.ProgressBar();
            this.GameLoopTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlPause = new System.Windows.Forms.Panel();
            this.lblRestart = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblKills = new System.Windows.Forms.Label();
            this.lblAmmo = new System.Windows.Forms.Label();
            this.lblHealth = new System.Windows.Forms.Label();
            this.pboCurrentInfo = new System.Windows.Forms.PictureBox();
            this.lblPause = new System.Windows.Forms.Label();
            this.pnlPause.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboCurrentInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // prgHealth
            // 
            this.prgHealth.BackColor = System.Drawing.Color.Lime;
            this.prgHealth.ForeColor = System.Drawing.Color.Lime;
            this.prgHealth.Location = new System.Drawing.Point(178, 25);
            this.prgHealth.Margin = new System.Windows.Forms.Padding(4);
            this.prgHealth.Name = "prgHealth";
            this.prgHealth.Size = new System.Drawing.Size(521, 58);
            this.prgHealth.TabIndex = 3;
            this.prgHealth.Value = 100;
            this.prgHealth.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // GameLoopTimer
            // 
            this.GameLoopTimer.Enabled = true;
            this.GameLoopTimer.Interval = 16;
            this.GameLoopTimer.Tick += new System.EventHandler(this.GameLoop);
            // 
            // pnlPause
            // 
            this.pnlPause.BackColor = System.Drawing.Color.DarkGray;
            this.pnlPause.BackgroundImage = global::SurviveTillDawn.Properties.Resources.background;
            this.pnlPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlPause.Controls.Add(this.lblRestart);
            this.pnlPause.Controls.Add(this.lblExit);
            this.pnlPause.Controls.Add(this.lblMenu);
            this.pnlPause.Controls.Add(this.flowLayoutPanel1);
            this.pnlPause.Location = new System.Drawing.Point(421, 119);
            this.pnlPause.Name = "pnlPause";
            this.pnlPause.Size = new System.Drawing.Size(882, 900);
            this.pnlPause.TabIndex = 9;
            this.pnlPause.Visible = false;
            // 
            // lblRestart
            // 
            this.lblRestart.AutoSize = true;
            this.lblRestart.BackColor = System.Drawing.Color.Transparent;
            this.lblRestart.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestart.ForeColor = System.Drawing.Color.White;
            this.lblRestart.Location = new System.Drawing.Point(320, 118);
            this.lblRestart.Name = "lblRestart";
            this.lblRestart.Size = new System.Drawing.Size(311, 50);
            this.lblRestart.TabIndex = 11;
            this.lblRestart.Text = "Restart Game";
            this.lblRestart.Click += new System.EventHandler(this.lblRestart_Click);
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.White;
            this.lblExit.Location = new System.Drawing.Point(320, 334);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(228, 50);
            this.lblExit.TabIndex = 10;
            this.lblExit.Text = "Exit Game";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.BackColor = System.Drawing.Color.Transparent;
            this.lblMenu.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.ForeColor = System.Drawing.Color.White;
            this.lblMenu.Location = new System.Drawing.Point(320, 226);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(235, 50);
            this.lblMenu.TabIndex = 9;
            this.lblMenu.Text = "Main Menu";
            this.lblMenu.Click += new System.EventHandler(this.lblMenu_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(374, 63);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblKills
            // 
            this.lblKills.AutoSize = true;
            this.lblKills.BackColor = System.Drawing.Color.Blue;
            this.lblKills.Font = new System.Drawing.Font("MS Reference Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKills.ForeColor = System.Drawing.Color.Red;
            this.lblKills.Image = global::SurviveTillDawn.Properties.Resources.OIP;
            this.lblKills.Location = new System.Drawing.Point(1027, 81);
            this.lblKills.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKills.Name = "lblKills";
            this.lblKills.Size = new System.Drawing.Size(105, 40);
            this.lblKills.TabIndex = 6;
            this.lblKills.Text = "Kills:";
            this.lblKills.Click += new System.EventHandler(this.lblKills_Click);
            // 
            // lblAmmo
            // 
            this.lblAmmo.AutoSize = true;
            this.lblAmmo.BackColor = System.Drawing.Color.Blue;
            this.lblAmmo.Font = new System.Drawing.Font("MS Reference Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmmo.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblAmmo.Image = ((System.Drawing.Image)(resources.GetObject("lblAmmo.Image")));
            this.lblAmmo.Location = new System.Drawing.Point(790, 81);
            this.lblAmmo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAmmo.Name = "lblAmmo";
            this.lblAmmo.Size = new System.Drawing.Size(46, 40);
            this.lblAmmo.TabIndex = 2;
            this.lblAmmo.Text = ": ";
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.BackColor = System.Drawing.Color.Blue;
            this.lblHealth.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHealth.ForeColor = System.Drawing.Color.Lime;
            this.lblHealth.Image = global::SurviveTillDawn.Properties.Resources.OIP;
            this.lblHealth.Location = new System.Drawing.Point(22, 36);
            this.lblHealth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(148, 35);
            this.lblHealth.TabIndex = 1;
            this.lblHealth.Text = "Health: ";
            // 
            // pboCurrentInfo
            // 
            this.pboCurrentInfo.BackColor = System.Drawing.Color.Transparent;
            this.pboCurrentInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pboCurrentInfo.BackgroundImage")));
            this.pboCurrentInfo.Location = new System.Drawing.Point(-8, -4);
            this.pboCurrentInfo.Margin = new System.Windows.Forms.Padding(4);
            this.pboCurrentInfo.Name = "pboCurrentInfo";
            this.pboCurrentInfo.Size = new System.Drawing.Size(1321, 123);
            this.pboCurrentInfo.TabIndex = 0;
            this.pboCurrentInfo.TabStop = false;
            this.pboCurrentInfo.Click += new System.EventHandler(this.pboCurrentInfo_Click);
            // 
            // lblPause
            // 
            this.lblPause.AutoSize = true;
            this.lblPause.BackColor = System.Drawing.Color.Transparent;
            this.lblPause.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPause.ForeColor = System.Drawing.Color.White;
            this.lblPause.Location = new System.Drawing.Point(1557, 67);
            this.lblPause.Name = "lblPause";
            this.lblPause.Size = new System.Drawing.Size(145, 50);
            this.lblPause.TabIndex = 10;
            this.lblPause.Text = "Pause";
            this.lblPause.Click += new System.EventHandler(this.lblPause_Click);
            // 
            // GameScreenDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1661, 673);
            this.Controls.Add(this.lblPause);
            this.Controls.Add(this.pnlPause);
            this.Controls.Add(this.lblKills);
            this.Controls.Add(this.prgHealth);
            this.Controls.Add(this.lblAmmo);
            this.Controls.Add(this.lblHealth);
            this.Controls.Add(this.pboCurrentInfo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameScreenDesign";
            this.Text = "GameScreenDesign";
            this.Load += new System.EventHandler(this.GameScreenDesign_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintEvent);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DownPressed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LiftPressed);
            this.pnlPause.ResumeLayout(false);
            this.pnlPause.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboCurrentInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pboCurrentInfo;
        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.Label lblAmmo;
        private System.Windows.Forms.ProgressBar prgHealth;
        private System.Windows.Forms.Timer GameLoopTimer;
        private System.Windows.Forms.Label lblKills;
        private System.Windows.Forms.Panel pnlPause;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblPause;
        private System.Windows.Forms.Label lblRestart;
    }
}
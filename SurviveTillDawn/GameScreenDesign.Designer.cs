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
            this.pboCurrentInfo = new System.Windows.Forms.PictureBox();
            this.lblHealth = new System.Windows.Forms.Label();
            this.lblAmmo = new System.Windows.Forms.Label();
            this.prgHealth = new System.Windows.Forms.ProgressBar();
            this.GameLoopTimer = new System.Windows.Forms.Timer(this.components);
            this.lblKills = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pboCurrentInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pboCurrentInfo
            // 
            this.pboCurrentInfo.BackColor = System.Drawing.Color.Transparent;
            this.pboCurrentInfo.BackgroundImage = global::SurviveTillDawn.Properties.Resources.Night;
            this.pboCurrentInfo.Location = new System.Drawing.Point(-6, -3);
            this.pboCurrentInfo.Name = "pboCurrentInfo";
            this.pboCurrentInfo.Size = new System.Drawing.Size(809, 59);
            this.pboCurrentInfo.TabIndex = 0;
            this.pboCurrentInfo.TabStop = false;
            this.pboCurrentInfo.Click += new System.EventHandler(this.pboCurrentInfo_Click);
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.BackColor = System.Drawing.Color.Black;
            this.lblHealth.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHealth.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblHealth.Image = global::SurviveTillDawn.Properties.Resources.Night;
            this.lblHealth.Location = new System.Drawing.Point(10, 20);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(106, 26);
            this.lblHealth.TabIndex = 1;
            this.lblHealth.Text = "Health: ";
            // 
            // lblAmmo
            // 
            this.lblAmmo.AutoSize = true;
            this.lblAmmo.BackColor = System.Drawing.Color.Black;
            this.lblAmmo.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmmo.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblAmmo.Image = global::SurviveTillDawn.Properties.Resources.Night;
            this.lblAmmo.Location = new System.Drawing.Point(553, 19);
            this.lblAmmo.Name = "lblAmmo";
            this.lblAmmo.Size = new System.Drawing.Size(102, 26);
            this.lblAmmo.TabIndex = 2;
            this.lblAmmo.Text = "Ammo: ";
            // 
            // prgHealth
            // 
            this.prgHealth.BackColor = System.Drawing.Color.Lime;
            this.prgHealth.ForeColor = System.Drawing.Color.Lime;
            this.prgHealth.Location = new System.Drawing.Point(95, 17);
            this.prgHealth.Name = "prgHealth";
            this.prgHealth.Size = new System.Drawing.Size(344, 25);
            this.prgHealth.TabIndex = 3;
            this.prgHealth.Value = 100;
            this.prgHealth.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // GameLoopTimer
            // 
            this.GameLoopTimer.Enabled = true;
            this.GameLoopTimer.Interval = 10;
            this.GameLoopTimer.Tick += new System.EventHandler(this.GameLoop);
            // 
            // lblKills
            // 
            this.lblKills.AutoSize = true;
            this.lblKills.BackColor = System.Drawing.Color.Black;
            this.lblKills.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKills.ForeColor = System.Drawing.Color.Red;
            this.lblKills.Image = global::SurviveTillDawn.Properties.Resources.Night;
            this.lblKills.Location = new System.Drawing.Point(665, 17);
            this.lblKills.Name = "lblKills";
            this.lblKills.Size = new System.Drawing.Size(78, 29);
            this.lblKills.TabIndex = 6;
            this.lblKills.Text = "Kills:";
            this.lblKills.Click += new System.EventHandler(this.lblKills_Click);
            // 
            // GameScreenDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblKills);
            this.Controls.Add(this.prgHealth);
            this.Controls.Add(this.lblAmmo);
            this.Controls.Add(this.lblHealth);
            this.Controls.Add(this.pboCurrentInfo);
            this.Name = "GameScreenDesign";
            this.Text = "GameScreenDesign";
            this.Load += new System.EventHandler(this.GameScreenDesign_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintEvent);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DownPressed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LiftPressed);
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
    }
}
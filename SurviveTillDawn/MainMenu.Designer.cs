namespace SurviveTillDawn
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblExitGame = new System.Windows.Forms.Label();
            this.lblLogIn = new System.Windows.Forms.Label();
            this.lblLeaderboard = new System.Windows.Forms.Label();
            this.dgvLeaderboard = new System.Windows.Forms.DataGridView();
            this.lblLogWarning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaderboard)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Showcard Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Brown;
            this.lblTitle.Location = new System.Drawing.Point(623, 107);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(809, 98);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Survive Till Dawn";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.BackColor = System.Drawing.Color.Transparent;
            this.lblStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblStart.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.ForeColor = System.Drawing.Color.White;
            this.lblStart.Location = new System.Drawing.Point(838, 320);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(262, 50);
            this.lblStart.TabIndex = 1;
            this.lblStart.Text = "Start Game";
            this.lblStart.Click += new System.EventHandler(this.lblStart_Click);
            // 
            // lblExitGame
            // 
            this.lblExitGame.AutoSize = true;
            this.lblExitGame.BackColor = System.Drawing.Color.Transparent;
            this.lblExitGame.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExitGame.ForeColor = System.Drawing.Color.White;
            this.lblExitGame.Location = new System.Drawing.Point(838, 590);
            this.lblExitGame.Name = "lblExitGame";
            this.lblExitGame.Size = new System.Drawing.Size(228, 50);
            this.lblExitGame.TabIndex = 2;
            this.lblExitGame.Text = "Exit Game";
            this.lblExitGame.Click += new System.EventHandler(this.lblExitGame_Click);
            // 
            // lblLogIn
            // 
            this.lblLogIn.AutoSize = true;
            this.lblLogIn.BackColor = System.Drawing.Color.Transparent;
            this.lblLogIn.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogIn.ForeColor = System.Drawing.Color.White;
            this.lblLogIn.Location = new System.Drawing.Point(838, 410);
            this.lblLogIn.Name = "lblLogIn";
            this.lblLogIn.Size = new System.Drawing.Size(312, 50);
            this.lblLogIn.TabIndex = 3;
            this.lblLogIn.Text = "Login / Signup";
            this.lblLogIn.Click += new System.EventHandler(this.lblLogIn_Click);
            // 
            // lblLeaderboard
            // 
            this.lblLeaderboard.AutoSize = true;
            this.lblLeaderboard.BackColor = System.Drawing.Color.Transparent;
            this.lblLeaderboard.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeaderboard.ForeColor = System.Drawing.Color.White;
            this.lblLeaderboard.Location = new System.Drawing.Point(838, 500);
            this.lblLeaderboard.Name = "lblLeaderboard";
            this.lblLeaderboard.Size = new System.Drawing.Size(414, 50);
            this.lblLeaderboard.TabIndex = 4;
            this.lblLeaderboard.Text = "View Leaderboard";
            this.lblLeaderboard.Click += new System.EventHandler(this.lblLeaderboard_Click);
            // 
            // dgvLeaderboard
            // 
            this.dgvLeaderboard.AllowUserToAddRows = false;
            this.dgvLeaderboard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLeaderboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeaderboard.Location = new System.Drawing.Point(369, 288);
            this.dgvLeaderboard.Name = "dgvLeaderboard";
            this.dgvLeaderboard.ReadOnly = true;
            this.dgvLeaderboard.RowHeadersVisible = false;
            this.dgvLeaderboard.RowHeadersWidth = 51;
            this.dgvLeaderboard.RowTemplate.Height = 24;
            this.dgvLeaderboard.Size = new System.Drawing.Size(240, 150);
            this.dgvLeaderboard.TabIndex = 5;
            this.dgvLeaderboard.Visible = false;
            this.dgvLeaderboard.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLeaderboard_CellContentClick);
            // 
            // lblLogWarning
            // 
            this.lblLogWarning.AutoSize = true;
            this.lblLogWarning.BackColor = System.Drawing.Color.Transparent;
            this.lblLogWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblLogWarning.Location = new System.Drawing.Point(725, 274);
            this.lblLogWarning.Name = "lblLogWarning";
            this.lblLogWarning.Size = new System.Drawing.Size(547, 36);
            this.lblLogWarning.TabIndex = 6;
            this.lblLogWarning.Text = "You must be logged in to start the game!";
            this.lblLogWarning.Visible = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1274, 655);
            this.Controls.Add(this.lblLogWarning);
            this.Controls.Add(this.dgvLeaderboard);
            this.Controls.Add(this.lblLeaderboard);
            this.Controls.Add(this.lblLogIn);
            this.Controls.Add(this.lblExitGame);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblTitle);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaderboard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblExitGame;
        private System.Windows.Forms.Label lblLogIn;
        private System.Windows.Forms.Label lblLeaderboard;
        private System.Windows.Forms.DataGridView dgvLeaderboard;
        private System.Windows.Forms.Label lblLogWarning;
    }
}
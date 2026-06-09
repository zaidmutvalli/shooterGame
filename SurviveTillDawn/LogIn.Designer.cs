namespace SurviveTillDawn
{
    partial class LogIn
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
            this.tboUsername = new System.Windows.Forms.TextBox();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.tboPassword = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblSign = new System.Windows.Forms.Label();
            this.lblBack = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tboUsername
            // 
            this.tboUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboUsername.Location = new System.Drawing.Point(589, 399);
            this.tboUsername.MaxLength = 20;
            this.tboUsername.Name = "tboUsername";
            this.tboUsername.Size = new System.Drawing.Size(550, 41);
            this.tboUsername.TabIndex = 0;
            this.tboUsername.TextChanged += new System.EventHandler(this.tboUsername_TextChanged);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.BackColor = System.Drawing.Color.Transparent;
            this.lblHeading.Font = new System.Drawing.Font("Showcard Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.White;
            this.lblHeading.Location = new System.Drawing.Point(745, 232);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(292, 98);
            this.lblHeading.TabIndex = 1;
            this.lblHeading.Text = "Log In";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(294, 390);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(239, 50);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Username:";
            // 
            // tboPassword
            // 
            this.tboPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboPassword.Location = new System.Drawing.Point(589, 477);
            this.tboPassword.MaxLength = 30;
            this.tboPassword.Name = "tboPassword";
            this.tboPassword.PasswordChar = '*';
            this.tboPassword.Size = new System.Drawing.Size(550, 41);
            this.tboPassword.TabIndex = 3;
            this.tboPassword.TextChanged += new System.EventHandler(this.tboPassword_TextChanged);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.BackColor = System.Drawing.Color.Transparent;
            this.lblPass.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.ForeColor = System.Drawing.Color.White;
            this.lblPass.Location = new System.Drawing.Point(294, 480);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(255, 50);
            this.lblPass.TabIndex = 4;
            this.lblPass.Text = "Password:";
            // 
            // lblSign
            // 
            this.lblSign.AutoSize = true;
            this.lblSign.BackColor = System.Drawing.Color.Transparent;
            this.lblSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSign.ForeColor = System.Drawing.Color.White;
            this.lblSign.Location = new System.Drawing.Point(589, 561);
            this.lblSign.Name = "lblSign";
            this.lblSign.Size = new System.Drawing.Size(393, 46);
            this.lblSign.TabIndex = 5;
            this.lblSign.Text = "No account? Sign up";
            this.lblSign.Click += new System.EventHandler(this.lblSign_Click);
            // 
            // lblBack
            // 
            this.lblBack.AutoSize = true;
            this.lblBack.BackColor = System.Drawing.Color.Transparent;
            this.lblBack.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBack.ForeColor = System.Drawing.Color.White;
            this.lblBack.Location = new System.Drawing.Point(298, 259);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(235, 50);
            this.lblBack.TabIndex = 6;
            this.lblBack.Text = "Main Menu";
            this.lblBack.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(729, 353);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(308, 32);
            this.lblInfo.TabIndex = 7;
            this.lblInfo.Text = "Press Enter to continue\r\n";
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SurviveTillDawn.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1063, 616);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblBack);
            this.Controls.Add(this.lblSign);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.tboPassword);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.tboUsername);
            this.Name = "LogIn";
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tboUsername;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox tboPassword;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblSign;
        private System.Windows.Forms.Label lblBack;
        private System.Windows.Forms.Label lblInfo;
    }
}
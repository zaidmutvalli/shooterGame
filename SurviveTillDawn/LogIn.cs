using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurviveTillDawn
{
    public partial class LogIn : Form
    {
        private bool accountExists = true;
        private MainMenu currentMenu;
        private string inputUsername;
        private string inputPassword;
        private string file;
        public string currentUser;
        public int currentHighScore;
        
        
        public LogIn(MainMenu menu)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            tboPassword.KeyDown += tboPassword_KeyDown;
            currentMenu = menu;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            lblSign.MouseEnter += lblSign_MouseEnter;
            lblSign.MouseLeave += lblSign_MouseLeave;
            lblBack.MouseEnter += lblBack_MouseEnter;
            lblBack.MouseLeave += lblBack_MouseLeave;
        }

        private void tboPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getDetails();
                e.SuppressKeyPress = true;

                if (accountExists)
                {
                    loginUser();
                }
                else
                {
                    if (Database.GetUser(inputUsername) != null)
                    {
                        MessageBox.Show("An account with this username already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Database.InsertUser(inputUsername, inputPassword);
                        MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        currentUser = inputUsername;
                        currentHighScore = 0;
                        currentMenu.setUser(currentUser);
                        currentMenu.setHighScore(currentHighScore);
                        currentMenu.Show();
                        this.Hide();
                    }
                }
            }



        }


        private void tboUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSign_Click(object sender, EventArgs e)
        {
            if (accountExists)
            {
                accountExists = false;
                lblHeading.Text = "Sign up";
                lblSign.Text = "Account exists? Log in";
            }
            else
            {
                accountExists = true;
                lblHeading.Text = "Log In";
                lblSign.Text = "No account? Sign up";
            }

        }

        private void lblSign_MouseEnter(object sender, EventArgs e)
        {
            lblSign.ForeColor = Color.Brown;
            currentMenu.playButton();
        }

        private void lblSign_MouseLeave(object sender, EventArgs e)
        {
            lblSign.ForeColor = Color.White;
        }

        private string getPath()
        {
            //method to obtain file path
            string path = Directory.GetCurrentDirectory();
            string filename = path + @"\userDatabase.csv";
            return filename;
        }

        private void getDetails()
        { 
           
            inputUsername = tboUsername.Text;
            inputPassword = tboPassword.Text;
        }

        private void loginUser()
        {
            User user = Database.GetUser(inputUsername);

            if (user != null && user.Password == inputPassword)
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentUser = user.Username;
                currentHighScore = user.HighScore;

                currentMenu.setUser(currentUser);
                currentMenu.setHighScore(currentHighScore);
                currentMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tboPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            currentMenu.Show();
            this.Hide();
        }

        private void lblBack_MouseEnter(object sender, EventArgs e)
        {
            lblBack.ForeColor = Color.Brown;
            currentMenu.playButton();
        }

        private void lblBack_MouseLeave(object sender, EventArgs e)
        {
            lblBack.ForeColor = Color.White;
        }
    }
}

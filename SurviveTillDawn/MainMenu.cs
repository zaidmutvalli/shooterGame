using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SurviveTillDawn
{
    public partial class MainMenu : Form
    {
        private AudioFileReader backgroundMusicReader;
        private WaveOutEvent backgroundMusicPlayer;
        private bool gameStarted = false;
        private bool musicShouldLoop = true;
        private bool musicIsPlaying = false;
        private List<(string, int)> highScores = new List<(string, int)>();
        private int highScore;
        private string user;
        private bool userLogged = false;
        public MainMenu()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            

        }

        public void setHighScore(int highest)
        {
            this.highScore = highest;
        }
        public int getHighScore() 
        { 
            return this.highScore;
        }
        public void setUser(string user)
        { 
            this.user = user;
            userLogged = true;
            lblLogWarning.Visible = false;
        }
        public string getUser()
        {
            return this.user;
        }
        public void PlayBackgroundMusic()
        {
            stopBackgroundMusic(); // Clean up any existing music first

            backgroundMusicReader = new AudioFileReader("menuMusic.mp3");
            backgroundMusicPlayer = new WaveOutEvent();
            backgroundMusicPlayer.Init(backgroundMusicReader);

            backgroundMusicPlayer.PlaybackStopped += (s, e) =>
            {
                if (musicShouldLoop)
                {
                    backgroundMusicReader.Position = 0;
                    backgroundMusicPlayer.Play(); // Only loop if allowed
                }
            };

            musicShouldLoop = true; // allow looping
            backgroundMusicPlayer.Play();
            musicIsPlaying = true;
        }
        public void stopBackgroundMusic()
        {
            musicShouldLoop = false; // disable looping

            if (backgroundMusicPlayer != null)
            {
                backgroundMusicPlayer.Stop(); // will trigger PlaybackStopped, but looping is off
                backgroundMusicPlayer.Dispose();
                backgroundMusicPlayer = null;
            }

            if (backgroundMusicReader != null)
            {
                backgroundMusicReader.Dispose();
                backgroundMusicReader = null;
            }

            musicIsPlaying = false;


        }
        public void hasGameStarted(bool gameStarted)
        {
            this.gameStarted = gameStarted;
        }


        private void MainMenu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            lblStart.Click += lblStart_Click;
            lblStart.MouseEnter += lblStart_MouseEnter;
            lblStart.MouseLeave += lblStart_MouseLeave;
            lblExitGame.MouseEnter += lblExitGame_MouseEnter;
            lblExitGame.MouseLeave += lblExitGame_MouseLeave;
            gameStarted = false;
            PlayBackgroundMusic();
            lblLogIn.MouseEnter += lblLogIn_MouseEnter;
            lblLogIn.MouseLeave += lblLogIn_MouseLeave;
            lblLeaderboard.MouseEnter += lblLeaderboard_MouseEnter;
            lblLeaderboard.MouseLeave += lblLeaderboard_MouseLeave;
        }

        private void lblStart_Click(object sender, EventArgs e)
        {
            
            

            if (!gameStarted && userLogged)
            {
                stopBackgroundMusic();
                GameScreenDesign gameScreen = new GameScreenDesign(this);

                gameScreen.Shown += (s, args) =>
                {
                    // This happens after GameScreen is fully loaded and visible
                    this.Hide(); // or this.Close() if you're done with the MainMenu
                };
                gameStarted = true;
                gameScreen.Show();
                
            }
            else if (!userLogged)
            {
                lblLogWarning.Visible = true;
                return;
            }

        }
        private void lblStart_MouseEnter(object sender, EventArgs e)
        {
            lblStart.ForeColor = Color.Brown; // highlight on hover#
            playButton();
        }

        private void lblStart_MouseLeave(object sender, EventArgs e)
        {
            lblStart.ForeColor = Color.White; // reset when not hovered
        }

        private void lblExitGame_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show(
        "Are you sure you want to quit the game?",
        "Confirm Exit",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );
            if (result == DialogResult.No)
            {

           
                this.ActiveControl = null;
                this.Focus();
            }
            if (result == DialogResult.Yes)
            {
                Application.Exit(); 
            }
        }
        private void lblExitGame_MouseEnter(object sender, EventArgs e)
        {
            lblExitGame.ForeColor = Color.Brown; // highlight on hover#
            playButton();
        }

        private void lblExitGame_MouseLeave(object sender, EventArgs e)
        {
            lblExitGame.ForeColor = Color.White; // reset when not hovered
        }

        public void playButton()
        {
            AudioFileReader sound = new AudioFileReader("buttonSound.mp4");
            WaveOutEvent buttonSound = new WaveOutEvent();
            buttonSound.Init(sound);
            buttonSound.Play();

            // Clean up after playback finishes
            buttonSound.PlaybackStopped += (s, args) =>
            {
                buttonSound.Dispose();
                buttonSound.Dispose();
            };
        }

        private void lblLogIn_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn(this);
            logIn.Shown += (s, args) =>
            {
                // This happens after LogIn is fully loaded and visible
                this.Hide(); // or this.Close() if you're done with the MainMenu
            };
            logIn.Show();
            this.Hide();
        }
        private void lblLogIn_MouseEnter(object sender, EventArgs e)
        {
            lblLogIn.ForeColor = Color.Brown;
            playButton();
        }

        private void lblLogIn_MouseLeave(Object sender, EventArgs e)
        {
            lblLogIn.ForeColor = Color.White;
        }

        private void lblLeaderboard_Click(object sender, EventArgs e)
        {
            if (dgvLeaderboard.Visible == false)
            {
                lblLeaderboard.Text = "Hide Leaderboard";
                displayLeaderboard();
            }
            else
            {
                lblLeaderboard.Text = "View Leaderboard";
                dgvLeaderboard.Visible = false;
            }
            
        }

        private void lblLeaderboard_MouseEnter(Object sender, EventArgs e)
        {
            lblLeaderboard.ForeColor = Color.Brown;
            playButton();
        }

        private void lblLeaderboard_MouseLeave(object sender, EventArgs e)
        {
            lblLeaderboard.ForeColor= Color.White;
        }

        private void dgvLeaderboard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void displayLeaderboard()
        {
            highScores.Clear(); // Clear previous scores

            string dbPath = @"D:\ZaidPrograms\PrType2 - Copy\SurviveTillDawn\bin\Debug\Users.db"; // 🔁 Replace with your actual DB path
            string connString = $"Data Source={dbPath};Version=3;";

            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                string query = "SELECT Username, HighScore FROM userData ORDER BY HighScore DESC";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string username = reader["Username"].ToString();
                        int highScore = Convert.ToInt32(reader["HighScore"]);
                        highScores.Add((username, highScore));
                    }
                }
            }

            dgvLeaderboard.DataSource = highScores
                .Select(x => new { Username = x.Item1, Score = x.Item2 })
                .ToList();

            dgvLeaderboard.Visible = true;
        }

        private string getFilePath()
        {
            //method to obtain file path
            string path = Directory.GetCurrentDirectory();
            string filename = path + @"\userDatabase.csv";
            return filename;
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurviveTillDawn
{
    public partial class GameScreenDesign : Form
    {
        //player object instantiated from character class
        private Character player;
        private int kills; int ammo = 7;  int powerTime = 320; int powerDrop = 600;
        private bool moveUp, moveDown, moveLeft, moveRight, gameEnded, droppedAmmo = false, droppedHealth = false, droppedPowerUp = false;
        private string direction;
        private Random range = new Random();
        // list created for all zombies
        private List<Zombie> zombies = new List<Zombie>();
        // bullet instantiated and list created for all bullets
        private Bullet bullet;
        private List<Bullet> bullets = new List<Bullet>();
        private Sprite ammoCrate, healthKit, powerUp;
        private List<string> powerUpLocations = new List<string>();
        private List<Sprite> powerUps = new List<Sprite>();
        private string[] powerUpNames = { "lightning", "shield" };
        private string powerName;
        private bool superSpeed = false; bool Invincibilty;
        private int cameraX = 0; int cameraY = 0;
        private int maxWidth = 600; int maxHeight;
        private bool restrictMovement = false; bool restrictCamera = false;
        private List<Wall> walls = new List<Wall>();
        private bool cameraRestrict = false;
        private bool zombieRestrict = false;
        private int minCameraX = 0; int maxCameraX = 1000;
        private int minCameraY = 0; int maxCameraY = 900;
        private int[] wallCoords = new int[2];
        private int healthTimer = 300; int ammoDrop = 300;
        private Sprite miniMap;
        private int miniMapX;
        private int miniMapY;



        private string getFilePath()
        {
            string path = Directory.GetCurrentDirectory();
            string filename = path + @"\wallCoordinates.csv";
            return filename;
        }

        private void makeWall(string file)
        {
            file = getFilePath();
            TextReader reader = new StreamReader(file);
            string line;
            //List<string> row = new List<string>();
            string[] row = new string[4];
            reader.ReadLine();
            while ((line = reader.ReadLine()) != null)
            {
                row = line.Split(',');
                
                int x = Convert.ToInt32(row[0]) ;
                int y = Convert.ToInt32(row[1]);
                int width = Convert.ToInt32(row[2]);
                int height = Convert.ToInt32(row[3]);
                Wall wall = new Wall(x, y, width, height);
                wallCoords[0] = x;
                wallCoords[1] = y;
                walls.Add(wall);
            }
            reader.Close();

        }
        private void GameScreenDesign_Load(object sender, EventArgs e)
        {

        }

        private void pboCurrentInfo_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        //private void KeyDown(object sender, KeyEventArgs e)
        //{
 
            
        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DownPressed(object sender, KeyEventArgs e)
        {
            // event detects if a key has been pressed and sets booleans to true
            // sets player to 15 to move the player
            
                if (e.KeyCode == Keys.Left)
                {
                    moveLeft = true;
                    direction = "left";
                    if (superSpeed)
                    {
                        player.setSpeed(25);
                    }
                    if (superSpeed == false)
                    {
                        player.setSpeed(15);
                    }
                }
                if (e.KeyCode == Keys.Right)
                {
                    moveRight = true;
                    direction = "right";
                    if (superSpeed) //&& restrictMovement == false)
                    {
                        player.setSpeed(25);
                    }
                    if (superSpeed == false)
                    {
                        player.setSpeed(15);
                    }
                }
                if (e.KeyCode == Keys.Up)
                {
                    moveUp = true;
                    direction = "up";
                    if (superSpeed && restrictMovement == false)
                    {
                        player.setSpeed(25);
                    }
                    if (restrictMovement == false && superSpeed == false)
                    {
                        player.setSpeed(15);
                    }
                }
                if (e.KeyCode == Keys.Down)
                {
                    moveDown = true;
                    direction = "down";
                    if (superSpeed && restrictMovement == false)
                    {
                        player.setSpeed(25);
                    }
                    if (restrictMovement == false && superSpeed == false)
                    {
                        player.setSpeed(15);
                    }
                }
            
            
        }

        private void LiftPressed(object sender, KeyEventArgs e)
        {
            // event detects if key has been lifted and sets boolean to false
            // sets player speed to 0
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveUp = false;
            }
            if (e.KeyCode == Keys.Down)
            { moveDown = false;}
            player.setSpeed(0);
            // if statement added to LiftPressed() to shoot if space is pressed.
            if(gameEnded == false && ammo > 0)
            {
                if (e.KeyCode == Keys.Space)
                {
                    ammo -= 1;
                    shoot();
                }
            }
        }

        public GameScreenDesign()
        {
            //main game screen constructor
            // background assigned
            // player object instantiated
            InitializeComponent();
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Height = 500;
            this.Width = 800;
            this.DoubleBuffered = true;
            this.pboCurrentInfo.Size = new System.Drawing.Size(1270, 60);
            player = new Character();
            powerUpLocations = Directory.GetFiles("powerups", "*png").ToList();
            makeWall(getFilePath());
            miniMap = new Sprite(miniMapX, miniMapY, 190, 190, 0);
            miniMap.setImage("miniMap.png");
        }

        private void PaintEvent(object sender, PaintEventArgs e)
        {
            // paint event used to draw player image on to the game screen
            Graphics Canvas = e.Graphics;

            Canvas.DrawImage(Image.FromFile("grey.png"), -cameraX, -cameraY, 3000, 1700);
            
            Canvas.DrawImage(player.getImage(), player.getX() - cameraX, player.getY() - cameraY, player.getWidth(), player.getHeight());
            // Draw zombies relative to the camera position
            foreach (Zombie zombie in zombies)
            {
                Canvas.DrawImage(zombie.getImage(), zombie.getX() - cameraX, zombie.getY() - cameraY, zombie.getWidth(), zombie.getHeight());
            }

            // Draw bullets relative to the camera position
            foreach (Bullet bullet in bullets)
            {
                Canvas.DrawImage(bullet.getImage(), bullet.getX() - cameraX, bullet.getY() - cameraY, bullet.getWidth(), bullet.getHeight());
            }

            // Draw power-ups, ammo crates, and health kits relative to the camera position
            if (droppedPowerUp)
            {
                Canvas.DrawImage(powerUp.getImage(), powerUp.getX() - cameraX, powerUp.getY() - cameraY, powerUp.getWidth(), powerUp.getHeight());
            }
            if (droppedAmmo)
            {
                Canvas.DrawImage(ammoCrate.getImage(), ammoCrate.getX() - cameraX, ammoCrate.getY() - cameraY, ammoCrate.getWidth(), ammoCrate.getHeight());
            }
            if (droppedHealth)
            {
                Canvas.DrawImage(healthKit.getImage(), healthKit.getX() - cameraX, healthKit.getY() - cameraY, healthKit.getWidth(), healthKit.getHeight());
            }
            Canvas.DrawImage(Image.FromFile("black.png"), -35 - cameraX, 10 - cameraY, 100, 1350);
            Canvas.DrawImage(Image.FromFile("black.png"), 1750 - cameraX, 10 - cameraY, 100, 1350);
            Canvas.DrawImage(Image.FromFile("black.png"), -35 - cameraX, 1300 - cameraY, 1875, 80);
            Canvas.DrawImage(Image.FromFile("black.png"), -35 - cameraX, 20 - cameraY, 1875, 80);
            

            foreach (Wall barrier in walls)
            {
                Canvas.DrawImage(barrier.getImage(), barrier.getX() - cameraX, barrier.getY() - cameraY, barrier.getWidth(), barrier.getHeight());
            }

            if (miniMap.getImage() != null)
            { 
                Canvas.DrawImage(miniMap.getImage(), miniMapX, miniMapY, 190, 190);
                foreach (Wall barrier in walls)
                {
                    Canvas.DrawImage(barrier.getImage(), (barrier.getX() / 10) + miniMapX, (barrier.getY() / 6) + miniMapY, barrier.getWidth() / 10, barrier.getHeight() / 6);
                }
            }
            
           // Canvas.DrawImage(Image.FromFile("minimap.png"), miniMapX, miniMapY , 190, 190);
           // foreach (Wall barrier in walls)
         //   {
          //     Canvas.DrawImage(barrier.getImage(), (barrier.getX()/ 10) + miniMapX, (barrier.getY()/ 6) + miniMapY, barrier.getWidth()/10, barrier.getHeight()/6);
           // }

        }

        private void GameLoop(object sender, EventArgs e)
        {
            
        //    miniMap = new Sprite(miniMapX, miniMapY, 190, 190, 0);
          //  miniMap.setImage("miniMap.png");
         //   if (CollisionOccurred(player.getX(), player.getY(), player.getWidth(), player.getHeight(),
       //         miniMap.getX(), miniMap.getY(), miniMap.getWidth(), miniMap.getHeight()))
      //      {
           //     miniMap.setImage(null);
         //   }
       // miniMap.setImage(null);
            
            if (player.getX() == 1600 || player.getY()== miniMapY)
            {
                miniMap.setImage(null);
            }
            miniMapX = this.ClientSize.Width - 170;
            miniMapY = this.ClientSize.Height - 410;
            zombieCollidesWithWall();
            zombieDirection();
            // labels set to display kill and ammo count
            boundControl();
            lblKills.Text = "Kills: " + kills.ToString();
            lblAmmo.Text = "Ammo: " + ammo.ToString();
            // if booleans are true, player movement direction is set
                cameraX = player.getX() - (this.ClientSize.Width / 2) + (player.getWidth() / 2);
                cameraY = player.getY() - (this.ClientSize.Height / 2) + (player.getHeight() / 2);
          
            if (cameraX < minCameraX)
           {
                cameraX = minCameraX;
            }
            else if (cameraX > maxCameraX)
            {
                cameraX = maxCameraX;
            }
            if (cameraY < minCameraY)
            {
                cameraY = minCameraY;
            }
            else if (cameraY > maxCameraY)
            {
                cameraY = maxCameraY;
            }
            if (superSpeed && restrictMovement == false || Invincibilty && restrictMovement == false )
            {
                if (moveLeft)
                {
                    player.playerSpeedAnimation(2, 3);
                }
                if (moveRight)
                {
                    player.playerSpeedAnimation(4, 5);
                }
                if (moveUp)
                {
                    player.playerSpeedAnimation(6, 7);
                }
                if (moveDown)
                {
                    player.playerSpeedAnimation(0, 1);
                }
                player.navigation(direction);
            }
            else if (restrictMovement == false && superSpeed == false)
            {
                if (moveLeft) { direction = "left"; }
                if (moveRight) {  direction = "right"; }
                if (moveUp) { direction = "up"; }
                if (moveDown) { direction = "down"; }
                player.face(direction);
            }
                SpawnZombie();
            huntCharacter();
            zombieAttack();
            checkHealth();
            killZombie();
            if (droppedAmmo) { pickAmmo(); }
            if (droppedHealth) { pickHealth(); }
            if (droppedPowerUp) { pickPowerUp(); }
            // bullets deleted after moving off screen
            foreach (Bullet bullet in bullets.ToList())
            {
                if (bullet.getImage() == null)
                {
                    bullets.Remove(bullet);
                }
            }
            if (ammo < 1 && droppedAmmo == false)
            {
                dropAmmo();
            }
            if (powerDrop < 1 && droppedPowerUp == false)
            {
                makePowerUp();
            }
            else
            {
                powerDrop--;
            }
            if (superSpeed || Invincibilty)
            {
                powerTime--;
                if (powerTime == 0)
                {
                    superSpeed = false;
                    Invincibilty = false;
                }

            }
            if (healthTimer < 1 && droppedHealth == false)
            {
                dropHealth();
            }
            else
            {
                healthTimer--;
            }
            if (ammoDrop < 1 && droppedAmmo == false)
            {
                dropAmmo();
            }
            else
            {
                ammoDrop--;
            }
            bulletHitsWall();
            if (player.getHealth() > 100)
            {
                player.setHealth(100);
            }
            this.Invalidate();
        }
        private void SpawnZombie()
        {
            // random co-ordinates assigned to zombies within boundaries
            int X = range.Next(60, 1500); 
            int Y = range.Next(110, 1000);
            if (zombies.Count < 5)
            {
                // if zombie count falls below 3, new zombies are spawned and added to list 
                Zombie zombie = new Zombie(X, Y, 4);
                zombies.Add(zombie);
            }
        }
        private void huntCharacter()
        {
            foreach (Zombie zombie in zombies)
            {
                            
                    if (zombie.getX() < player.getX())
                    {
                        if(zombie.isMovementAllowed())
                        {
                             zombie.moveZombie("right");
                        }
                       
                    }
                    if (zombie.getX() > player.getX())
                    {
                        if (zombie.isMovementAllowed())
                        {
                            zombie.moveZombie("left");
                         }
                }
                    if (zombie.getY() < player.getY())
                    {
                        if (zombie.isMovementAllowed())
                        {
                            zombie.moveZombie("down");
                        }
                   
                    }
                    if (zombie.getY() > player.getY())
                    {
                        if (zombie.isMovementAllowed())
                        {
                             zombie.moveZombie("up");
                        }
                    }
                
            }
        }
        private bool CollisionOccurred(int firstX, int firstY, int firstWidth, int firstHeight, 
            int secondX, int secondY, int secondWidth, int secondHeight)
        {//check if two objects have collided by looking at the x and y coordinates
            if (firstX + firstWidth <= secondX || firstX >= secondX + secondWidth || 
                firstY + firstHeight <= secondY || firstY >= secondY + secondHeight)
            {
                return false; // no collision
            }
            else
            {
                return true; // found collision
            }
        }

        private void zombieAttack()
        {
            foreach (Zombie zombie in zombies)
            {
                if (CollisionOccurred(player.getX(), player.getY(), player.getWidth(), player.getHeight(), 
                    zombie.getX(), zombie.getY(), zombie.getWidth(), zombie.getHeight()) && Invincibilty == false)
                {
                    player.zombieDamage();
                }
            }  if (player.getHealth() >= 0)
               {
                prgHealth.Value = player.getHealth();
               }
               else { prgHealth.Value = 0; }
        }  
        private void killZombie()
        {
            foreach (Zombie zombie in zombies.ToList())
            {
                foreach (Bullet bullet in bullets.ToList())
                {
                    if (CollisionOccurred(zombie.getX(), zombie.getY(), zombie.getWidth(), 
                        zombie.getHeight(), bullet.getX(), bullet.getY(), 
                        bullet.getWidth(), bullet.getHeight()))
                    {
                        kills++;
                        bullets.Remove(bullet);
                        zombies.Remove(zombie);
                        SpawnZombie();
                    }
                }
            }
        }


        private void checkHealth()
        {
            // program constantly checks player health
            if (player.getHealth() <= 0)
            {
                endGame();
            }
        }

        private void lblKills_Click(object sender, EventArgs e)
        {

        }

        private void dropHealth()
        {
            // assigns random co-ordinates to health kit
            int X = range.Next(60, 1500);
            int Y = range.Next(110, 1000);
            // instantiates health kit based on sprite class
            healthKit = new Sprite(X, Y, 50, 50, 0);
            // sets image
            healthKit.setImage("healthKit.png");
            // makes bool true
            droppedHealth = true;

        }
        private void pickHealth()
        {
            // detects collision between player and healthkit
            if (CollisionOccurred(player.getX(), player.getY(), 
                player.getWidth(), player.getHeight(), healthKit.getX(), 
                healthKit.getY(), healthKit.getWidth(), healthKit.getHeight()))
            {
                // increases player health
                int health = player.getHealth() + 40;
                player.setHealth(health);
                // deletes healthkit image and makes bool false
                healthKit.setImage(null);
                droppedHealth = false;
                //resets health timer
                healthTimer = 300;

            }
        }
        private void pickAmmo()
        {
            // if player collides with ammo crate, it is picked up
            // ammo count increases and the crate disappears
            if (CollisionOccurred(player.getX(), player.getY(), player.getWidth(), 
                player.getHeight(), ammoCrate.getX(), ammoCrate.getY(), 
                ammoCrate.getWidth(), ammoCrate.getHeight()))
            {
                ammo += 7;
                ammoCrate.setImage(null);
                droppedAmmo = false;
                //resets ammo timer
                ammoDrop = 300;
            }
        }

        private void pboMiniMap_Click(object sender, EventArgs e)
        {

        }

        private void shoot()
        {
            // bullet shot in same direction as player facing
            // bullet added to list of bullets after instantiation
            bullet = new Bullet(direction, player.getX() + (player.getWidth() / 2), player.getY() + (player.getHeight() / 2));
            bullet.face(direction);
            bullets.Add(bullet);
        }

        private void dropAmmo()
        {
            // random co-ordinates assigned to ammo crate
            int X = range.Next(60, 1500);
            int Y = range.Next(110, 1000);
            // ammo crate instantiated based on sprite class
            ammoCrate = new Sprite(X, Y, 50, 100, 0);
            ammoCrate.setImage("ammoCrate.png");
            droppedAmmo = true;
           
        }
        private void makePowerUp()
        {
            int i = range.Next(0, powerUpLocations.Count());
            int X = range.Next(60, 1500);
            int Y = range.Next(110, 1000);
            powerUp = new Sprite(X, Y, 50, 100, 0);
            powerUp.setImage(powerUpLocations[i]);
            powerName = powerUpNames[i];
            droppedPowerUp = true;
        }

        private void pickPowerUp()
        {
            {
                if (CollisionOccurred(player.getX(), player.getY(), player.getWidth(), player.getHeight(), 
                    powerUp.getX(), powerUp.getY(), powerUp.getWidth(), powerUp.getHeight()))
                {
                    switch (powerName)
                    {
                        case "lightning":
                            superSpeed = true;
                            break;

                        case "shield":
                            Invincibilty = true;
                            break;

                    }
                    powerTime = 400;
                    powerDrop = 600;
                    powerUp.setImage(null);
                    powerUps.Remove(powerUp);
                    droppedPowerUp = false;
                    player.setPower(powerName);
                }
            }
        }

        private void boundControl()
        {

            int minX = 45; 
            int maxX = 1675; 
            int minY = 100; 
            int maxY = 1230; 

            if (player.getX() <= minX && direction == "left" || player.getX() >= maxX && direction == "right"
               || (player.getY() <= minY && direction == "up" || (player.getY() >= maxY && direction == "down")))
            { 
                restrictMovement = true;
                if (player.getY() > maxY)
                {
                    player.setY(maxY);
                }
                if (player.getY() < minY)
                {
                    player.setY(minY);
                }
            }

            else
            {
                restrictMovement = false;
            }

            foreach (Wall barrier in walls.ToList())
            {
                if (CollisionOccurred(player.getX(), player.getY(), player.getWidth(), player.getHeight(),
                    barrier.getX(), barrier.getY(), barrier.getWidth(), barrier.getHeight()))
                {
                    if (barrier.getX() < player.getX() && direction == "left" ||
                        barrier.getX() > player.getX() && direction == "right"||
                        barrier.getY() < player.getY() && direction == "up"||
                        barrier.getY() > player.getY() && direction == "down") 
                    { 
                        restrictMovement = true;
                        
                    }
                }
            }
        }

        private void bulletHitsWall()
        {
            foreach (Bullet shot in bullets.ToList())
            {
                foreach (Wall barrier in walls.ToList())
                {
                    if (CollisionOccurred(shot.getX(), shot.getY(), shot.getWidth(), shot.getHeight(),
                    barrier.getX(), barrier.getY(), barrier.getWidth(), barrier.getHeight()))
                    {
                        bullets.Remove(shot);
                    }
                }
            }
        }

        private void zombieCollidesWithWall()
        {
            foreach (Zombie zombie in zombies.ToList())
            {
                foreach (Wall barrier in walls.ToList())
                {
                    if (CollisionOccurred(zombie.getX(), zombie.getY(), zombie.getWidth(), zombie.getHeight(),
                        barrier.getX(), barrier.getY(), barrier.getWidth(), barrier.getHeight()))
                    {
                        if (zombie.getX() > barrier.getX() && zombie.getHorizontalDirection() == "left" ||
                           zombie.getX() < barrier.getX() && zombie.getHorizontalDirection() == "right" ||
                           zombie.getY() > (barrier.getY())  && zombie.getVerticalDirection() == "up" ||
                           zombie.getY() < (barrier.getY()) && zombie.getVerticalDirection() == "down")
                        { zombie.setMovement(false); } 
                        else { zombie.setMovement(true); }
                    }
                }
            }
        }

        private void zombieDirection()
        {
            foreach (Zombie enemy in zombies.ToList())
            {
                if (enemy.getX() < player.getX())// && enemy.getY() == player.getY())
                {
                    enemy.setHorizontalDirection("right");
                }
                if (enemy.getX() > player.getX())// && enemy.getY() == player.getY())
                {
                    enemy.setHorizontalDirection("left");
                }
                if (enemy.getY() < player.getY())// && enemy.getY() == player.getY())
                {
                    enemy.setVerticalDirection("down");
                }
                if (enemy.getY() > player.getY())// && enemy.getY() == player.getY())
                {
                    enemy.setVerticalDirection("up");
                }
            }
        }

        private void endGame()
        {
            player.setImage("grave.png");
            gameEnded = true;
            lblAmmo.Text = "You died!";
            GameLoopTimer.Stop();
        }
    }
}

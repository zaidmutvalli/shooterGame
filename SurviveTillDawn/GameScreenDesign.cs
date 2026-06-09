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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using NAudio.Wave;

namespace SurviveTillDawn
{
    public partial class GameScreenDesign : Form
    {
        //player object instantiated from character class
        private Character player;
        private int kills; int ammo = 10;  int powerTime = 320; int powerDrop = 600;
        private bool moveUp, moveDown, moveLeft, moveRight, gameEnded, droppedAmmo = false, droppedHealth = false, droppedPowerUp = false;
        private string direction;
        private Random range = new Random();
        // list created for all zombies
        private List<Zombie> zombies = new List<Zombie>();
        // bullet instantiated and list created for all bullets
        private Bullet bullet;
        private List<Bullet> bullets = new List<Bullet>();
        //sprites instantiated for spawn items
        private Sprite ammoCrate, healthKit, powerUp;
        //location of powerups stored in a list
        private List<string> powerUpLocations = new List<string>();
        //all present powerups added to the list
        private List<Sprite> powerUps = new List<Sprite>();
        //names of powerups stored in an array
        private string[] powerUpNames = { "lightning", "shield" };
        //name of current powerup held in this variable
        private string powerName;
        //boolean variables inform the program which powerup is active
        private bool superSpeed = false; bool Invincibilty;
        //camera coordinates used to scroll map
        private int cameraX = 0; int cameraY = 0;
        //boolean variables prevent character and camera movement
        private bool restrictMovement = false; bool restrictCamera = false;
        private List<Wall> walls = new List<Wall>(); //list of walls created
        private int healthTimer = 300; int ammoDrop = 300; //cool down timers in between spawn
        private Sprite miniMap; //instance of mini map
        private int miniMapX; //mini map coordinates
        private int miniMapY;
        private string[] arrowImages; //arrow images stored in array
        private int arrowIndex; //current arrow index stored
        private Sprite arrow; //instance of arrow
        private int arrowX; int arrowY; //arrow coordinates stored
        private Node[,] grid; //grid initialised for heuristic calculations
        private List<Node> unWalkableNodes = new List<Node>(); //list of unwalkable nodes
        private bool imageNotFound = false; //image validation boolean
        private bool paused = false;
        private AudioFileReader backgroundMusicReader;
        private WaveOutEvent backgroundMusicPlayer;
        private int miniMapWidth = 210;
        private int miniMapHeight = 50;

        // Position the mini-map near the top-right corner, with a small margin
        private int miniMapYMargin = 94; int miniMapXMargin = 40;
        private bool gamePaused = false;
        private bool musicShouldLoop = true;
        private bool musicIsPlaying = false;
        private MainMenu menu;
        private Image red = Image.FromFile("red.png");
        private Image healthA = Image.FromFile("healthA.png");
        private Image ammoA = Image.FromFile("ammoA.png");
        private Image powerA = Image.FromFile("powerA.png");
        private Image grey = Image.FromFile("grey.png");
        private Image black = Image.FromFile("black.png");
        private Image ammoLBL = Image.FromFile("ammoLBL.png");
        private Image skull = Image.FromFile("skull.png");
        private bool scoreSet = false; bool closedGame = false;
        private string getFilePath()
        {
            //method to obtain file path
            string path = Directory.GetCurrentDirectory();
            string filename = path + @"\wallCoordinates.csv";
            return filename;
        }

        private void makeWall(string file)
        {
            //method reads wall information from csv file
            file = getFilePath();
            TextReader reader = new StreamReader(file);//file opened for reading
            string line;
            string[] row = new string[4];
            reader.ReadLine();
            while ((line = reader.ReadLine()) != null)
            {
                row = line.Split(',');
                //wall information accessed from each field
                int x = Convert.ToInt32(row[0]);
                int y = Convert.ToInt32(row[1]);
                int width = Convert.ToInt32(row[2]);
                int height = Convert.ToInt32(row[3]);
                Wall wall = new Wall(x, y, width, height);
                walls.Add(wall);
            }
            reader.Close(); //file closed

        }
        private void GameScreenDesign_Load(object sender, EventArgs e)
        {
            InitGameUI();
           // InitGameLogic(); // if you have other logic to reset game variables, etc.
        }

        private void InitGameUI()
        {
            lblPause.MouseEnter += lblPause_MouseEnter;
            lblPause.MouseLeave += lblPause_MouseLeave;

            lblHealth.Parent = pboCurrentInfo;
            lblAmmo.Parent = pboCurrentInfo;
            lblKills.Parent = pboCurrentInfo;
            lblPause.Parent = pboCurrentInfo;
            lblRestart.MouseEnter += lblRestart_MouseEnter;
            lblRestart.MouseLeave += lblRestart_MouseLeave;
            pboCurrentInfo.Paint += pboCurrentInfo_Paint;
        }

        private void lblPause_MouseEnter(object sender, EventArgs e)
        {
            lblPause.ForeColor = Color.Brown;
            playButtonSound();
        }
        private void lblPause_MouseLeave(object sender, EventArgs e)
        {
            lblPause.ForeColor= Color.White;
        }
        private void lblRestart_MouseEnter(Object sender, EventArgs e)
        {
            lblRestart.ForeColor = Color.Brown;
            playButtonSound();
        }
        private void lblRestart_MouseLeave(Object sender, EventArgs e)
        {
            lblRestart.ForeColor = Color.White;
        }

        private void pboCurrentInfo_Click(object sender, EventArgs e)
        {
            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DownPressed(object sender, KeyEventArgs e)
        {

            // event detects if a key has been pressed and sets booleans to true
            // sets player to 15 to move the player
            if (restrictMovement)
            {
                player.setSpeed(0);
            }
            if (superSpeed)
            {
                player.setSpeed(25);
            }
            if (superSpeed == false)
            {
                player.setSpeed(15);
            }
            if (e.KeyCode == Keys.Left)
                {
                    //key event for left arrow key
                    moveLeft = true;
                moveRight = moveUp = moveDown = false; 
                    
                }
                if (e.KeyCode == Keys.Right)
                {
                    //key event for right arrow key
                    moveRight = true;
                moveLeft= moveUp = moveDown = false;

            }
                if (e.KeyCode == Keys.Up)
                {
                    //key event for up arrow key
                    moveUp = true;
                moveRight = moveLeft = moveDown = false;

            }
                if (e.KeyCode == Keys.Down)
                {
                    //key event for down arrow key

                    moveDown = true;
                moveRight = moveUp = moveLeft = false;

            }

            

            // Other key events
            if (ammo == 0 && e.KeyCode == Keys.Space)
            {
                PlaySound("noAmmoSound.mp3");
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
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
            if(gameEnded == false && ammo > 0 && !gamePaused)
            {
                if (e.KeyCode == Keys.Space)
                {
                    shoot();
                    ammo -= 1;
                }
            }
            
            
        }

        public GameScreenDesign(MainMenu menu)
        {
            //main game screen constructor
            // background assigned
            // player object instantiated
            InitializeComponent();
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Height = 500;
            this.Width = 800;
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            // this.pboCurrentInfo.Size = new System.Drawing.Size(this.ClientSize.Width, 60);
            player = new Character();
            makeWall(getFilePath());
            miniMap = new Sprite(miniMapX, miniMapY, 190, 190, 0); //mini map initialised
            arrow = new Sprite(arrowX, arrowY, 8, 8, 0); //arrow sprite initialised
            InitializeGrid(walls); //grid initialised
            PlayBackgroundMusic();
            this.FormBorderStyle = FormBorderStyle.None; // Removes title bar
            this.WindowState = FormWindowState.Maximized; // Maximizes to full screen
            this.TopMost = true; // Optional: forces window to stay on top
            this.menu = menu;
            lblMenu.MouseEnter += lblMenu_MouseEnter;
            lblExit.MouseEnter += lblExit_MouseEnter;
            lblMenu.MouseLeave += lblMenu_MouseLeave;
            lblExit.MouseLeave += lblExit_MouseLeave;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            pboCurrentInfo.Size = new Size(this.ClientSize.Width + 20, 120);
            pnlPause.Left = (this.ClientSize.Width - pnlPause.Width) / 2;
            pnlPause.Top = (this.ClientSize.Height - pnlPause.Height) / 2;
            
            
        }

        private void InitializeGrid(List<Wall> walls)
        {
            int gridWidth = 25;   // Grid width
            int gridHeight = 20;  // Grid height

            // Create a new grid of Node objects
            grid = new Node[gridWidth, gridHeight];

            // Initialize each grid node as walkable by default
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    grid[x, y] = new Node(x, y, true);
                }
            }

            // Calculate buffer needed to keep zombies out of upper/lower wall edges
            int bufferX = player.getWidth() / 40;  // Convert zombie width to grid units
            int bufferY = player.getHeight() / 40; // Convert zombie height to grid units

            // Iterate over each wall and mark unwalkable nodes
            foreach (Wall wall in walls)
            {
                // Calculate bounds for each wall including the buffer
                int wallStartX = wall.getX() / 80 - bufferX;
                int wallEndX = wallStartX + (wall.getWidth() / 80) + 2 * bufferX;
                int wallStartY = wall.getY() / 80 - bufferY;
                int wallEndY = wallStartY + (wall.getHeight() / 80) + 2 * bufferY;

                // Mark each node within the wall bounds as unwalkable
                for (int x = Math.Max(0, wallStartX); x < Math.Min(gridWidth, wallEndX); x++)
                {
                    for (int y = Math.Max(0, wallStartY); y < Math.Min(gridHeight, wallEndY); y++)
                    {
                        if (x >= 0 && x < gridWidth && y >= 0 && y < gridHeight)
                        {
                            grid[x, y] = new Node(x, y, false);  // Mark as unwalkable
                            unWalkableNodes.Add(grid[x, y]);
                        }
                    }
                }
            }
        }


        private void pboCurrentInfo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Draw ammo
            Point ammoStart = new Point(lblAmmo.Location.X - 25, lblAmmo.Top - 70);
            
                g.DrawImage(ammoLBL, ammoStart.X, ammoStart.Y, 200, 200);
            

            // Kill icons next to kills label
            Point killStart = new Point(lblKills.Location.X - 25, lblKills.Top - 80);
            
                g.DrawImage(skull, killStart.X, killStart.Y, 200, 200);
            
        }


        private void PaintEvent(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;
            //Canvas.DrawImage()
            // paint event used to draw player image on to the game screen
            
                if (!player.imageNotFound() && !imageNotFound)
                {
                    Canvas.DrawImage(grey, -cameraX, -cameraY, 3000, 1700);

                    Canvas.DrawImage(player.getImage(), player.getX() - cameraX, player.getY() - cameraY, player.getWidth(), player.getHeight());
                    // Draw zombies relative to the camera position
                    foreach (Zombie zombie in zombies)
                    {
                        Canvas.DrawImage(zombie.getImage(), zombie.getX() - cameraX, zombie.getY() - cameraY, zombie.getWidth(), zombie.getHeight());
                    }

                    // Draw bullets relative to the camera position
                    foreach (Bullet bullet in bullets)
                    {
                        if (bullet.getImage() != null)
                        {
                            Canvas.DrawImage(bullet.getImage(), bullet.getX() - cameraX, bullet.getY() - cameraY, bullet.getWidth(), bullet.getHeight());
                        }
                        
                    }

                    // Draw power-ups relative to the camera position
                    if (droppedPowerUp)
                    {
                        Canvas.DrawImage(powerUp.getImage(), powerUp.getX() - cameraX, powerUp.getY() - cameraY, powerUp.getWidth(), powerUp.getHeight());
                    }
                    // Draw ammo crates relative to the camera position
                    if (droppedAmmo)
                    {
                        Canvas.DrawImage(ammoCrate.getImage(), ammoCrate.getX() - cameraX, ammoCrate.getY() - cameraY, ammoCrate.getWidth(), ammoCrate.getHeight());
                    }
                    // Draw health kits relative to the camera position
                    if (droppedHealth)
                    {
                        Canvas.DrawImage(healthKit.getImage(), healthKit.getX() - cameraX, healthKit.getY() - cameraY, healthKit.getWidth(), healthKit.getHeight());
                    }
                    Canvas.DrawImage(black, -35 - cameraX, 10 - cameraY, 100, 1350);
                    Canvas.DrawImage(black, 1750 - cameraX, 10 - cameraY, 100, 1350);
                    Canvas.DrawImage(black, -35 - cameraX, 1300 - cameraY, 1875, 80);
                    Canvas.DrawImage(black, -35 - cameraX, 20 - cameraY, 1875, 80);

                    // Draw walls relative to the camera position
                    foreach (Wall barrier in walls)
                    {
                        Canvas.DrawImage(barrier.getImage(), barrier.getX() - cameraX, barrier.getY() - cameraY, barrier.getWidth(), barrier.getHeight());
                    }

                    //mini map drawn with abstracted images
                    if (miniMap.getImage() != null)
                    {
                        Canvas.DrawImage(miniMap.getImage(), miniMapX, miniMapY, 310, 265);
                        foreach (Wall barrier in walls.ToList())
                        {
                            Canvas.DrawImage(barrier.getImage(), (barrier.getX() / 10) + miniMapX, (barrier.getY() / 6) + miniMapY, barrier.getWidth() / 10, barrier.getHeight() / 6);
                        }
                        Canvas.DrawImage(arrow.getImage(), (player.getX() / 10) + miniMapX, (player.getY() / 6) + miniMapY, player.getWidth() / 8, player.getHeight() / 5);
                        foreach (Zombie opponent in zombies.ToList())
                        {
                            //division carried out to make images proportionally sized
                            Canvas.DrawImage(red, (opponent.getX() / 10) + miniMapX, (opponent.getY() / 6) + miniMapY, opponent.getWidth() / 10, opponent.getHeight() / 6);
                        }
                        if (droppedHealth)
                        {
                            Canvas.DrawImage(healthA, (healthKit.getX() / 10) + miniMapX, (healthKit.getY() / 6) + miniMapY, healthKit.getWidth() / 4, healthKit.getHeight() / 4);
                        }
                        if (droppedAmmo)
                        {
                            Canvas.DrawImage(ammoA, (ammoCrate.getX() / 10) + miniMapX, (ammoCrate.getY() / 6) + miniMapY, ammoCrate.getWidth() / 5, ammoCrate.getHeight() / 5);
                        }
                        if (droppedPowerUp)
                        {
                            Canvas.DrawImage(powerA, (powerUp.getX() / 10) + miniMapX, (powerUp.getY() / 6) + miniMapY, powerUp.getWidth() / 3, powerUp.getHeight() / 5);
                        }


                    }


                

            }
            
            
            
        }
        private void mapScroll()
        {
            int minX = 45; //limiting coordinates set
            int maxX = 1675;
            int minY = 100;
            int maxY = 1230;
            int minCameraX = 0; int maxCameraX = 1800 - this.ClientSize.Width; //coordinates to limit map size
         int minCameraY = 0; int maxCameraY = 1350 - this.ClientSize.Height;
            cameraX = player.getX() - (this.ClientSize.Width / 2) + (player.getWidth() / 2); // camera coordinates set
            cameraY = player.getY() - (this.ClientSize.Height / 2) + (player.getHeight() / 2);

            if (cameraX < minCameraX)
            {
                cameraX = minCameraX;
            }
            else if (cameraX > maxCameraX) //if statements restrict camera from moving past game
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

        }

        private void GameLoop(object sender, EventArgs e)
        {
            mapScroll();
            imagesValidation(); //validates images

            if (arrowImages != null)
            {
                arrow.setImage(arrowImages[arrowIndex]); //arrow image set
                setArrowImage();

            }

            

            try
            {
                if (player.getHealth() >= 0)
                {
                    prgHealth.Value = player.getHealth(); //prg bar updated
                }
                else { prgHealth.Value = 0; }
            }
            
            catch (ArgumentOutOfRangeException)
            {
                player.setHealth(100);
            }

            
            if (player.getX() >= 1500)
            {
                //prevents mini map overlapping the player
                miniMap.setImage(null);

            }
            



       
            if (miniMap.getImage() == null && player.getX() < 1550)
            {
                miniMap.setImage("miniMap.png");
                //mini map made visible again
            }
            miniMapX = this.ClientSize.Width - miniMapWidth - miniMapXMargin;
            miniMapY = miniMapYMargin;



            zombieDirection();
            boundControl();
            // labels set to display kill and ammo count
            lblKills.Text = kills.ToString();
            lblAmmo.Text = ammo.ToString();

            // if booleans are true, player movement direction is set
            if (moveLeft)
            {
                direction = "left";
            }
            if(moveRight)
            {
                direction ="right";
            }
            if (moveUp)
            {
                direction = "up";
            }
            if (moveDown)
            {
                direction = "down";
            }
            if (superSpeed && restrictMovement == false || Invincibilty && restrictMovement == false)
            {
                //if a power up is picked then the animation method is called
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
                player.navigation(direction); //player is moved in direction after animation
            }
            else if (restrictMovement == false && superSpeed == false)
            {

                player.face(direction);
                
            }
            SpawnZombie();
            foreach (Zombie zombie in zombies)
            {
                //calculates quickest path from zombie to player
                Node targetNode = grid[player.getX() / 80, player.getY() / 80];
                if (targetNode != null)
                {
                    UpdateZombieMovement(zombie, grid, targetNode);
                }
                
            }
            zombieAttack();
            checkHealth();
            killZombie();
            if (droppedAmmo) { pickAmmo(); } // if statements control the spawn of items
            if (droppedHealth) { pickHealth(); }
            if (droppedPowerUp) { pickPowerUp(); }
            // bullets deleted after moving off screen
            foreach (Bullet bullet in bullets.ToList())
            {
                if (bullet.getImage() == null)
                {

                    bullets.Remove(bullet); //prevents null image error
                }
            }
            if (powerDrop < 1 && droppedPowerUp == false)
            {
                makePowerUp(); //controls spawn of powerup
            }
            else
            {
                powerDrop--; //reduces cool down timer
            }
            if (superSpeed || Invincibilty)
            {
                powerTime--; //reduces duration timer
                if (powerTime == 0)
                {
                    superSpeed = false;
                    Invincibilty = false;// booleans set back to false
                }

            }
            if (healthTimer < 1 && droppedHealth == false)
            {
                dropHealth(); //controls spawn of health
            }
            else
            {
                healthTimer--;
            }
            if (ammoDrop < 1 && droppedAmmo == false)
            {
                dropAmmo(); //controls spawn of ammo
            }
            else
            {
                ammoDrop--; //reduces cool down timer
            }
            bulletHitsWall();
            this.Invalidate();
        }
        private void SpawnZombie()
        {
            // random co-ordinates assigned to zombies within boundaries
            int X = range.Next(60, 1500); 
            int Y = range.Next(110, 1000);
            Node currentZombieNode = grid[X / 80, Y / 80];
            if (zombies.Count < 5)
            {
                // if zombie count falls below 3, new zombies are spawned and added to list 
                if (currentZombieNode.Walkable)
                {
                    Zombie zombie = new Zombie(X, Y, 5);
                    zombies.Add(zombie);
                }
                
            }
        }
        private void imagesValidation()
        {
            try
            {//try to access mini map image
                miniMap.setImage("miniMap.png");
            }
            catch (FileNotFoundException)
            {//if the file is not found
                imageNotFound = true;

            }
            try
            {//tries to access arrow images
                arrowImages = Directory.GetFiles("arrowImages", "*png").ToArray(); //arrow images obtained
                arrow.setImage(arrowImages[0]); //arrow image set
            }
            catch (DirectoryNotFoundException)
            {//if the images are not found
                imageNotFound = true;
            }
            try
            { //tries to access powerup images
                powerUpLocations = Directory.GetFiles("powerups", "*png").ToList();
            }
            catch (DirectoryNotFoundException)
            {//if the images are not found
                imageNotFound = true;
            }
            //method to check for insufficient image errors
            foreach (Zombie zombie in zombies) 
            {
                if (player.imageNotFound() || zombie.imageNotFound() || imageNotFound)
                {
                    this.BackgroundImage = Image.FromFile("imageforError.png");//background image changed to inform user
                    GameLoopTimer.Stop(); //timer stopped as the program has issues so should not run
                }
            }
            
        }
        
        private void runAstar(Zombie zombie, Node[,] grid, Node targetNode)
        {
            Node currentZombieNode = grid[zombie.getX() / 80, zombie.getY() / 80];
            List<Node> path = AStar(currentZombieNode, targetNode, grid);

            // If no path found, stop movement
            if (path == null || path.Count == 0)
            {

                return;
            }
            Node nextMove;
            // Get the next move node in the path
            if (path.Count > 1)
            {
                nextMove = path[1];
            }
            else
            {
                nextMove = path[0];
            } // Index 1 to get the immediate next step

            // Move zombie towards the next step in the path
            if (currentZombieNode.X < nextMove.X)
                zombie.moveZombie("right");
            else if (currentZombieNode.X > nextMove.X)
                zombie.moveZombie("left");

            if (currentZombieNode.Y < nextMove.Y)
                zombie.moveZombie("down");
            else if (currentZombieNode.Y > nextMove.Y)
                zombie.moveZombie("up");
        }
        // A* pathfinding algorithm implementation
        private void UpdateZombieMovement(Zombie zombie, Node[,] grid, Node targetNode)
        {
            Node currentZombieNode = grid[zombie.getX() / 80, zombie.getY() / 80];
            if (targetNode.Walkable == false)
            {
                targetNode.Walkable = true;
                runAstar(zombie, grid, targetNode);
                targetNode.Walkable = false;

            }
            else
            {
                runAstar(zombie, grid, targetNode);
            }
            
        }
        private List<Node> AStar(Node startNode, Node targetNode, Node[,] grid)
        {
            List<Node> openSet = new List<Node>(); // Nodes to explore
            HashSet<Node> closedSet = new HashSet<Node>(); // Nodes already explored

            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                Node currentNode = openSet.OrderBy(node => node.FCost).ThenBy(node => node.HCost).First();

                // Check if reached target
                if (currentNode == targetNode)
                {
                    return RetracePath(startNode, currentNode); // Returns path as list of nodes
                }

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                foreach (Node neighbor in GetNeighbors(currentNode, grid))
                {
                    // Skip non-walkable or already-processed nodes
                    if (!neighbor.Walkable || closedSet.Contains(neighbor)) continue;

                    int newCostToNeighbor = currentNode.GCost + GetDistance(currentNode, neighbor);
                    if (newCostToNeighbor < neighbor.GCost || !openSet.Contains(neighbor))
                    {
                        neighbor.GCost = newCostToNeighbor;
                        neighbor.HCost = GetDistance(neighbor, targetNode);
                        neighbor.Parent = currentNode;

                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                        }
                    }
                }
            }

            return null; // No path found
        }

        // Helper function to trace back from the end node to the start node to get the final path
        private List<Node> RetracePath(Node startNode, Node endNode)
        {
            List<Node> path = new List<Node>();
            Node currentNode = endNode;

            // Retrace the path from end to start by following the parent nodes
            while (currentNode != startNode)
            {
                path.Add(currentNode);
                currentNode = currentNode.Parent;
            }

            // Reverse the path to get it from start to end
            path.Reverse();
            return path;
        }
        private List<Node> GetNeighbors(Node node, Node[,] grid)
        {
            List<Node> neighbors = new List<Node>();
            int x = node.X;
            int y = node.Y;

            // Add neighboring nodes (assuming 4-directional movement)
            if (x - 1 >= 0) neighbors.Add(grid[x - 1, y]); // Left
            if (x + 1 < grid.GetLength(0)) neighbors.Add(grid[x + 1, y]); // Right
            if (y - 1 >= 0) neighbors.Add(grid[x, y - 1]); // Up
            if (y + 1 < grid.GetLength(1)) neighbors.Add(grid[x, y + 1]); // Down

            return neighbors;
        }

        private int GetDistance(Node a, Node b)
        {
            int dstX = Math.Abs(a.X - b.X);
            int dstY = Math.Abs(a.Y - b.Y);
            return dstX + dstY; // Manhattan distance
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
                //collision detected between zombie and player
                if (CollisionOccurred(player.getX(), player.getY(), player.getWidth(), player.getHeight(), 
                    zombie.getX(), zombie.getY(), zombie.getWidth(), zombie.getHeight()) && Invincibilty == false)
                {
                    player.zombieDamage(); //player health reduced
                    if (player.getHealth() % 10 == 0 && player.getHealth() != 100)
                    {
                        PlaySound("attackedSound.mp3");
                    }
                    
                }
            }  
        }  
        private void killZombie()
        {
            foreach (Zombie zombie in zombies.ToList())
            {
                foreach (Bullet bullet in bullets.ToList())
                {//collision detected between zombie and bullet
                    if (CollisionOccurred(zombie.getX(), zombie.getY(), zombie.getWidth(), 
                        zombie.getHeight(), bullet.getX(), bullet.getY(), 
                        bullet.getWidth(), bullet.getHeight()))
                    {
                        kills++; //kill count increased
                        bullets.Remove(bullet); //sprites removed
                        zombies.Remove(zombie);
                        SpawnZombie();
                    }
                }
            }
        }


        private void checkHealth()
        {
            // program constantly checks player health
            if (player.getHealth() <= 0 && !closedGame)
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
            Node Powerup = grid[X / 80, Y / 80];
            if (Powerup.Walkable)
            {
                // instantiates health kit based on sprite class
                healthKit = new Sprite(X, Y, 50, 50, 0);
                // sets image
                healthKit.setImage("healthKit.png");

                // makes bool true
                droppedHealth = true;
            }
            else
            {
                dropHealth();
            }

        }
        private void pickHealth()
        {
            // detects collision between player and healthkit
            if (CollisionOccurred(player.getX(), player.getY(), 
                player.getWidth(), player.getHeight(), healthKit.getX(), 
                healthKit.getY(), healthKit.getWidth(), healthKit.getHeight()))
            {
                // increases player health
                int health = player.getHealth() + 25;
                
                    player.setHealth(health);


                PlaySound("healSound.mp4");
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
                ammo += 10;
                ammoCrate.setImage(null);
                droppedAmmo = false;
                //resets ammo timer
                ammoDrop = 300;
                PlaySound("reloadSound.mp3");
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
            PlaySound("gunShot.wav");



        }
        private WaveOutEvent PlaySound(string filePath)
        {
            var audioFile = new AudioFileReader(filePath);
            var outputDevice = new WaveOutEvent();

            outputDevice.Init(audioFile);
            outputDevice.Play();

            // Clean up after playback finishes
            outputDevice.PlaybackStopped += (sender, args) =>
            {
                outputDevice.Dispose();
                audioFile.Dispose();
            };
            return outputDevice;
        }
        private void PlayBackgroundMusic()
        {
            stopBackgroundMusic(); // Clean up any existing music first

            backgroundMusicReader = new AudioFileReader("bgMusic.mp3");
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

        private void stopBackgroundMusic()
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

        
        protected override bool IsInputKey(Keys keyData)
        {
            // Ensures arrow keys and space are treated as input, not UI navigation
            switch (keyData)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                case Keys.Space:
                    return true;
                default:
                    return base.IsInputKey(keyData);
            }
        }

        //private void btnClose_Click(object sender, EventArgs e)
        //{
            
        //}

        //private void button1_Click_1(object sender, EventArgs e)
        //{
            
        //}

        private void dropAmmo()
        {
            // random co-ordinates assigned to ammo crate
            int X = range.Next(60, 1500);
            int Y = range.Next(110, 1000);
             Node Ammocrate =  grid[X / 80, Y / 80];
            if (Ammocrate.Walkable)
            {
                // ammo crate instantiated based on sprite class
                ammoCrate = new Sprite(X, Y, 50, 100, 0);
                ammoCrate.setImage("ammoCrate.png");
                droppedAmmo = true;
            }
            else 
            {
                dropAmmo();
            }

           
        }
        private void makePowerUp()
        {
            //random co-ordinates assigned to powerup
            int i = range.Next(0, powerUpLocations.Count());
            int X = range.Next(60, 1500);
            int Y = range.Next(110, 1000);
            Node Powerup =  grid[X / 80, Y / 80];
            if (Powerup.Walkable)
            {
                powerUp = new Sprite(X, Y, 50, 100, 0);
                powerUp.setImage(powerUpLocations[i]); //powerup instantiated based on sprite class
                powerName = powerUpNames[i];
                droppedPowerUp = true;
            }
            else
            {
                makePowerUp();
            }
            
        }

        private void pickPowerUp()
        {
            {
                //collision detected between powerup and player
                if (CollisionOccurred(player.getX(), player.getY(), player.getWidth(), player.getHeight(), 
                    powerUp.getX(), powerUp.getY(), powerUp.getWidth(), powerUp.getHeight()))
                {
                    switch (powerName)
                    {//checks which powerup is picked and sets according image to true
                        case "lightning":
                            superSpeed = true;
                            break;

                        case "shield":
                            Invincibilty = true;
                            break;

                    }
                    powerTime = 200;
                    powerDrop = 600;
                    powerUp.setImage(null);
                    powerUps.Remove(powerUp);
                    droppedPowerUp = false;
                    player.setPower(powerName);
                    PlaySound("powerSound.mp3");
                }
            }
        }
        private void setArrowImage()
        {
            

            switch (direction)
            {
                //sets the arrow index
                case "left":
                    arrowIndex = 1;
                    break;
                case "right":
                    arrowIndex = 2;
                    break;
                case "up":
                    arrowIndex = 3;
                    break;
                case "down":
                    arrowIndex = 0;
                    break;
            }
            arrow.setImage(arrowImages[arrowIndex]);
        }
        private void boundControl()
        {
            //method restricts sprite movement
            int minX = 45; //limiting coordinates set
            int maxX = 1675; 
            int minY = 100; 
            int maxY = 1230; 

            if (player.getX() <= minX && direction == "left" || player.getX() >= maxX && direction == "right"
               || (player.getY() <= minY && direction == "up" || (player.getY() >= maxY && direction == "down")))
            { 
                //prevents movement against boundaries
                restrictMovement = true;
                if (player.getY() > maxY)
                {
                    //prevents glitching through boundaries
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
                    //collision detected between wall and player
                    if (barrier.getX() < player.getX() && direction == "left" ||
                        barrier.getX() > player.getX() && direction == "right" ||
                        barrier.getY() < player.getY() && direction == "up" ||
                        barrier.getY() > player.getY() && direction == "down")
                    {
                        restrictMovement = true;
                        //prevents movement
                    }
                }
            }
        }

        private void lblMenu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Return to Main Menu?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                GameLoopTimer.Stop();

                menu.hasGameStarted(false);
                stopBackgroundMusic();

                menu.Show();   // Show the main menu first
                menu.PlayBackgroundMusic();
                menu.setUser(menu.getUser());
                this.Close();  // 
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            GameLoopTimer.Stop();
            DialogResult result = MessageBox.Show(
        "Are you sure you want to quit the game?",
        "Confirm Exit",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );
            if (result == DialogResult.No && gamePaused == false)
            {

                GameLoopTimer.Start();
                this.ActiveControl = null;
                this.Focus();
            }
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // or this.Close();
            }
        }

        private void lblPause_Click(object sender, EventArgs e)
        {
            if (!gameEnded)
            {
                if (!gamePaused)
                {
                    gamePaused = true;
                    lblPause.Text = "Play";
                    stopBackgroundMusic();
                    pnlPause.Visible = true;
                    GameLoopTimer.Stop();
                }
                else
                {
                    gamePaused = false;
                    lblPause.Text = "Pause";
                    pnlPause.Visible = false;
                    PlayBackgroundMusic();
                    GameLoopTimer.Start();

                }
                this.ActiveControl = null;
                this.Focus();
            }
        }

        private void bulletHitsWall()
        {
            foreach (Bullet shot in bullets.ToList())
            {
                foreach (Wall barrier in walls.ToList())
                {//collision detected between wall and bullet
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
                    //collision detected between zombie and wall
                    if (CollisionOccurred(zombie.getX(), zombie.getY(), zombie.getWidth(), zombie.getHeight(),
                        barrier.getX(), barrier.getY(), barrier.getWidth(), barrier.getHeight()))
                    {
                        if (zombie.getX() > barrier.getX() && zombie.getHorizontalDirection() == "left" ||
                           zombie.getX() < barrier.getX() && zombie.getHorizontalDirection() == "right" ||
                           zombie.getY() > (barrier.getY())  && zombie.getVerticalDirection() == "up" ||
                           zombie.getY() < (barrier.getY()) && zombie.getVerticalDirection() == "down")
                        { zombie.setMovement(false); } //movement prevented
                        else { zombie.setMovement(true); }
                    }
                }
            }
        }

        private void zombieDirection()
        {
            foreach (Zombie enemy in zombies.ToList())
            {
                //method assigns horizontal and vertical directions to zombie
                if (enemy.getX() < player.getX())
                {
                    enemy.setHorizontalDirection("right");
                }
                if (enemy.getX() > player.getX())
                {
                    enemy.setHorizontalDirection("left");
                }
                if (enemy.getY() < player.getY())
                {
                    enemy.setVerticalDirection("down");
                }
                if (enemy.getY() > player.getY())
                {
                    enemy.setVerticalDirection("up");
                }
            }
        }

        private void lblRestart_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to restart the game?",
                "Confirm Restart",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                GameScreenDesign game = new GameScreenDesign(menu);
                game.Show();
                this.Close(); 
            }
        }


        private void lblMenu_MouseEnter(object sender, EventArgs e)
        {
            lblMenu.ForeColor = Color.Brown;
            playButtonSound();
        }
        private void lblMenu_MouseLeave(object sender, EventArgs e)
        {
            lblMenu.ForeColor= Color.White;
        }
        private void lblExit_MouseEnter(Object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.Brown;
            playButtonSound();
        }
        private void lblExit_MouseLeave(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.White;
        }

        private void playButtonSound()
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

       
        





        private void RestartGame()
        {
            // Reset all game state
           // ResetGameVariables(); // score = 0, ammo = 10, etc.
            InitGameUI();         // restore label positions, event handlers, etc.
            GameLoopTimer.Start();
        }



        private void endGame()
        {
            if (closedGame) return; // ⛔️ safety net if accidentally called elsewhere

            closedGame = true;      // ✅ immediately prevent repeat calls

            player.setImage("grave.png");
            gameEnded = true;

            stopBackgroundMusic();
            pnlPause.Visible = true;

            if (kills > menu.getHighScore() && !scoreSet)
            {
                string username = menu.getUser();
                if (!string.IsNullOrEmpty(username))
                {
                    Database.SetHighScore(username, kills);
                    scoreSet = true;
                }
            }

            GameLoopTimer.Stop(); // You can keep this at the end
        }


    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurviveTillDawn
{
    internal class Bullet : Sprite
    {
        // bullet class based on sprite superclass
        private string direction;
        private Timer bulletTimer;
        private int speed = 15;
        private List<string> bulletImages = new List<string>();

        public Bullet(string facing, int left, int top) : base(left, top, 20, 20, 30)
        {
            //image set
            // direction based on parameter
            // separate timer for bullet to ensure smooth bullet movement
            direction = facing;
            bulletTimer = new System.Windows.Forms.Timer();
            bulletTimer.Interval = speed;
            bulletTimer.Tick += new EventHandler(BulletTimerEvent);
            bulletTimer.Start();
            bulletImages = Directory.GetFiles("bullet", "*.png").ToList();
            base.setImage(bulletImages[3]);
        }
        //Canvas.DrawImage(Image.FromFile("wall.png"), -35 - cameraX, 10 - cameraY, 100, 1350);
        //    Canvas.DrawImage(Image.FromFile("wall.png"), 1750 - cameraX, 10 - cameraY, 100, 1350);
        //    Canvas.DrawImage(Image.FromFile("wall.png"), -35 - cameraX, 1300 - cameraY, 1875, 80);
        //    Canvas.DrawImage(Image.FromFile("wall.png"), -35 - cameraX, 20 - cameraY, 1875, 80);
        private void BulletTimerEvent(object sender, EventArgs e)
        {
            base.navigation(direction);
            if (base.getX() < 10 || base.getX() + base.getWidth() > 1750 || base.getY() < 50 || base.getY() + base.getHeight() > 1350)
            {
                bulletTimer.Stop();
                bulletTimer.Dispose();
                bulletTimer = null;
                base.setImage(null);
            }
        }

        public void face(string direction)
        {
            // direction passed as parameter
            // method checks parameter and sets player image
            switch (direction)
            {
                case "left":
                    base.setImage(bulletImages[1]);
                    break;
                case "right":
                    base.setImage(bulletImages[2]);
                    break;
                case "up":
                    base.setImage(bulletImages[3]);
                    break;
                case "down":
                    base.setImage(bulletImages[0]);
                    break;
            }
        }


    }
}

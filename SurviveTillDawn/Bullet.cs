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
        private int speed = 40;
        private List<string> bulletImages = new List<string>();

        public Bullet(string facing, int left, int top) : base(left, top, 20, 20, 30)
        {
            //image set
            // direction based on parameter
            // separate timer for bullet to ensure smooth bullet movement
            direction = facing;
            bulletTimer = new System.Windows.Forms.Timer();
            bulletTimer.Interval = 20;
            bulletTimer.Tick += new EventHandler(BulletTimerEvent);
            bulletTimer.Start();
            bulletImages = Directory.GetFiles("bullet", "*.png").ToList();
            base.setImage(bulletImages[3]);
            
        }
        
        private void BulletTimerEvent(object sender, EventArgs e)
        {
            base.setSpeed(speed);
            base.navigation(direction);
            if (base.getX() < 10 || base.getX() + base.getWidth() > 1750 || base.getY() < 50 || base.getY() + base.getHeight() > 1350)
            {
                bulletTimer.Stop(); //stops timer after bullet is removed
                bulletTimer.Dispose(); //timer is disposed
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

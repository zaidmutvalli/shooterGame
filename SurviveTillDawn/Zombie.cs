using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurviveTillDawn
{
    internal class Zombie : Sprite
    {
        private List<string> zombieImages = new List<string>();
        private bool movementAllowed = true;
        private string zombieHorizontalDirection;
        private string zombieVerticalDirection;
        public Zombie(int x, int y) : base(x, y, 75, 75, 4)
        {
            // constructor obtains zombie images as a list
            // initial image set 
            zombieImages = Directory.GetFiles("zombie", "*.png").ToList();
            base.setImage(zombieImages[3]);
        }

        public void moveZombie(string direction)
        {
            
            switch (direction)
            { 
                case "left":
                    base.setImage(zombieImages[1]);
                    break;
                case "right":
                    base.setImage(zombieImages[2]);
                    break;
                case "up":
                    base.setImage(zombieImages[3]);
                    break;
                case "down":
                    base.setImage(zombieImages[0]);
                    break;
            }
            base.navigation(direction);
        }

        public void setMovement(bool passed)
        {
            this.movementAllowed = passed;
        }
        public bool isMovementAllowed()
        {
            return this.movementAllowed;
        }

        public void setHorizontalDirection(string horizontal)
        {
            
            this.zombieHorizontalDirection = horizontal;
        }

        public void setVerticalDirection(string vertical)
        {
            this.zombieVerticalDirection = vertical;
        }

        public string getHorizontalDirection()
        {
            return this.zombieHorizontalDirection;
        }

        public string getVerticalDirection()
        {
            return this.zombieVerticalDirection;
        }
    }
}

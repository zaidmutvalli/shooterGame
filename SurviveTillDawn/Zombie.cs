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
        private List<string> zombieImages = new List<string>(); //images list made
        private bool movementAllowed = true; //movement permission set
        private string zombieHorizontalDirection;
        private string zombieVerticalDirection;
        private bool zombieImageNotFound = false; //boolean for image validation
    

        public Zombie(int x, int y, int speed) : base(x, y, 75, 75, speed)
        {
            // constructor obtains zombie images as a list
            // initial image set 
            try //try catch loop checks if images have been correctly accessed
            {
                zombieImages = Directory.GetFiles("zombie", "*.png").ToList();
                base.setImage(zombieImages[3]);
            }
            catch (DirectoryNotFoundException)
            {//catch in case the directory for images is not found
                zombieImageNotFound = true;
            }
            catch (IndexOutOfRangeException)
            {//catch in case the index is out of range
                zombieImageNotFound = true;
                
            }

        }

        public void moveZombie(string direction)
        {
            if (!zombieImageNotFound)
            {
                //zombie image set according to direction
                switch (direction)
                {
                    case "left":
                        this.setImage(zombieImages[1]);
                        break;
                    case "right":
                        this.setImage(zombieImages[2]);
                        break;
                    case "up":
                        this.setImage(zombieImages[3]);
                        break;
                    case "down":
                        this.setImage(zombieImages[0]);
                        break;
                }
                base.navigation(direction); //zombie moved in direction
            }
        }
        public bool imageNotFound()
        {
            return this.zombieImageNotFound; //getter for image not found bool
        }
        public void setMovement(bool passed)
        {
            this.movementAllowed = passed; //controls movement
        }
        public bool isMovementAllowed()
        {
            return this.movementAllowed; //returns movement permission
        }

        public void setHorizontalDirection(string horizontal)
        {
            
            this.zombieHorizontalDirection = horizontal; //sets horizontal direction
        }

        public void setVerticalDirection(string vertical)
        {
            this.zombieVerticalDirection = vertical; //sets vertical direction
        }

        public string getHorizontalDirection()
        {
            return this.zombieHorizontalDirection; //gets horizontal direction
        }

        public string getVerticalDirection()
        {
            return this.zombieVerticalDirection; //gets vertical direction
        }
    }
}

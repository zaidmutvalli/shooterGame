using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SurviveTillDawn
{
     class Character : Sprite
    {
        // character inherits all attributes and methods from sprite
        // also has additional attributes
        private int health; int index; int frameRate = 0;
         private List<string> shooterImages = new List<string>();
        private List<string> InvincibleImages = new List<string>();
        private string currentPower;
        private bool shooterImageNotFound = false; //boolean for image validation

        
        public Character(): base(580, 350, 75, 75, 10)
        {
            //constructor based on player class
            // assigned original health, co-ordinates and image
            health = 100;
            // obtained list of images from files
            try
            {//this try-catch aims to check if images have been correctly obtained
                shooterImages = Directory.GetFiles("player", "*.png").ToList();
                base.setImage(shooterImages[6]);
            }
            catch(DirectoryNotFoundException) 
            { //catch in case the directory has not been founded containing the images
                shooterImageNotFound=true;
            }
            catch(IndexOutOfRangeException) 
            { //catch in case the index has been incorrectly set
                shooterImageNotFound=true;
            }
            try
            {//tries to access invincible images
                InvincibleImages = Directory.GetFiles("InvinciblePlayer", "*.png").ToList();
            }
            catch(DirectoryNotFoundException)
            {//if directory is not found
                shooterImageNotFound=true;
            }
        }

        public void face(string direction)
        {
            // direction passed as parameter
            // method checks parameter and sets player image
            switch (direction)
            {
                case "left":
                    base.setImage(shooterImages[2]);
                        break;
                case "right":
                    base.setImage(shooterImages[4]);
                    break;
                case "up":
                    base.setImage(shooterImages[6]);
                    break;
                case "down":
                    base.setImage(shooterImages[0]);
                    break;
            }
            navigation(direction);
        }
        public bool imageNotFound()
        {
            //getter for the image not found bool
            return this.shooterImageNotFound;
        }
        public void zombieDamage() { this.health -= 1; }
        public int getHealth() { return this.health; }
        public void setHealth(int health) { this.health = health;}
        public void setPower(string power) { this.currentPower = power;}

        public void playerSpeedAnimation(int first, int second)
        {
            frameRate++;
            if (frameRate == 8)
            {
                index++;
                frameRate = 0;
            }
            if (index > second || index < first)
            {
                index = first;
            }
            switch (currentPower)
            {
                case "lightning":
                    base.setImage(shooterImages[index]);
                    break;

                case "shield":
                    base.setImage(InvincibleImages[index]);
                    break;
            }
                
        }
    }
}

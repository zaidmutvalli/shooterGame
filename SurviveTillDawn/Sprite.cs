using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurviveTillDawn
{
    internal class Sprite
    {
        // super class Sprite's attributes
        private Image image;
        private int x;
        private int y;
        private int width;
        private int height;
        private int speed;

        public Sprite(int x, int y, int width, int height, int speed)
        {
            // constructor based on sprite class which assigns parameters as attributes to object
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.speed = speed;
        }

        public void setImage(string visual)
        {
            if (visual != null)
            {
                this.image = Image.FromFile(visual);
            }
            else
            {
                this.image = null;
            }
        }

        public Image getImage() { return this.image; }
        public int getX() { return this.x;}
        public int getY() { return this.y;}
        public int getWidth() { return this.width;} 
        public int getHeight() { return this.height;}   
        public void setX(int x) { this.x = x;} 
        public void setY(int y) {  this.y = y;}
        public void setSpeed(int speed) { this.speed = speed;}
        public int getSpeed() { return this.speed; }


        public void navigation(string facing)
        {
            switch(facing)
            {
                // facing direction passed as parameter
                // method increases/decreases co-ordinates accordingly
                case "left":
                    // if statements prevent character from moving off screen.
                    x -= speed;
                    break;
                case "right": 
                    x += speed;
                    break;
                case "up":
                    y -= speed;
                    break;
                case "down":
                    y += speed;
                    break;
            }
        }
    }
}

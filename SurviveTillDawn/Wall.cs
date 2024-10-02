using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurviveTillDawn
{
    internal class Wall : Sprite
    {
        public Wall(int x, int y, int width, int height)
           : base(x, y, width, height, 0)  // Wall has no speed, so set it to 0
        {
            // Optionally set a default image for the wall here
            setImage("black.png");  // Assuming you have a default wall image
        }
    }
}

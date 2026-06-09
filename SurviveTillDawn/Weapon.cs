using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Drawing;

namespace SurviveTillDawn
{
    internal class Weapon
    {
        private string name;
        private int damage;
        private string imageFile;
        private string shootingType;
        private int maxMag;
        private Image image;
        public Weapon(string weapon, int damage, string fileName, string type, int max)
        {
            this.name = weapon;
            this.imageFile = fileName;
            this.shootingType = type;
            this.maxMag = max;
        }

        private void setDamage()
        {
            switch (shootingType)
            {
                case "melee":
                    this.damage = 20;
                    break;
                case "AR":
                    this.damage = 50;
                    break;
                case "Shotgun":
                    this.damage = 75;
                    break;
                case "Pistol":
                    this.damage = 50;
                    break;
            }

        }

        private void setImage(string fileName)
        {
            if (fileName != null)
            {
                this.image = Image.FromFile(fileName);
            }
            else
            {
                this.image = null;
            }
        }



    }

    
}

    

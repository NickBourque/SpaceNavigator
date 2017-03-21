using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceNavigator
{
    class Bullet
    {
        private readonly int BulletHeight = 10;
        private readonly int BulletWidth = 10;

        private Rectangle BulletDisplayArea;
        private Rectangle GameplayArea;

        public int XVelocity { get; set; }
        public int YVelocity { get; set; }

        private Image image;

        public Rectangle DisplayArea
        {
            get { return this.BulletDisplayArea; }
        }


        public Bullet(Rectangle GameplayArea, Spaceship ship)
        {
            BulletDisplayArea.Height = BulletHeight;
            BulletDisplayArea.Width = BulletWidth;

            BulletDisplayArea.Y = ship.DisplayArea.Y; //y of spaceship;
            BulletDisplayArea.X = ship.DisplayArea.X + (ship.DisplayArea.Width / 2); //spaceship width / 2;

            XVelocity = 0;
            YVelocity = 30;

            image = Image.FromFile(@"images/Bullet.png");

            this.GameplayArea = GameplayArea;
        }


        public void Move()
        {
            BulletDisplayArea.X += XVelocity;
            BulletDisplayArea.Y -= YVelocity;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, BulletDisplayArea);
        }
    }
}

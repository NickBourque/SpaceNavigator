using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceNavigator
{
    class UFO
    {
        private readonly int UFOHeight = 250;
        private readonly int UFOWidth = 500;

        private Rectangle UFODisplayArea;
        private Rectangle GameplayArea;

        public int XVelocity { get; set; }
        public int YVelocity { get; set; }

        private Random random = new Random();
        private Image image;


        public Rectangle DisplayArea
        {
            get { return this.UFODisplayArea; }
        }


        public UFO(Rectangle gameplayArea)
        {
            this.GameplayArea = gameplayArea;

            UFODisplayArea.Height = UFOHeight;
            UFODisplayArea.Width = UFOWidth;

            //set starting location
            UFODisplayArea.X = random.Next(GameplayArea.X, GameplayArea.Right);
            UFODisplayArea.Y = random.Next(GameplayArea.Y - 60, GameplayArea.Y - 40);

            XVelocity = random.Next(-10, 10);
            YVelocity = random.Next(5, 25);

            image = Image.FromFile(string.Format(@"images/UFO{0}.png", random.Next(1, 4)));
        }


        public void Move()
        {
            UFODisplayArea.X += XVelocity;
            UFODisplayArea.Y += YVelocity;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, UFODisplayArea);
        }

    }
}

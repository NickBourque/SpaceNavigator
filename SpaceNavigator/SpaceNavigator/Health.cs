using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceNavigator
{
    class Health
    {
        private readonly int HealthHeight = 25;
        private readonly int HealthWidth = 25;

        private Rectangle HealthDisplayArea;
        private Rectangle GameplayArea;

        public int XVelocity { get; set; }
        public int YVelocity { get; set; }

        private Random random = new Random();
        private Image image;


        public Rectangle DisplayArea
        {
            get { return this.HealthDisplayArea; }
        }


        public Health(Rectangle gameplayArea)
        {
            this.GameplayArea = gameplayArea;

            HealthDisplayArea.Height = HealthHeight;
            HealthDisplayArea.Width = HealthWidth;

            //set starting location and velocity
            HealthDisplayArea.X = random.Next(GameplayArea.X, GameplayArea.Right);
            HealthDisplayArea.Y = random.Next(GameplayArea.Y - 60, GameplayArea.Y - 40);

            XVelocity = 0;
            YVelocity = random.Next(10, 20);
            
            image = Image.FromFile(@"images/Health.png");
        }


        public void Move()
        {
            HealthDisplayArea.X += XVelocity;
            HealthDisplayArea.Y += YVelocity;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, HealthDisplayArea);
        }

    }
}

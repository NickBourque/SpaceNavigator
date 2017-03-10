using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncyBall
{
    class Ball
    {

        private int ballSize = 20;

        private Rectangle ballDisplayArea;
        private Rectangle gameplayArea;

        public int XVelocity { get; set; }
        public int YVelocity { get; set; }

        private Random random = new Random();
        private Color color;
        private Image image;

        public Rectangle DisplayArea
        {
            get { return this.ballDisplayArea; }
        }

        public int Size
        {
            get { return this.ballSize; }
        }

        public Ball(Rectangle gameplayArea)
        {
            this.gameplayArea = gameplayArea;

            ballDisplayArea.Height = ballSize;
            ballDisplayArea.Width = ballSize;

            //set starting coords
            ballDisplayArea.X = (gameplayArea.Width / 2) - (ballSize / 2);
            ballDisplayArea.Y = gameplayArea.Height / 2 - (ballSize / 2);

            //randomly set x and y velocity
            Random random = new Random();
            while(XVelocity > -3 && XVelocity <3)
                XVelocity = random.Next(-10, 10);

            while (YVelocity > -3 && YVelocity < 3)
                YVelocity = random.Next(-10, 10);

            color = Color.FromArgb(255, random.Next(255), random.Next(255), random.Next(255));
            image = Image.FromFile(string.Format(@"images\ball{0}.png", random.Next(1,4)));
        }


        public void Move()
        {
            ballDisplayArea.X += XVelocity;
            ballDisplayArea.Y += YVelocity;

        }

        public void Draw(Graphics graphics)
        {

            using (SolidBrush brush = new SolidBrush(color))
            {
                //graphics.FillEllipse(brush, ballDisplayArea);
                graphics.DrawImage(image, ballDisplayArea);
            }
        }


    }
}

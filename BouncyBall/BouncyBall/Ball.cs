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

        private int ballSize = 10;

        private Rectangle ballDisplayArea;
        private Rectangle gameplayArea;

        public int XVelocity { get; set; }
        public int YVelocity { get; set; }

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
            XVelocity = random.Next(-10, 10);
            YVelocity = random.Next(-10, 10);

        }


        public void Move()
        {
            ballDisplayArea.X += XVelocity;
            ballDisplayArea.Y += YVelocity;

            if(ballDisplayArea.X <= 0)
            {
                XVelocity = XVelocity * -1;
            }
            if(ballDisplayArea.X >= gameplayArea.Width - ballSize)
            {
                XVelocity = XVelocity * -1;
            }
            if(ballDisplayArea.Y <= 0)
            {
                YVelocity = YVelocity * -1;
            }
            if(ballDisplayArea.Y >= gameplayArea.Height - ballSize)
            {
                YVelocity = YVelocity * -1;
            }

        }

        public void Draw(Graphics graphics)
        {
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                graphics.FillEllipse(brush, ballDisplayArea);
            }
        }


    }
}

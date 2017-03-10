using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncyBall
{
    public class Paddle
    {
        private readonly int paddleHeight = 10;
        private readonly int paddleWidth = 70;

        private Rectangle paddleDisplayArea;
        private Rectangle gameplayArea;

        public enum Direction { Left, Right }

        public Rectangle DisplayArea
        {
            get { return this.paddleDisplayArea; }
        }


        public Paddle(Rectangle gameplayArea)//constructor taking in form size rectangle
        {
            paddleDisplayArea.Width = paddleWidth;
            paddleDisplayArea.Height = paddleHeight;

            //set initial position
            paddleDisplayArea.Y = gameplayArea.Bottom - 50;
            paddleDisplayArea.X = (gameplayArea.Width / 2) - (paddleWidth / 2);

            this.gameplayArea = gameplayArea;
        }


        //move
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    {
                        //ternary statement
                        paddleDisplayArea.X = (paddleDisplayArea.X >= 20) ? paddleDisplayArea.X - 20 : 0;
                        
                        break;
                    }
                case Direction.Right:
                    {
                        if(paddleDisplayArea.X >= gameplayArea.Right - paddleWidth)
                        {
                            paddleDisplayArea.X = gameplayArea.Right - paddleWidth;
                        }
                        else
                        {
                            paddleDisplayArea.X += 20;
                        }
                        break;
                    }
            }
        }


        //draw
        public void Draw(Graphics graphics)
        {
            //draw the paddle
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                graphics.FillRectangle(brush, paddleDisplayArea);
            }
        }

    }
}

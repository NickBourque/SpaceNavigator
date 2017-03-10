using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncyBall
{
    public partial class GameForm : Form
    {
        Paddle paddle;
        HashSet<Ball> balls = new HashSet<Ball>();
        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            //maximize the window
            this.WindowState = FormWindowState.Maximized;

            //create paddle, giving it the display area rectangle of the form
            paddle = new Paddle(this.DisplayRectangle);
            balls.Add(new Ball(this.DisplayRectangle));
            
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            //draw the paddle
            paddle.Draw(e.Graphics);

            foreach(Ball ball in balls)
            {
                ball.Draw(e.Graphics);
            }

            UpdateBallCount(e.Graphics);

        }

        private void UpdateBallCount(Graphics graphics)
        {
            string message = "Ball Count: {0}";

            Font font = new Font("Comic Sans MS", 16);
            SolidBrush brush = new SolidBrush(Color.White);
            Point point = new Point(20, 20);

            graphics.DrawString(string.Format(message, balls.Count), font, brush, point);
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.Left:
                    {
                        paddle.Move(Paddle.Direction.Left);
                        //Invalidate();
                        break;
                    }
                case Keys.Right:
                    {
                        paddle.Move(Paddle.Direction.Right);
                        //Invalidate();
                        break;
                    }
                case Keys.Space:
                    {
                        if(AnimationTimer.Enabled)
                        {
                            //AnimationTimer.Stop();
                            balls.Add(new Ball(this.DisplayRectangle));
                        }
                        else
                        {
                            AnimationTimer.Start();
                        }
                        break;
                    }
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            CheckForCollisions();
            
            foreach(Ball ball in balls)
            {
                ball.Move();
            }
            
            //redraw screen each tick
            Invalidate();
        }


        private void CheckForCollisions()
        {

            balls.RemoveWhere(BallMissesPaddle);

            foreach(Ball ball in balls)
            {
                //ball left touches wall
                if (ball.DisplayArea.X <= 0)
                {
                    ball.XVelocity *= -1;
                }

                //ball touches right wall
                else if (ball.DisplayArea.X >= this.DisplayRectangle.Right - ball.Size)
                {
                    ball.XVelocity *= -1;
                }

                //ball touches ceiling
                else if (ball.DisplayArea.Y <= 0)
                {
                    ball.YVelocity *= -1;
                }

                //ball touches paddle
                else if (ball.DisplayArea.IntersectsWith(paddle.DisplayArea))
                {
                    ball.YVelocity *= -1;
                }

                
            }
            
        }

        private bool BallMissesPaddle(Ball ball)
        {
            return ball.DisplayArea.Bottom > this.DisplayRectangle.Bottom;
        }
    }
}

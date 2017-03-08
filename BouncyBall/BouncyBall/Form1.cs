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
        Ball ball;
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
            ball = new Ball(this.DisplayRectangle);
            
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            //draw the paddle
            paddle.Draw(e.Graphics);
            ball.Draw(e.Graphics);
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
                            AnimationTimer.Stop();
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
            ball.Move();

            //redraw screen each tick
            Invalidate();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceNavigator
{
    public partial class SpaceNavigatorForm : Form
    {
        Spaceship ship;
        HashSet<Asteroid> Asteroids = new HashSet<Asteroid>();
        HashSet<Bullet> Bullets = new HashSet<Bullet>();
        int health = 1000;

        public SpaceNavigatorForm()
        {
            InitializeComponent();
        }

        private void SpaceNavigatorForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            ship = new Spaceship(this.DisplayRectangle);
            //Asteroids.Add(new Asteroid(this.DisplayRectangle));

            AnimationTimer.Start();
            AsteroidTimer.Start();
        }

        private void SpaceNavigatorForm_Paint(object sender, PaintEventArgs e)
        {
            ship.Draw(e.Graphics);

            foreach(Asteroid asteroid in Asteroids)
            {
                asteroid.Draw(e.Graphics);
            }

            foreach(Bullet bullet in Bullets)
            {
                bullet.Draw(e.Graphics);
            }

            UpdateLifeCount(e.Graphics);
        }

        private void SpaceNavigatorForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.Left:
                    {
                        ship.Move(Spaceship.Direction.Left);
                        break;
                    }
                case Keys.Right:
                    {
                        ship.Move(Spaceship.Direction.Right);
                        break;
                    }
                case Keys.Space:
                    {
                        Bullets.Add(new Bullet(this.DisplayRectangle, ship));
                        break;
                    }
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            Asteroids.RemoveWhere(BulletHitsAsteroid);
            Asteroids.RemoveWhere(AsteroidOffScreen);
            Bullets.RemoveWhere(BulletOffScreen);
            CheckForCollisions();

            foreach (Asteroid asteroid in Asteroids)
            {
                asteroid.Move();
            }

            foreach(Bullet bullet in Bullets)
            {
                bullet.Move();
            }


            Invalidate();
        }

        private void CheckForCollisions()
        {
            foreach(Asteroid asteroid in Asteroids)
            {
                if (ship.DisplayArea.IntersectsWith(asteroid.DisplayArea))
                {
                    health -= 10;
                }
            }
            
        }

        private void AsteroidTimer_Tick(object sender, EventArgs e)
        {
            Asteroids.Add(new Asteroid(this.DisplayRectangle));
        }


        private bool BulletHitsAsteroid(Asteroid asteroid)
        {
            foreach(Bullet bullet in Bullets)
            {
                return asteroid.DisplayArea.IntersectsWith(bullet.DisplayArea);
            }
            return false;
        }


        private bool AsteroidOffScreen(Asteroid asteroid)
        {
            return asteroid.DisplayArea.Y > this.DisplayRectangle.Bottom;
        }

        private bool BulletOffScreen(Bullet bullet)
        {
            return bullet.DisplayArea.Y < this.DisplayRectangle.Top;
        }


        private void UpdateLifeCount(Graphics graphics)
        {
            string message = "Health: {0}";

            Font font = new Font("Comic Sans MS", 16);
            SolidBrush brush = new SolidBrush(Color.White);
            Point point = new Point(20, 20);

            graphics.DrawString(string.Format(message, health), font, brush, point);
        }
    }
}

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
        FinishLine finish;
        HashSet<Asteroid> Asteroids = new HashSet<Asteroid>();
        HashSet<Bullet> Bullets = new HashSet<Bullet>();
        HashSet<Health> Healths = new HashSet<Health>();
        int healthMeter = 100;

        public SpaceNavigatorForm()
        {
            InitializeComponent();
        }

        private void SpaceNavigatorForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            ship = new Spaceship(this.DisplayRectangle);
            finish = new FinishLine(this.DisplayRectangle);

            AnimationTimer.Start();
            AsteroidTimer.Start();
            HealthTimer.Start();
        }

        private void SpaceNavigatorForm_Paint(object sender, PaintEventArgs e)
        {
            ship.Draw(e.Graphics);
            finish.Draw(e.Graphics);

            foreach(Asteroid asteroid in Asteroids)
            {
                asteroid.Draw(e.Graphics);
            }

            foreach(Bullet bullet in Bullets)
            {
                bullet.Draw(e.Graphics);
            }

            foreach(Health health in Healths)
            {
                health.Draw(e.Graphics);
            }

            UpdateLifeCount(e.Graphics);
            UpdateDistance(e.Graphics);
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
            Healths.RemoveWhere(ShipCollectsHealth);
            Healths.RemoveWhere(HealthOffScreen);
            CheckForCollisions();

            foreach (Asteroid asteroid in Asteroids)
            {
                asteroid.Move();
            }

            foreach(Bullet bullet in Bullets)
            {
                bullet.Move();
            }

            foreach(Health health in Healths)
            {
                health.Move();
            }

            finish.Move();

            Invalidate();
        }

        private void CheckForCollisions()
        {
            foreach(Asteroid asteroid in Asteroids)
            {
                if (ship.DisplayArea.IntersectsWith(asteroid.DisplayArea))
                {
                    healthMeter -= 1;
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

        private bool ShipCollectsHealth(Health health)
        {
            if(ship.DisplayArea.IntersectsWith(health.DisplayArea))
            {
                healthMeter += 10;
                return true;
            }
            return false;
        }


        private bool AsteroidOffScreen(Asteroid asteroid)
        {
            return asteroid.DisplayArea.Y > this.DisplayRectangle.Bottom;
        }

        private bool HealthOffScreen(Health health)
        {
            return health.DisplayArea.Y > this.DisplayRectangle.Bottom;
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

            graphics.DrawString(string.Format(message, healthMeter), font, brush, point);
        }

        private void UpdateDistance(Graphics graphics)
        {
            string message = "Distance to Finish: {0}";

            Font font = new Font("Comic Sans MS", 16);
            SolidBrush brush = new SolidBrush(Color.White);
            Point point = new Point(20, 50);

            graphics.DrawString(string.Format(message, this.DisplayRectangle.Bottom - ship.DisplayArea.Height - (finish.DisplayArea.Y)), font, brush, point);
        }

        private void HealthTimer_Tick(object sender, EventArgs e)
        {
            Healths.Add(new Health(this.DisplayRectangle));
        }
    }
}

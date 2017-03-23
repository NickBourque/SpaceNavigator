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
        SplashScreen splash;
        LevelUp levelUpScreen;
        GameOver gameOver;
        Spaceship ship;
        FinishLine finish;
        HashSet<Asteroid> Asteroids = new HashSet<Asteroid>();
        HashSet<Bullet> Bullets = new HashSet<Bullet>();
        HashSet<Health> Healths = new HashSet<Health>();
        int healthMeter = 100;
        int asteroidsHit;
        bool running;
        bool alive = true;
        int level = 1;
        bool levelUp;

        List<Keys> KeyList = new List<Keys>();

        public SpaceNavigatorForm()
        {
            InitializeComponent();
        }

        private void SpaceNavigatorForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;


            splash = new SplashScreen(this.DisplayRectangle);
            levelUpScreen = new LevelUp(this.DisplayRectangle);
            gameOver = new GameOver(this.DisplayRectangle);
            ship = new Spaceship(this.DisplayRectangle);
            finish = new FinishLine(this.DisplayRectangle, ship, level);
            
        }

        public void LevelUpOrRestart()
        {
            finish = new FinishLine(this.DisplayRectangle, ship, level);
            //healthMeter = 100;
            Asteroids.Clear();
            Bullets.Clear();
            Healths.Clear();
        }

        public bool StartPause()
        {
            if(!running)
            {
                AnimationTimer.Start();
                AsteroidTimer.Start();
                HealthTimer.Start();
                return true;
            }
            else
            {
                AnimationTimer.Stop();
                AsteroidTimer.Stop();
                HealthTimer.Stop();
                Invalidate();
                return false;
            }
        }

        private void SpaceNavigatorForm_Paint(object sender, PaintEventArgs e)
        {
            finish.Draw(e.Graphics);
            ship.Draw(e.Graphics);
            
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

            if (levelUp)
            {
                levelUpScreen.Draw(e.Graphics);
                LevelUpOrRestart();
            }
            else if (!levelUp && !running)
            {
                
                splash.Draw(e.Graphics);
                
                
            }
            else if(!alive)
            {
                gameOver.Draw(e.Graphics);
            }

            UpdateHealthMeter(e.Graphics);
            UpdateDistance(e.Graphics);
            UpdateAsteroidHitCount(e.Graphics);
            UpdateLevel(e.Graphics);
        }

        private void SpaceNavigatorForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.Left:
                    {
                        if (!KeyList.Contains(Keys.Left))
                        {
                            KeyList.Add(Keys.Left);
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (!KeyList.Contains(Keys.Right))
                        {
                            KeyList.Add(Keys.Right);
                        }
                        break;
                    }
                case Keys.Space:
                    {
                        if (!KeyList.Contains(Keys.Space))
                        {
                            KeyList.Add(Keys.Space);
                        }
                        break;
                    }
                case Keys.Enter:
                    {
                        if (!levelUp)
                        {
                            running = StartPause();
                        }

                        if(!alive)
                        {
                            //RESET EVERYTHING TO LEVEL 1
                            level = 1;
                            LevelUpOrRestart();
                            asteroidsHit = 0;
                            healthMeter = 100;
                            alive = true;
                        }
                        else if (levelUp)
                        {
                            //RESET EVERYTHING TO NEXT LEVEL
                            LevelUpOrRestart();
                            levelUp = false;
                            running = false;
                            running = StartPause();
                        }

                        break;
                    }
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if(KeyList.Contains(Keys.Left))
            {
                ship.Move(Spaceship.Direction.Left);
            }

            if (KeyList.Contains(Keys.Right))
            {
                ship.Move(Spaceship.Direction.Right);
            }

            if (KeyList.Contains(Keys.Space))
            {
                if (Bullets.Count < 1)
                {
                    Bullets.Add(new Bullet(this.DisplayRectangle, ship));
                }
            }


            Asteroids.RemoveWhere(BulletHitsAsteroid);
            Asteroids.RemoveWhere(AsteroidOffScreen);
            Bullets.RemoveWhere(BulletOffScreen);
            Healths.RemoveWhere(ShipCollectsHealth);
            Healths.RemoveWhere(HealthOffScreen);
            CheckForAsteroidCollisions();
            CheckForFinish();

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

        private void CheckForFinish()
        {
            if(ship.DisplayArea.Y <= finish.DisplayArea.Y)
            {
                levelUp = !StartPause();
                level += 1;
            }
        }

        private void CheckForAsteroidCollisions()
        {
            foreach(Asteroid asteroid in Asteroids)
            {
                if (ship.DisplayArea.IntersectsWith(asteroid.DisplayArea))
                {
                    healthMeter -= 1;

                    if(healthMeter <= 0)
                    {
                        healthMeter = 0;
                        alive = StartPause();
                    }
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
                if(asteroid.DisplayArea.IntersectsWith(bullet.DisplayArea))
                {
                    Bullets.Remove(bullet);
                    asteroidsHit += 1;
                    return true;
                }
            }
            return false;
        }

        private bool ShipCollectsHealth(Health health)
        {
            if(ship.DisplayArea.IntersectsWith(health.DisplayArea))
            {
                healthMeter += 10;
                healthMeter = (healthMeter > 100) ? healthMeter = 100 : healthMeter;
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


        private void UpdateHealthMeter(Graphics graphics)
        {
            string message = "Health: {0}";

            Font font = new Font("Comic Sans MS", 16);
            SolidBrush brush = new SolidBrush(Color.White);
            Point point = new Point(20, 20);

            graphics.DrawString(string.Format(message, healthMeter + "%"), font, brush, point);
        }

        private void UpdateDistance(Graphics graphics)
        {
            string message = "Distance to Finish: {0} m";

            Font font = new Font("Comic Sans MS", 16);
            SolidBrush brush = new SolidBrush(Color.White);
            Point point = new Point(20, 50);

            graphics.DrawString(string.Format(message, ship.DisplayArea.Y - finish.DisplayArea.Y), font, brush, point);
        }


        private void UpdateAsteroidHitCount(Graphics graphics)
        {
            string message = "Asteroids Destroyed: {0}";

            Font font = new Font("Comic Sans MS", 16);
            SolidBrush brush = new SolidBrush(Color.White);
            Point point = new Point(20, 80);

            graphics.DrawString(string.Format(message, asteroidsHit), font, brush, point);
        }


        private void UpdateLevel(Graphics graphics)
        {
            string message = "Level: {0}";

            Font font = new Font("Comic Sans MS", 16);
            SolidBrush brush = new SolidBrush(Color.White);
            Point point = new Point(this.DisplayRectangle.Right -100, 20);

            graphics.DrawString(string.Format(message, level), font, brush, point);
        }


        private void HealthTimer_Tick(object sender, EventArgs e)
        {
            Healths.Add(new Health(this.DisplayRectangle));
        }

        private void SpaceNavigatorForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    {
                        if (KeyList.Contains(Keys.Left))
                        {
                            KeyList.Remove(Keys.Left);
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (KeyList.Contains(Keys.Right))
                        {
                            KeyList.Remove(Keys.Right);
                        }
                        break;
                    }
                case Keys.Space:
                    {
                        if (KeyList.Contains(Keys.Space))
                        {
                            KeyList.Remove(Keys.Space);
                        }
                        break;
                    }
            }
        }

    }
}

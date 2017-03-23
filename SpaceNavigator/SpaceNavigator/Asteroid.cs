using System;
using System.Drawing;

namespace SpaceNavigator
{
    /// <summary>
    /// Asteroids used in game-play.
    /// </summary>
    class Asteroid
    {
        private readonly int AsteroidHeight = 100;
        private readonly int AsteroidWidth = 200;

        private Rectangle AsteroidDisplayArea;
        private Rectangle GameplayArea;

        public int XVelocity { get; set; }
        public int YVelocity { get; set; }

        private Random random = new Random();
        private Random random2 = new Random();
        private Image image;

        /// <summary>
        /// Gets the Asteroid's display area.
        /// </summary>
        public Rectangle DisplayArea
        {
            get { return this.AsteroidDisplayArea; }
        }

        /// <summary>
        /// Constructor for Asteroid objects.
        /// </summary>
        /// <param name="gameplayArea">The Windows Form area.</param>
        public Asteroid(Rectangle gameplayArea)
        {
            this.GameplayArea = gameplayArea;

            AsteroidDisplayArea.Height = AsteroidHeight;
            AsteroidDisplayArea.Width = AsteroidWidth;

            //set starting location and velocity
            AsteroidDisplayArea.X = random.Next(GameplayArea.X, GameplayArea.Right);
            AsteroidDisplayArea.Y = random.Next(GameplayArea.Y - 60, GameplayArea.Y - 40);

            XVelocity = random.Next(-10, 10);
            YVelocity = random.Next(5, 25);
            
            image = Image.FromFile(@"images/Asteroid.png");
        }

        /// <summary>
        /// Moves the asteroid.
        /// </summary>
        public void Move()
        {
            AsteroidDisplayArea.X += XVelocity;
            AsteroidDisplayArea.Y += YVelocity;
        }

        /// <summary>
        /// Draws the asteroid.
        /// </summary>
        /// <param name="graphics">A Graphics object.</param>
        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, AsteroidDisplayArea);
        }

    }
}

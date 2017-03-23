using System;
using System.Drawing;

namespace SpaceNavigator
{
    /// <summary>
    /// Health objects are collected to increase the spaceship's health.
    /// </summary>
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

        /// <summary>
        /// Gets the health object's display area.
        /// </summary>
        public Rectangle DisplayArea
        {
            get { return this.HealthDisplayArea; }
        }

        /// <summary>
        /// Constructor for Health objects.
        /// </summary>
        /// <param name="gameplayArea">The Windows Form area.</param>
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

        /// <summary>
        /// Moves the Health object.
        /// </summary>
        public void Move()
        {
            HealthDisplayArea.X += XVelocity;
            HealthDisplayArea.Y += YVelocity;
        }

        /// <summary>
        /// Draws the Health object on screen.
        /// </summary>
        /// <param name="graphics">A Graphics object.</param>
        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, HealthDisplayArea);
        }

    }
}

using System.Drawing;

namespace SpaceNavigator
{
    /// <summary>
    /// The bullets used in game-play.
    /// </summary>
    class Bullet
    {
        private readonly int BulletHeight = 10;
        private readonly int BulletWidth = 10;

        private Rectangle BulletDisplayArea;
        private Rectangle GameplayArea;

        public int XVelocity { get; set; }
        public int YVelocity { get; set; }

        private Image image;

        /// <summary>
        /// Gets the Bullet's display area.
        /// </summary>
        public Rectangle DisplayArea
        {
            get { return this.BulletDisplayArea; }
        }

        /// <summary>
        /// Constructor for Bullet objects.
        /// </summary>
        /// <param name="GameplayArea">The Windows Form area.</param>
        /// <param name="ship">The Spaceship object.</param>
        public Bullet(Rectangle GameplayArea, Spaceship ship)
        {
            BulletDisplayArea.Height = BulletHeight;
            BulletDisplayArea.Width = BulletWidth;

            BulletDisplayArea.Y = ship.DisplayArea.Y;
            BulletDisplayArea.X = ship.DisplayArea.X + (ship.DisplayArea.Width / 2);

            XVelocity = 0;
            YVelocity = 20;

            image = Image.FromFile(@"images/Bullet.png");

            this.GameplayArea = GameplayArea;
        }

        /// <summary>
        /// Moves the bullet.
        /// </summary>
        public void Move()
        {
            BulletDisplayArea.X += XVelocity;
            BulletDisplayArea.Y -= YVelocity;
        }

        /// <summary>
        /// Draws the bullet.
        /// </summary>
        /// <param name="graphics">A Graphics object.</param>
        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, BulletDisplayArea);
        }
    }
}

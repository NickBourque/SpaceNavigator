using System.Drawing;

namespace SpaceNavigator
{
    /// <summary>
    /// The Finish Line used in game-play.
    /// </summary>
    class FinishLine
    {
        private readonly int FinishLineHeight = 72;
        private readonly int FinishLineWidth = 2480;

        private Rectangle FinishLineDisplayArea;
        private Rectangle GameplayArea;

        public int XVelocity { get; set; }
        public int YVelocity { get; set; }
        
        private Image image;

        /// <summary>
        /// Gets the display area of the Finish Line.
        /// </summary>
        public Rectangle DisplayArea
        {
            get { return this.FinishLineDisplayArea; }
        }

        /// <summary>
        /// Constructor for the finish line.
        /// </summary>
        /// <param name="gameplayArea">The Windows Form area.</param>
        /// <param name="ship">A Spaceship object.</param>
        /// <param name="level">The current game level.</param>
        public FinishLine(Rectangle gameplayArea, Spaceship ship, int level)
        {
            this.GameplayArea = gameplayArea;

            FinishLineDisplayArea.Height = FinishLineHeight;
            FinishLineDisplayArea.Width = FinishLineWidth;

            //set starting location and velocity
            FinishLineDisplayArea.X = 0;
            FinishLineDisplayArea.Y = ship.DisplayArea.Y - (level * 10000);
            XVelocity = 0;
            YVelocity = 8;

            image = Image.FromFile(@"images/FinishLine.png");
        }
        
        /// <summary>
        /// Moves the Finish Line.
        /// </summary>
        public void Move()
        {
            FinishLineDisplayArea.X += XVelocity;
            FinishLineDisplayArea.Y += YVelocity;
        }

        /// <summary>
        /// Draws the Finish Line.
        /// </summary>
        /// <param name="graphics">A Graphics object.</param>
        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, FinishLineDisplayArea);
        }
    }
}

using System.Drawing;

namespace SpaceNavigator
{
    /// <summary>
    /// The level up message seen when passing to the next level.
    /// </summary>
    class LevelUp
    {
        private readonly int LevelUpHeight = 97;
        private readonly int LevelUpWidth = 420;

        private Rectangle LevelUpDisplayArea;
        private Rectangle GameplayArea;

        private Image image;

        /// <summary>
        /// Constructor for the Level Up object.
        /// </summary>
        /// <param name="GameplayArea">The Windows Form area.</param>
        public LevelUp(Rectangle GameplayArea)
        {
            LevelUpDisplayArea.Height = LevelUpHeight;
            LevelUpDisplayArea.Width = LevelUpWidth;

            LevelUpDisplayArea.Y = (GameplayArea.Height / 2) - (LevelUpHeight / 2);
            LevelUpDisplayArea.X = (GameplayArea.Width / 2) - (LevelUpWidth / 2);

            image = Image.FromFile(@"images/LevelUp.png");

            this.GameplayArea = GameplayArea;
        }

        /// <summary>
        /// Draws the Level Up screen.
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, LevelUpDisplayArea);
        }
    }
}

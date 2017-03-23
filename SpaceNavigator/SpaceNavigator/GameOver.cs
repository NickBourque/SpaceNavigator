using System.Drawing;

namespace SpaceNavigator
{
    /// <summary>
    /// The Game Over Screen.
    /// </summary>
    class GameOver
    {
        private readonly int GameOverHeight = 524;
        private readonly int GameOverWidth = 420;

        private Rectangle GameOverDisplayArea;
        private Rectangle GameplayArea;

        private Image image;

        /// <summary>
        /// Constructor for the Game Over Screen.
        /// </summary>
        /// <param name="GameplayArea"></param>
        public GameOver(Rectangle GameplayArea)
        {
            GameOverDisplayArea.Height = GameOverHeight;
            GameOverDisplayArea.Width = GameOverWidth;

            GameOverDisplayArea.Y = (GameplayArea.Height / 2) - (GameOverHeight / 2);
            GameOverDisplayArea.X = (GameplayArea.Width / 2) - (GameOverWidth / 2);

            image = Image.FromFile(@"images/GameOver.png");

            this.GameplayArea = GameplayArea;
        }

        /// <summary>
        /// Draws the Game Over Screen.
        /// </summary>
        /// <param name="graphics">A Graphics object.</param>
        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, GameOverDisplayArea);
        }
    }
}

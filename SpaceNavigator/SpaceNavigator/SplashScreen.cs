using System.Drawing;

namespace SpaceNavigator
{
    /// <summary>
    /// The splash screen for the game.
    /// </summary>
    class SplashScreen
    {
        private readonly int SplashHeight = 524;
        private readonly int SplashWidth = 420;

        private Rectangle SplashDisplayArea;
        private Rectangle GameplayArea;

        private Image image;

        /// <summary>
        /// Constructor for the splash screen.
        /// </summary>
        /// <param name="GameplayArea">The windows form area.</param>
        public SplashScreen(Rectangle GameplayArea)
        {
            SplashDisplayArea.Height = SplashHeight;
            SplashDisplayArea.Width = SplashWidth;

            SplashDisplayArea.Y = (GameplayArea.Height / 2) - (SplashHeight / 2);
            SplashDisplayArea.X = (GameplayArea.Width / 2) - (SplashWidth / 2);

            image = Image.FromFile(@"images/SplashScreen.png");

            this.GameplayArea = GameplayArea;
        }

        /// <summary>
        /// Draws the splash screen image.
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, SplashDisplayArea);
        }

    }
}

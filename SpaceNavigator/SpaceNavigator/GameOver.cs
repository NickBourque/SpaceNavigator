using System.Drawing;

namespace SpaceNavigator
{
    class GameOver
    {
        private readonly int GameOverHeight = 524;
        private readonly int GameOverWidth = 420;

        private Rectangle GameOverDisplayArea;
        private Rectangle GameplayArea;

        private Image image;


        public GameOver(Rectangle GameplayArea)
        {
            GameOverDisplayArea.Height = GameOverHeight;
            GameOverDisplayArea.Width = GameOverWidth;

            GameOverDisplayArea.Y = (GameplayArea.Height / 2) - (GameOverHeight / 2);
            GameOverDisplayArea.X = (GameplayArea.Width / 2) - (GameOverWidth / 2);

            image = Image.FromFile(@"images/GameOver.png");

            this.GameplayArea = GameplayArea;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, GameOverDisplayArea);
        }
    }
}

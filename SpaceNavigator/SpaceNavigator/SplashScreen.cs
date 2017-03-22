using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceNavigator
{
    class SplashScreen
    {
        private readonly int SplashHeight = 524;
        private readonly int SplashWidth = 420;

        private Rectangle SplashDisplayArea;
        private Rectangle GameplayArea;

        private Image image;


        public SplashScreen(Rectangle GameplayArea)
        {
            SplashDisplayArea.Height = SplashHeight;
            SplashDisplayArea.Width = SplashWidth;

            SplashDisplayArea.Y = (GameplayArea.Height / 2) - (SplashHeight / 2);
            SplashDisplayArea.X = (GameplayArea.Width / 2) - (SplashWidth / 2);

            image = Image.FromFile(@"images/SplashScreen.png");

            this.GameplayArea = GameplayArea;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, SplashDisplayArea);
        }

    }
}

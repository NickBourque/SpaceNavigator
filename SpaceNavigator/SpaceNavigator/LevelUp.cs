using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceNavigator
{
    class LevelUp
    {
        private readonly int LevelUpHeight = 97;
        private readonly int LevelUpWidth = 420;

        private Rectangle LevelUpDisplayArea;
        private Rectangle GameplayArea;

        private Image image;


        public LevelUp(Rectangle GameplayArea)
        {
            LevelUpDisplayArea.Height = LevelUpHeight;
            LevelUpDisplayArea.Width = LevelUpWidth;

            LevelUpDisplayArea.Y = (GameplayArea.Height / 2) - (LevelUpHeight / 2);
            LevelUpDisplayArea.X = (GameplayArea.Width / 2) - (LevelUpWidth / 2);

            image = Image.FromFile(@"images/LevelUp.png");

            this.GameplayArea = GameplayArea;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, LevelUpDisplayArea);
        }
    }
}

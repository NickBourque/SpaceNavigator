using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceNavigator
{
    class FinishLine
    {
        private readonly int FinishLineHeight = 72;
        private readonly int FinishLineWidth = 2480;

        private Rectangle FinishLineDisplayArea;
        private Rectangle GameplayArea;

        public int XVelocity { get; set; }
        public int YVelocity { get; set; }
        
        private Image image;


        public Rectangle DisplayArea
        {
            get { return this.FinishLineDisplayArea; }
        }


        public FinishLine(Rectangle gameplayArea)
        {
            this.GameplayArea = gameplayArea;

            FinishLineDisplayArea.Height = FinishLineHeight;
            FinishLineDisplayArea.Width = FinishLineWidth;

            //set starting location
            FinishLineDisplayArea.X = 0;
            FinishLineDisplayArea.Y = -10000;

            XVelocity = 0;
            YVelocity = 10;

            image = Image.FromFile(@"images/FinishLine.png");
        }
        
        public void Move()
        {
            FinishLineDisplayArea.X += XVelocity;
            FinishLineDisplayArea.Y += YVelocity;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, FinishLineDisplayArea);
        }
    }
}

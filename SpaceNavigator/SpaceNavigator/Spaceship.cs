using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceNavigator
{
    class Spaceship
    {
        private readonly int ShipHeight = 60;
        private readonly int ShipWidth = 40;

        private Rectangle ShipDisplayArea;
        private Rectangle GameplayArea;

        private Image image;

        public enum Direction { Left, Right }

        public Rectangle DisplayArea
        {
            get { return this.ShipDisplayArea; }
        }


        public Spaceship(Rectangle GameplayArea)
        {
            ShipDisplayArea.Height = ShipHeight;
            ShipDisplayArea.Width = ShipWidth;

            ShipDisplayArea.Y = GameplayArea.Bottom - 75;
            ShipDisplayArea.X = (GameplayArea.Width / 2) - (ShipWidth / 2);

            image = Image.FromFile(@"images/Spaceship.png");

            this.GameplayArea = GameplayArea;
        }


        public void Draw(Graphics graphics)
        {
            //using (SolidBrush brush = new SolidBrush(Color.Orange))
            //{
            //    graphics.FillRectangle(brush, ShipDisplayArea);
            //}

            graphics.DrawImage(image, ShipDisplayArea);
        }


        public void Move(Direction direction)
        {
            switch(direction)
            {
                case Direction.Left:
                    {
                        //if ShipDisplayArea.X >= 20 then (?) ShipDisplayArea.X -= 20 else (:) don't move.
                        ShipDisplayArea.X = (ShipDisplayArea.X >= 20) ? ShipDisplayArea.X - 20 : 0;
                        break;
                    }
                case Direction.Right:
                    {

                        ShipDisplayArea.X = (ShipDisplayArea.X >= GameplayArea.Right - ShipWidth) ? GameplayArea.Right - ShipWidth : ShipDisplayArea.X += 20;
                        
                        break;
                    }
            }
        }

    }
}

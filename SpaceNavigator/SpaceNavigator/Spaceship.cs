using System.Drawing;

namespace SpaceNavigator
{
    /// <summary>
    /// A spaceship controlled by the player.
    /// </summary>
    class Spaceship
    {
        private readonly int ShipHeight = 60;
        private readonly int ShipWidth = 40;

        private int ShipOffset = 75;

        private Rectangle ShipDisplayArea;
        private Rectangle GameplayArea;

        private Image image;

        /// <summary>
        /// A Direction object used to give the spaceship left and right movements.
        /// </summary>
        public enum Direction { Left, Right }

        /// <summary>
        /// Gets the ship's display area.
        /// </summary>
        public Rectangle DisplayArea
        {
            get { return this.ShipDisplayArea; }
        }

        /// <summary>
        /// Constructor for the spaceship object.
        /// </summary>
        /// <param name="GameplayArea">The Windows Form area.</param>
        public Spaceship(Rectangle GameplayArea)
        {
            ShipDisplayArea.Height = ShipHeight;
            ShipDisplayArea.Width = ShipWidth;

            ShipDisplayArea.Y = GameplayArea.Bottom - ShipOffset;
            ShipDisplayArea.X = (GameplayArea.Width / 2) - (ShipWidth / 2);

            image = Image.FromFile(@"images/Spaceship.png");

            this.GameplayArea = GameplayArea;
        }

        /// <summary>
        /// Draws the Spaceship.
        /// </summary>
        /// <param name="graphics">A Graphics object.</param>
        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, ShipDisplayArea);
        }

        /// <summary>
        /// Moves the spaceship left and right.
        /// </summary>
        /// <param name="direction">A Direction object; either left or right.</param>
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

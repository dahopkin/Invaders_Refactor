using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Invaders
{
    class ShieldBlock
    {
        private Color borderColor = Color.Green;
        private Color innerColor = Color.FromArgb(127, Color.Green);
        private static Size blockSize = new Size(30, 20);

        public static int BlockWidth { get { return blockSize.Width; } }
        public static int BlockHeight { get { return blockSize.Height; } }

        /// <summary>
        /// Gets the location of the Shield Block.
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// Instantiates a new ShieldBlock instance at a specified location.
        /// </summary>
        /// <param name="location">The point where the Shield Block should be created</param>
        public ShieldBlock(Point location) {
            this.Location = location;
        } // end constructor method ShieldBlock

        /// <summary>
        /// Gets a rectangle dependent on current ShieldBlock's location.
        /// </summary>
        public Rectangle Area
        {
            get { return new Rectangle(Location, blockSize); }
        } // end property Area

        /// <summary>
        /// Gets the point needed to create a new ShieldBlock to the right of the current one.
        /// </summary>
        public Point NewBlockRight
        {
            get { return new Point(Area.Right, Location.Y); }
        } // end method NewBlockRight

        /// <summary>
        /// Gets the point needed to create a new ShieldBlock to the left of the current one.
        /// </summary>
        public Point NewBlockLeft
        {
            get { return new Point((Location.X - Area.Width), Location.Y); }
        } // end method NewBlockLeft

        /// <summary>
        /// Gets the point needed to create a new ShieldBlock below the current one.
        /// </summary>
        public Point NewBlockBottom
        {
            get { return new Point(Location.X, Area.Bottom); }
        } // end method NewBlockBottom

        /// <summary>
        /// Gets the point needed to create a new ShieldBlock on top of the current one.
        /// </summary>
        public Point NewBlockTop
        {
            get { return new Point(Location.X, (Location.Y - Area.Height)); }
        } // end method NewBlockTop

        /// <summary>
        /// Draws a ShieldBlock onto the specified graphics object (and therefore the screen).
        /// </summary>
        /// <param name="g">The graphics object to draw onto.</param>
        public void Draw(Graphics g)
        {
            Pen borderPen = new Pen(borderColor);
            Brush backColorBrush = new SolidBrush(innerColor);
            g.FillRectangle(backColorBrush, Area);
            g.DrawRectangle(borderPen, Area);
        } // end method Draw
    }
}

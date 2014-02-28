/*
 * Created by Daniel Hopkins, based on the Invaders Lab
 * in Head First C# (2nd Edition).
 * E-Mail: dahopkin2@gmail.com
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace Invaders
{
    class Bomb : AreaUser
    {
        private const int moveInterval = 20;
        private const int width = 30;
        private const int height = 30;
        private const int expansionDistance = 5;
        private Color borderColor = Color.Orange;
        private Color innerColor = Color.FromArgb(127, Color.Orange);
        private bool expanding;
        private DateTime expansionStartTime;
        public bool Expanding {
            get { return expanding; }
            set {
                expansionStartTime = DateTime.Now;
                expanding = value;
            } // end set 
        } // end property Expanding

        public bool Exploded { get; set; }

        private Direction direction;
        private Rectangle boundaries;

        /// <summary>
        /// Instantiates a new instance of the Shot Class from a location, a direction, and a boundary rectangle.
        /// </summary>
        /// <param name="location">The shot's starting location</param>
        /// <param name="direction"> The shot's direction.</param>
        /// <param name="boundaries">The rectangle representing the gaming area.</param>
        public Bomb(Point location, Direction direction,
            Rectangle boundaries) : base(location, width, height){
            this.direction = direction;
            this.boundaries = boundaries;
            this.Expanding = false;
            this.Exploded = false;
        } // end constructor method Bomb

        /// <summary>
        /// This method draws a circle representing the bomb (which expands upon hitting an enemy) 
        /// onto the screen.
        /// </summary>
        /// <param name="g">The Graphics object to draw onto.</param>
        public void Draw(Graphics g)
        {
            if (!Expanding && !Exploded)
            {
                // The bomb hasn't hit an enemy. Make it look normal.
                Pen borderPen = new Pen(borderColor);
                Brush backColorBrush = new SolidBrush(innerColor);
                g.FillEllipse(backColorBrush, Area);
                g.DrawEllipse(borderPen, Area);
            }
            else if (Expanding && !Exploded) {
                // The bomb is expanding. Stretch the area.
                DateTime expansionCurrentTime = DateTime.Now;
                TimeSpan duration = expansionCurrentTime - expansionStartTime;
                if (duration.Seconds < 2)
                {
                    Point expandedPoint = new Point((Location.X - expansionDistance), (Location.Y - expansionDistance));
                    Location = expandedPoint;
                    areaSize = new Size((areaSize.Width + expansionDistance), (areaSize.Height + expansionDistance));
                    Pen borderPen = new Pen(borderColor);
                    Brush backColorBrush = new SolidBrush(innerColor);
                    g.FillEllipse(backColorBrush, Area);
                    g.DrawEllipse(borderPen, Area);
                }
                else {
                    Expanding = false;
                    Exploded = true;
                }
            } 
        } // end method Draw

        /// <summary>
        /// This method moves a shot object in the specified direction, returning 
        /// true if the bomb object is still within the game area's boundaries. 
        /// The bomb stays in place if it's expanding.
        /// </summary>
        /// <param name="directionToMove">The direction the shot should move.</param>
        /// <returns>A boolean specifying whether it's beyond the game area's boundaries.</returns>
        public bool Move(Direction directionToMove)
        {
            if (!Expanding && !Exploded)
            {
                switch (directionToMove)
                {
                    case Direction.Up:
                        Location = new Point(Location.X, Location.Y - moveInterval);
                        break;
                    case Direction.Down:
                        Location = new Point(Location.X, Location.Y + moveInterval);
                        break;
                    default:
                        break;
                }
                if ((Location.Y <= boundaries.Top) || (Location.Y >= boundaries.Bottom))
                    return false;
                return true;
            }
            else if (Expanding && !Exploded) return true;
            else return false;
        } // end method Move

       }
}

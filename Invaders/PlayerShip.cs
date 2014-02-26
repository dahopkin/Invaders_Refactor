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
    class PlayerShip : ImageUser
    {
        private DateTime deadShipStartTime;

        private const int HorizontalInterval = 10;

        private int deadShipHeight;
        
        /// <summary>
        /// Initializes a new instance of the PlayerShip class using a Point.
        /// </summary>
        /// <param name="location">The player ship's starting location.</param>
        public PlayerShip(Point location) : base(location){
            this.Location = location;
            image = ResizeImage(Properties.Resources.player, 40, 40);
            Alive = true;
            deadShipHeight = image.Height;
        } // end constructor method PlayerShip

        private bool alive;

        /// <summary>
        /// This method returns a bool stating whether the player ship is alive or not.
        /// </summary>
        public bool Alive {
            get { return alive;}
            set { 
                alive = value;
                deadShipStartTime = DateTime.Now;
            } // end set 
        } // end property Alive

        /// <summary>
        /// This method will draw the player ship onto the screen, and will 
        /// draw the 3-second death animation if the player is dead (was hit by
        /// an invader's shot). It will toggle the Alive property at the end
        /// of the animation.
        /// </summary>
        /// <param name="g">The Grahpics object to draw onto.</param>
        public void Draw(Graphics g)
        {
            if (!Alive)
            {
                Bitmap deadShipImage = new Bitmap(image);
                DateTime deadShipCurrentTime = DateTime.Now;
                TimeSpan duration = deadShipCurrentTime - deadShipStartTime;
                if(duration.Seconds < 3){
                    if (deadShipHeight > 0) deadShipHeight -= 2;
                    g.DrawImage(deadShipImage, Location.X, Location.Y, Area.Width, deadShipHeight);
                } // end if 
                else{
                    Alive = true;
                    deadShipHeight = image.Height;
                    g.DrawImageUnscaled(image, Location);
                } // end else 
            } // end if 
            else {
                g.DrawImageUnscaled(image, Location);
            } // end else 
        } // end method Draw

        /// <summary>
        /// This method moves the playership either left or right.
        /// </summary>
        /// <param name="directionToMove">The direction the player ship moves.</param>
        public void Move(Direction directionToMove)
        {
            Point moveTo;
            switch (directionToMove)
            {
                case Direction.Left:
                    moveTo = new Point(Location.X - HorizontalInterval, Location.Y);
                    Location = moveTo;
                    break;

                case Direction.Right:
                    moveTo = new Point(Location.X + HorizontalInterval, Location.Y);
                    Location = moveTo;
                    break;

                default:
                    break;
            } // end switch 
        } // end method Move
    }
}

/*
 * 
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
    abstract class Invader : ImageUser
    {
        protected const int HorizontalInterval = 10;
        protected const int VerticalInterval = 40;

        /// <summary>
        /// Gets the current ShipType of the invader.
        /// </summary>
        public ShipType InvaderType { get; protected set; }
        
        /// <summary>
        /// Gets the invader's score (points a player gets for killing it).
        /// </summary>
        public int Score { get; protected set; }

        protected Bitmap[] invaderImages;

        /// <summary>
        /// Instantiates an Invader object from a ShipType, a location, and a score.
        /// </summary>
        /// <param name="invaderType">The type of invader ship.</param>
        /// <param name="location">The invader's starting location</param>
        /// <param name="score">The invader's score (points a player gets for killing it).</param>
        public Invader(ShipType invaderType, Point location, int score) : base(location) {
            this.InvaderType = invaderType;
            this.Location = location;
            this.Score = score;/*
            InitializeInvaderImages(invaderType);
            image = invaderImages[0];*/
            
        } // end constructor

        /// <summary>
        /// Moves the invader in a specified direction.
        /// </summary>
        /// <param name="directionToMove">The direction the invader moves.</param>
        public virtual void Move(Direction directionToMove)
        {
            switch (directionToMove) {
                case Direction.Left:
                    Location = new Point(Location.X - HorizontalInterval, Location.Y);
                    break;
                case Direction.Right:
                    Location = new Point(Location.X + HorizontalInterval, Location.Y);
                    break;
                case Direction.Down:
                    Location = new Point(Location.X, Location.Y + VerticalInterval);
                    break;
                default:
                    break;
            } // end switch 
        } // end method Move

        public abstract void Draw(Graphics g, int animationCell);

    }
}

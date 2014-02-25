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
    class Invader : ImageUser
    {
        private const int HorizontalInterval = 10;
        private const int VerticalInterval = 40;

        /// <summary>
        /// Gets the current ShipType of the invader.
        /// </summary>
        public ShipType InvaderType { get; private set; }
        
        /// <summary>
        /// Gets the invader's score (points a player gets for killing it).
        /// </summary>
        public int Score { get; private set; }

        private Bitmap[] invaderImages;

        /// <summary>
        /// Instantiates an Invader object from a ShipType, a location, and a score.
        /// </summary>
        /// <param name="invaderType">The type of invader ship.</param>
        /// <param name="location">The invader's starting location</param>
        /// <param name="score">The invader's score (points a player gets for killing it).</param>
        public Invader(ShipType invaderType, Point location, int score) {
            this.InvaderType = invaderType;
            this.Location = location;
            this.Score = score;
            InitializeInvaderImages(invaderType);
            image = invaderImages[0];
            
        } // end constructor

        /// <summary>
        /// Moves the invader in a specified direction.
        /// </summary>
        /// <param name="directionToMove">The direction the invader moves.</param>
        public void Move(Direction directionToMove)
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

        /// <summary>
        /// Draws an invader onto the screen from a Graphics object and a number for current animation cell.
        /// </summary>
        /// <param name="g">The Grahpics object to draw onto.</param>
        /// <param name="animationCell">The animation cell number representing which invader image to return.</param>
        public void Draw(Graphics g, int animationCell)
        {
            image = invaderImages[animationCell];
            g.DrawImageUnscaled(image, Location);
        } // end method Draw

        /// <summary>
        /// Initializes the invader's image array by returning the right array to use,
        /// depending on ship type.
        /// </summary>
        /// <param name="invaderType">The ship type that decides which images to use.</param>
        private void InitializeInvaderImages(ShipType invaderType)
        {

            switch (invaderType)
            {
                case ShipType.Bug:
                    invaderImages = GetBugImages();
                    break;
                case ShipType.Satellite:
                    invaderImages = GetSatelliteImages();
                    break;
                case ShipType.Saucer:
                    invaderImages = GetSaucerImages();
                    break;
                case ShipType.Spaceship:
                    invaderImages = GetSpaceShipImages();
                    break;
                case ShipType.Star:
                    invaderImages = GetStarImages();
                    break;
            } // end switch
        }// end method InitializeInvaderImages 

        /// <summary>
        /// Returns a bitmap array of all the Bug invader's images, resized to the standard size.
        /// </summary>
        /// <returns>A bitmap array of all the Bug invader's images, resized to the standard size.</returns>
        private Bitmap[] GetBugImages() {
            Bitmap[] bugImages = new Bitmap[]{
                ResizeImage(Properties.Resources.bug1, userSize.Width, userSize.Height),
                ResizeImage(Properties.Resources.bug2, userSize.Width, userSize.Height),
                ResizeImage(Properties.Resources.bug3, userSize.Width, userSize.Height),
                ResizeImage(Properties.Resources.bug4, userSize.Width, userSize.Height)
            };

            return bugImages;
        } // end method GetBugImages

        /// <summary>
        /// Returns a bitmap array of all the Saucer invader's images, resized to the standard size.
        /// </summary>
        /// <returns>A bitmap array of all the Saucer invader's images, resized to the standard size.</returns>
        private Bitmap[] GetSaucerImages()
        {
            Bitmap[] saucerImages = new Bitmap[]{
                ResizeImage(Properties.Resources.flyingsaucer1, userSize.Width, userSize.Height),
                ResizeImage(Properties.Resources.flyingsaucer2, userSize.Width, userSize.Height),
                ResizeImage(Properties.Resources.flyingsaucer3, userSize.Width, userSize.Height),
                ResizeImage(Properties.Resources.flyingsaucer4, userSize.Width, userSize.Height)
            };

            return saucerImages;
        } // end method GetSaucerImages

        /// <summary>
        /// Returns a bitmap array of all the Satellite invader's images, resized to the standard size.
        /// </summary>
        /// <returns>A bitmap array of all the Satellite invader's images, resized to the standard size.</returns>
        private Bitmap[] GetSatelliteImages()
        {
            Bitmap[] satelliteImages = new Bitmap[]{
                ResizeImage(Properties.Resources.satellite1, userSize.Width, userSize.Height),
                ResizeImage(Properties.Resources.satellite2, userSize.Width, userSize.Height),
                ResizeImage(Properties.Resources.satellite3, userSize.Width, userSize.Height),
                ResizeImage(Properties.Resources.satellite4, userSize.Width, userSize.Height)
            };

            return satelliteImages;
        } // end method GetSatelliteImages

        /// <summary>
        /// Returns a bitmap array of all the Spaceship invader's images, resized to the standard size.
        /// </summary>
        /// <returns>A bitmap array of all the Spaceship invader's images, resized to the standard size.</returns>
        private Bitmap[] GetSpaceShipImages()
        {
            Bitmap[] spaceshipImages = new Bitmap[]{
                ResizeImage(Properties.Resources.spaceship1, userSize.Width, userSize.Height),
                ResizeImage(Properties.Resources.spaceship2, userSize.Width, userSize.Height),
                ResizeImage(Properties.Resources.spaceship3, userSize.Width, userSize.Height),
                ResizeImage(Properties.Resources.spaceship4, userSize.Width, userSize.Height)
            };

            return spaceshipImages;
        } // end method GetSpaceShipImages

        /// <summary>
        /// Returns a bitmap array of all the Star invader's images, resized to the standard size.
        /// </summary>
        /// <returns>A bitmap array of all the Star invader's images, resized to the standard size.</returns>
        private Bitmap[] GetStarImages()
        {
            Bitmap[] starImages = new Bitmap[]{
                ResizeImage(Properties.Resources.star1, userSize.Width, userSize.Height),
                ResizeImage(Properties.Resources.star2, userSize.Width, userSize.Height),
                ResizeImage(Properties.Resources.star3, userSize.Width, userSize.Height),
                ResizeImage(Properties.Resources.star4, userSize.Width, userSize.Height)
            };

            return starImages;
        } // end method GetStarImages

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Invaders
{
    abstract class ImageUser
    {

        protected Bitmap image;

        protected Size userSize = new Size(40, 40);
        
        /// <summary>
        /// Gets the current Point where the PlayerShip is located.
        /// </summary>
        public Point Location { get; protected set; }

        /// <summary>
        /// Gets a rectangle dependent on current player ship location.
        /// </summary>
        public Rectangle Area
        {
            get { return new Rectangle(Location, image.Size); }
        } // end property Area

        public Point TopMiddle
        {
            get 
            {
                return new Point((Area.Left + Area.Width / 2), Area.Top);
            }
        } // end property TopMiddle

        /// <summary>
        /// Gets the point at the middle of the bottom of the invader's area. The invader
        /// will shoot from this area.
        /// </summary>
        public Point BottomMiddle { 
            get 
            { 
                return new Point((Area.Left + Area.Width / 2), Area.Bottom); 
            } 
        } // end property BottomMiddle

        /// <summary>
        /// Returns a bitmap image of the playership.
        /// </summary>
        /// <returns>A bitmap image for displaying the lives left.</returns>
        public Bitmap GetImage()
        {
            return ResizeImage(image, 40, 40);
        } // end method GetLivesLeftImage

        /// <summary>
        /// This method changes the height and width of an image to a custom size.
        /// </summary>
        /// <param name="picture">The original picture to resize</param>
        /// <param name="width">The desired width of the new picture.</param>
        /// <param name="height">The desired height of the new picture.</param>
        /// <returns>A resized Bitmap Image</returns>
        protected static Bitmap ResizeImage(Bitmap picture, int width, int height)
        {
            Bitmap resizedPicture = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedPicture))
            {
                graphics.DrawImage(picture, 0, 0, width, height);
            } // end using
            return resizedPicture;
        } // end method ResizeImage
    }
}

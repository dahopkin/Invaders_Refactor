using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Invaders
{
    abstract class ImageUser : AreaUser
    {        
        protected Bitmap image;

        public ImageUser(Point location)
            : base(location, new Size(40,40)){}

      
        /// <summary>
        /// Returns a bitmap image of the object.
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

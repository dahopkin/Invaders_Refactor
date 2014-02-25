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
        /// Gets the current Point where the object is located.
        /// </summary>
        public Point Location { get; protected set; }

        /// <summary>
        /// Gets a rectangle dependent on current object's location.
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
            } // end get 
        } // end property TopMiddle

        /// <summary>
        /// Gets the point at the middle of the bottom of the object's area.
        /// </summary>
        public Point BottomMiddle { 
            get 
            { 
                return new Point((Area.Left + Area.Width / 2), Area.Bottom); 
            } // end get 
        } // end property BottomMiddle

        /// <summary>
        /// Gets the point at the lower right corner of the object's area.
        /// </summary>
        public Point BottomRight
        {
            get
            {
                return new Point(Area.Right, Area.Bottom);
            } // end get 
        } // end property BottomRight

        /// <summary>
        /// Gets the point at the lower left corner of the object's area.
        /// </summary>
        public Point BottomLeft
        {
            get
            {
                return new Point(Area.Left, Area.Bottom);
            } // end get 
        } // end property BottomLeft

        /// <summary>
        /// Gets the point at the upper right corner of the object's area.
        /// </summary>
        public Point TopRight
        {
            get
            {
                return new Point(Area.Right, Area.Top);
            } // end get 
        } // end property BottomRight

        /// <summary>
        /// Gets the point at the middle of the left side of the object's area.
        /// </summary>
        public Point LeftMiddle
        {
            get
            {
                return new Point(Area.Left, (Area.Top + Area.Height / 2));
            } // end get 
        } // end property BottomRight

        /// <summary>
        /// Gets the point at the middle of the right side of the object's area.
        /// </summary>
        public Point RightMiddle
        {
            get
            {
                return new Point(Area.Right, (Area.Top + Area.Height / 2));
            } // end get 
        } // end property BottomRight

        /// <summary>
        /// Gets the point at the center of the object's area.
        /// </summary>
        public Point Middle
        {
            get
            {
                return new Point((Area.Left + Area.Width / 2), (Area.Top + Area.Height / 2));
            } // end get 
        } // end property BottomRight

        /// <summary>
        /// Gets a list of points representing all corners and middles of the object's area.
        /// </summary>
        public List<Point> CollisionPoints {
            get {
                return new List<Point>(){
                    this.Location,
                    this.TopMiddle,
                    this.TopRight,
                    this.LeftMiddle,
                    this.Middle,
                    this.RightMiddle,
                    this.BottomLeft,
                    this.BottomMiddle,
                    this.BottomRight,
                };
            } // end get 
        } // end property CollisionPoints
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

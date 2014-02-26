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
    class MotherShip : Invader
    {
        
        /// <summary>
        /// Instantiates an Invader object from a ShipType, a location, and a score.
        /// </summary>
        /// <param name="invaderType">The type of invader ship.</param>
        /// <param name="location">The invader's starting location</param>
        /// <param name="score">The invader's score (points a player gets for killing it).</param>
        public MotherShip(Point location): base(ShipType.Mothership, location, 250)
        {
            InitializeInvaderImages(InvaderType);
            image = invaderImages[0];
        } // end constructor

       
        /// <summary>
        /// Draws an invader onto the screen from a Graphics object and a number for current animation cell.
        /// </summary>
        /// <param name="g">The Grahpics object to draw onto.</param>
        /// <param name="animationCell">The animation cell number representing which invader image to return.</param>
        public override void Draw(Graphics g, int animationCell)
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
            invaderImages = GetMotherShipImages();

        }// end method InitializeInvaderImages 

        /// <summary>
        /// Returns a bitmap array of all the Mothership invader's images, resized to the standard size.
        /// </summary>
        /// <returns>A bitmap array of all the Bug invader's images, resized to the standard size.</returns>
        private Bitmap[] GetMotherShipImages() {
            Bitmap[] motherShipImages = new Bitmap[]{
                ResizeImage(Properties.Resources.watchit1, areaSize.Width, areaSize.Height),
                ResizeImage(Properties.Resources.watchit2, areaSize.Width, areaSize.Height),
                ResizeImage(Properties.Resources.watchit3, areaSize.Width, areaSize.Height),
                ResizeImage(Properties.Resources.watchit4, areaSize.Width, areaSize.Height)
            };

            return motherShipImages;
        } // end method GetMotherShipImages
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Invaders
{
    class Explosion
    {
        private List<Star> explosionParticles;
        private DateTime explosionStartTime;
        private int drawExplodeDistance = 20; // max amount any explosion star can move when a frame is rendered.
        Random random;
        private Size explosionSize = new Size(40, 40);
        public bool Exploding{ get; set;}


        /// <summary>
        /// Gets the current Point where the object is located.
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// Gets a rectangle dependent on current explosion location.
        /// </summary>
        public Rectangle Area
        {
            get { return new Rectangle(Location, explosionSize); }
        } // end property Area

        /// <summary>
        /// Instantiates an instance of the Explosion class from a starting location and a Random object.
        /// </summary>
        /// <param name="boundaries">A rectangle representing the gaming area</param>
        /// <param name="random">An instance of the Random class for use in functions needing a random.</param>
        public Explosion(Point location, Random random)
        {
            this.Location = location;
            this.random = random;
            explosionParticles = new List<Star>();
            AddParticles(300);
            this.explosionStartTime = DateTime.Now;
            Exploding = true;
        } // end constructor method Explosion

        /// <summary>
        /// This method draws all the dots in the explosion fanning out, until one second has passed.
        /// </summary>
        /// <param name="g">The graphics objec to draw onto.</param>
        public void Draw(Graphics g)
        {
			if(Exploding){
                DateTime explosionCurrentTime = DateTime.Now;
			TimeSpan duration = explosionCurrentTime - explosionStartTime;
			if (duration.Seconds < 1)
			{
				for (int i = explosionParticles.Count-1; i >= 0; i--){
                    Point movedPoint = new Point(explosionParticles[i].point.X,
                        explosionParticles[i].point.Y);
                    movedPoint.X += (random.Next(2) == 0 ? random.Next(drawExplodeDistance) * -1 : random.Next(drawExplodeDistance));
                    movedPoint.Y += (random.Next(2) == 0 ? random.Next(drawExplodeDistance) * -1 : random.Next(drawExplodeDistance));
                    Star movedStar = new Star(movedPoint, explosionParticles[i].pen);
                    explosionParticles[i] = movedStar;
                    g.DrawEllipse(explosionParticles[i].pen, explosionParticles[i].point.X, explosionParticles[i].point.Y, 1, 1);
                } // end for 
                
			} // end if 
            else Exploding = false;

			} // end if 
        } // end method Draw

        /// <summary>
        /// This method adds a certain number of explosion particles to the explosion star list. 
        /// Every particle has a random location within the explosion area's boundaries
        /// and a random color.
        /// </summary>
        /// <param name="numberOfParticlesToAdd">How many particles to add.</param>
        private void AddParticles(int numberOfParticlesToAdd)
        {
            /*I want to restrict star creation*/
            for (int i = 0; i < numberOfParticlesToAdd; i++)
            {
                Point randomPointWithinBoundaries = new Point(random.Next(Area.Left, Area.Right),
                    random.Next(Area.Top, Area.Bottom));
                Star newStar = new Star(randomPointWithinBoundaries, RandomColorPen(random));
                explosionParticles.Add(newStar);
            } // end for 
        } // end method AddParticles

        /// <summary>
        /// Returns a pen of a random shade of Red.
        /// </summary>
        /// <param name="random">The Random object needed</param>
        /// <returns>A pen object with random color</returns>
        private Pen RandomColorPen(Random random)
        {
            Pen penToReturn = new Pen(Brushes.White);

            int colorSelectNumber = random.Next(10);

            switch (colorSelectNumber)
            {
                case 0:
                    penToReturn.Brush = Brushes.LightGoldenrodYellow;
                    break;
                case 1:
                    penToReturn.Brush = Brushes.Yellow;
                    break;
                case 2:
                case 3:
                    penToReturn.Brush = Brushes.Red;
                    break;
                case 4:
                case 5:
                case 6:
                    penToReturn.Brush = Brushes.Orange;
                    break;
                default:
                    penToReturn.Brush = Brushes.White;
                    break;
            } // end switch 
            return penToReturn;
        }// end method RandomPen
    }

}

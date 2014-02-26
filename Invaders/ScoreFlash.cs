using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Invaders
{
    class ScoreFlash : AreaUser
    {

        private DateTime scoreFlashStartTime;
        public bool Flashing{ get; set;}
        private int scoreToDisplay;

        /// <summary>
        /// Instantiates an instance of the Explosion class from a starting location and a Random object.
        /// </summary>
        /// <param name="boundaries">A rectangle representing the gaming area</param>
        /// <param name="random">An instance of the Random class for use in functions needing a random.</param>
        public ScoreFlash(Point location, int score) : base(location, 40,40)
        {
            this.Location = location;
            this.scoreFlashStartTime = DateTime.Now;
            Flashing = true;
            this.scoreToDisplay = score;
        } // end constructor method Explosion

        /// <summary>
        /// This method draws all the dots in the explosion fanning out, until one second has passed.
        /// </summary>
        /// <param name="g">The graphics objec to draw onto.</param>
        public void Draw(Graphics g)
        {
			if(Flashing){
                DateTime scoreFlashCurrentTime = DateTime.Now;
                TimeSpan duration = scoreFlashCurrentTime - scoreFlashStartTime;
			    if (duration.Seconds < 1)
			    {
                    Location = new Point(Location.X, Location.Y - 5);
                    string scoreString = scoreToDisplay.ToString();
                    Font scoreFont = new Font("Arial", 12, FontStyle.Bold);
                    g.DrawString(scoreString, scoreFont, Brushes.White, Location);                
			    } // end if 
                else Flashing = false;
			} // end if 
        } // end method Draw

       
       
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace Invaders
{
    class Shield
    {
        private List<ShieldBlock> shieldBlocks;
        
        /// <summary>
        /// Instantiates a new Shield instance at the specified location.
        /// </summary>
        /// <param name="location">The point where the Shield will be created.</param>
        public Shield(Point location) {
            ConstructShield(location);
        } // end method Shield

        /// <summary>
        /// This method constructs a 4-block shield at the specified location.
        /// </summary>
        /// <param name="location">The location where the shield will be built.</param>
        public void ConstructShield(Point location){
            shieldBlocks = new List<ShieldBlock>();
            ShieldBlock shieldBlock1 = new ShieldBlock(location);
            ShieldBlock shieldBlock2 = new ShieldBlock(shieldBlock1.NewBlockRight);
            ShieldBlock shieldBlock3 = new ShieldBlock(shieldBlock2.NewBlockBottom);
            ShieldBlock shieldBlock4 = new ShieldBlock(shieldBlock3.NewBlockLeft);
            shieldBlocks.Add(shieldBlock1);
            shieldBlocks.Add(shieldBlock2);
            shieldBlocks.Add(shieldBlock3);
            shieldBlocks.Add(shieldBlock4);
        } // end method ConstructShield

        /// <summary>
        /// This method draws a shield onto a graphics object (and therefore the screen).
        /// </summary>
        /// <param name="g">The Graphics object to draw onto.</param>
        public void Draw(Graphics g) {
            foreach (ShieldBlock shieldBlock in shieldBlocks)
                shieldBlock.Draw(g);
        } // end method Draw

        /// <summary>
        /// This method checks to see if any of the shield blocks has the location of an attack object (e.g a shot)
        /// within them. If so, the block is removed from the shield.
        /// </summary>
        /// <param name="incomingAttackPoint">The point of the attack object.</param>
        /// <returns>A boolean indicating whether it was hit and a shield block was removed.</returns>
        public bool WasHit(Point incomingAttackPoint) {
            for (int i = shieldBlocks.Count - 1; i >= 0; i--)
            {
                if (shieldBlocks[i].Area.Contains(incomingAttackPoint)) {
                    shieldBlocks.Remove(shieldBlocks[i]);
                    return true;
                } // end if 
            } // end for 
            return false;
        } // end method WasHit

        /// <summary>
        /// This method checks to see if any of the shield blocks has the location of an attack object (e.g a shot)
        /// within them. If so, the block is removed from the shield.
        /// </summary>
        /// <param name="incomingAttackPoint">The point of the attack object.</param>
        /// <returns>A boolean indicating whether it was hit and a shield block was removed.</returns>
        public bool WasHit(List<Point> incomingAttackPoints)
        {
            foreach (Point point in incomingAttackPoints) {
                if (WasHit(point)) return true;
            } // end foreach 
            return false;
        } // end method WasHit
    }
}

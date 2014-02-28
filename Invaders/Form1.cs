/*
 * Created by Daniel Hopkins, based on the Invaders Lab
 * in Head First C# (2nd Edition).
 * E-Mail: dahopkin2@gmail.com
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Invaders
{
    public partial class Form1 : Form
    {
   
        int animationCounter;
        bool reverseInvaderAnimation;
        bool gameOver;
        bool paused;
        Game game;
        Random random = new Random();
        List<Keys> keysPressed = new List<Keys>();
        public Form1()
        {
            InitializeComponent();
            StartNewGame();
        } // end constructor method Form1

        /*This method responds resets all the game's relevant variables in order to 
         start a new game.*/
        void StartNewGame() {
            game = new Game(this.ClientRectangle, random);
            game.GameOver += new EventHandler(game_GameOver);
            gameOver = false;
            paused = false;
            reverseInvaderAnimation = false;
            animationCounter = 0;
            animationTimer.Enabled = true;
            gameTimer.Enabled = true;
        } // end method StartNewGame

        /*This method responds to the game's GameOver event.*/
        void game_GameOver(object sender, EventArgs e)
        {
            gameTimer.Stop();
            gameOver = true;
            Invalidate();
        } // end method game_GameOver

        /*This method animates everything. Animation keeps going even if gameplay stops.*/
        private void animationTimer_Tick(object sender, EventArgs e)
        {
            if (animationCounter == 3) reverseInvaderAnimation = true;
            else if (animationCounter == 0) reverseInvaderAnimation = false;

            if (reverseInvaderAnimation) animationCounter--;
            else animationCounter++;

            game.Twinkle();

            Refresh();

        } // end method animationTimer_Tick

        /*If the user types Q at any point, the game quits.
         If game is over and the user types S, the game restarts.
         If the user types space, a shot fires.
         If the user has a bomb and tpes B, a bomb fires.
         */
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Q)
                Application.Exit();

            if (gameOver)
            {
                if (e.KeyCode == Keys.S)
                {
                    StartNewGame();
                    return;
                } // end if 
            } // end if 

            if (e.KeyCode == Keys.Space)
               game.FirePlayerShot();

            if (e.KeyCode == Keys.B)
                game.FirePlayerBomb();

            if (e.KeyCode == Keys.P) {
                if (!paused) {
                    gameTimer.Enabled = false;
                    animationTimer.Enabled = false;
                    paused = true;
                }
                else{
                    gameTimer.Enabled = true;
                    animationTimer.Enabled = true;
                    paused = false;
                }

            }

            if (keysPressed.Contains(e.KeyCode))
                keysPressed.Remove(e.KeyCode);

            keysPressed.Add(e.KeyCode);
        } // end method Form1_KeyDown

        /*This method removes keys not being pressed anymore from the
         * keyspressed list.*/
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (keysPressed.Contains(e.KeyCode))
                keysPressed.Remove(e.KeyCode);
        } // end method Form1_KeyUp

        /*This method processes keystrokes into game actions.
         the left/right keys move the player left/right, and 
         space shoots a shot.*/
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            game.Go();

            foreach (Keys key in keysPressed) { 
                if(key == Keys.Left){
                    game.MovePlayer(Direction.Left);
                    return;
                } // end if

                else if (key == Keys.Right)
                {
                    game.MovePlayer(Direction.Right);
                    return;
                } // end else if
            } // end foreach
        } // end method gameTimer_Tick

        /*This method draws everything on the screen through the game's 
         draw method, and if the game's over, display the game
         over screen.*/
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            game.Draw(g, animationCounter);

            if (gameOver) {
                DrawGameOver(g);
            } // end if 
        } // end method Form1_Paint
        
        /*This method draws the game over graphics onto the screen.*/
        private void DrawGameOver(Graphics g)
        {
            string playAgain = "Press S to start a new game or Q to quit";

            Font playAgainFont = new Font("Arial", 12);
            Font gameOverTopFont = new Font("Arial", 30, FontStyle.Bold);

            Point gameOverPoint = new Point((ClientRectangle.Width / 3), (ClientRectangle.Height / 2));
            Point playAgainPoint = new Point(ClientRectangle.Width / 2, (int)((double)(ClientRectangle.Height * .9)));
            g.DrawString("GAME OVER!", gameOverTopFont, Brushes.Yellow, gameOverPoint);
            g.DrawString(playAgain, playAgainFont, Brushes.Yellow, playAgainPoint);
        } // end method DrawGameOver

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

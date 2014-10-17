using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Media;


namespace FallingFalcon
{
    class Player
    {
        // Animation representing the player
        public Animation PlayerAnimation;

        // Position of the Player relative to the upper left side of the screen
        public Vector2 Position;
        // State of the player
        public bool Active;
        // Amount of hit points that player has
        public int Health;
        // Player's move speed. Set in initialize of hit points that player has
        private float playerMoveSpeed;
        // Player's "gravity constant"... the number of pixels the player's height decreases per second.
        private float gravityConstant;
        // Amount of hit points that player has
        private GameWindow viewWindow;
        // Used for a conversion later
        private const float MILLI_SECS_PER_SEC = 1000.0f;
        // Flag used to determine if the space key is already being held down by the user.
        private bool alreadyDown = false;
        // Get the width of the player ship
        public int Width
        {
            get { return PlayerAnimation.FrameWidth; }
        }

        // Get the height of the player ship
        public int Height
        {
            get { return PlayerAnimation.FrameHeight; }
        }


        // Initialize the player
        public void Initialize(GameWindow gameWindow, Animation animation, Vector2 position)
        {
            viewWindow = gameWindow;

            PlayerAnimation = animation;

            // Set the starting position of the player around the middle of the screen and to the back
            Position = position;

            // Set the player to be active
            Active = true;

            // Set the player health
            Health = 100;

            // Set a constant player move speed
            playerMoveSpeed = 10.0f;
            // Gravity constant for the player
            gravityConstant = -10.0f;
        }


        // Draw the player
        public void Draw(SpriteBatch spriteBatch)
        {
            PlayerAnimation.Draw(spriteBatch);
        }

        // Update the player animation
        public void Update(GameTime gameTime, KeyboardState kbState)
        {
            // div by zero check
            if (gameTime.ElapsedGameTime.Milliseconds > 0)
            {
                float dbugConv = (1.0f/(MILLI_SECS_PER_SEC/(float)gameTime.ElapsedGameTime.Milliseconds));
                float heightDecrease = gravityConstant*dbugConv;
                Position.Y -= heightDecrease;
            }

            PlayerAnimation.Position = Position;
            PlayerAnimation.Update(gameTime);

            // Use the Keyboard / Dpad
            if (kbState.IsKeyDown(Keys.Left))
            {
                Position.X -= playerMoveSpeed;
            }
            if (kbState.IsKeyDown(Keys.Right))
            {
                Position.X += playerMoveSpeed;
            }
            if (kbState.IsKeyUp(Keys.Space))
            {
                alreadyDown = false;
            }
            else if (kbState.IsKeyDown(Keys.Space) && !alreadyDown)
            {
                Position.Y -= playerMoveSpeed;
                alreadyDown = true;
            }

            // Make sure that the player does not go out of bounds
            if (Position.X < 0)
                Position.X = 0;
            if (Position.Y < 0)
                Position.Y = 0;
            if (Position.X > viewWindow.ClientBounds.Width - Width)
                Position.X = viewWindow.ClientBounds.Width - Width;
        }



    }
}

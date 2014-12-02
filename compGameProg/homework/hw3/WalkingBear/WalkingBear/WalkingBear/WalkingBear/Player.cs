using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Media;


namespace WalkingBear
{
    class Player
    {
        // Animation representing the player
        public Animation PlayerAnimation;

        // Position of the Player relative to the upper left side of the screen
        public Vector2 Position;
        // Inital Position of the Player
        public Vector2 InitialPosition;
        // State of the player
        public bool Active;
        // Amount of hit points that player has
        public int Health;

        // Amount of hit points that player has
        private GameWindow viewWindow;
        // Used for a conversion later
        private const float MILLI_SECS_PER_SEC = 1000.0f;
        // Flag used to determine if the space key is already being held down by the user.
        private bool alreadyDown = false;
        // Flag indicating if the player is jumping
        public bool isJumping = false;
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
            InitialPosition = position;
            Position = InitialPosition;

            // Set the player to be active
            Active = true;

            // Set the player health
            Health = 100;

        }


        // Draw the player
        public void Draw(SpriteBatch spriteBatch)
        {
            PlayerAnimation.Draw(spriteBatch);
        }

        // Update the player animation
        public void Update(GameTime gameTime, KeyboardState kbState)
        {
            PlayerAnimation.Position = Position;
            PlayerAnimation.Update(gameTime);

            // Use the Keyboard
            if (kbState.IsKeyUp(Keys.Space))
            {
                alreadyDown = false;
            }
            else if (kbState.IsKeyDown(Keys.Space) && !alreadyDown && !isJumping)
            {
                alreadyDown = true;
                isJumping = true;
            }

            performJump(gameTime);

        }

        // Player's "gravity constant"... 
        private float gravityConstant = 9.8f;
        // Player's "jump velocity constant"... the amount of instantaneous y-velocity a jump applies
        private float jumpVel = -30;
        // simulates slowing down time...the effect gives longer hang time for the bear
        // while still following  a realistic-ish jump trajectory.
        private float hangTimeDelayTerm = 0.40f;

        // time in air
        private float jumpTime = 0.0f;

        private void performJump(GameTime gameTime)
        {
            // div by zero check
            if (gameTime.ElapsedGameTime.Milliseconds > 0 && isJumping)
            {
                // Elapsed time in seconds
                float delta_t = (1.0f / (MILLI_SECS_PER_SEC / (float)gameTime.ElapsedGameTime.Milliseconds));
                jumpTime += delta_t*hangTimeDelayTerm;
                float jumpAccelTerm = (float)Math.Pow(gravityConstant*jumpTime,2);
                float tmpJumpVel = jumpVel * jumpTime;
                Position.Y += tmpJumpVel + jumpAccelTerm;
            }

            if (Position.Y > InitialPosition.Y )
            {
                Position.Y = InitialPosition.Y;
                isJumping = false;
                jumpTime = 0.0f;
            }

        }



    }
}

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
    class BearTrap
    {
        // Animation representing the player
        public Animation bearTrapAnimation;

        // Position of the bear trap relative to the upper left side of the screen
        public Vector2 Position;
        // Inital Position of the bear trap
        public Vector2 InitialPosition;
        // State of the bear trap
        public bool Active;
        // bear trap's move speed. Set in initialize of hit points that player has
        private float bearTrapMoveSpeed;
        // Amount of hit points that player has
        private GameWindow viewWindow;

        private bool trapCleared = false;

        // Get the width of the player ship
        public int Width
        {
            get { return bearTrapAnimation.FrameWidth; }
        }

        // Get the height of the player ship
        public int Height
        {
            get { return bearTrapAnimation.FrameHeight; }
        }

        // True if this trap was avoided by player (reaches end of screen)
        public bool TrapCleared
        {
            get { return trapCleared; }
            set { this.trapCleared = value; }
        }


        // Initialize the player
        public void Initialize(GameWindow gameWindow, Animation animation, Vector2 position)
        {
            viewWindow = gameWindow;

            bearTrapAnimation = animation;

            // Set the starting position of the bear trap 
            InitialPosition = position;
            Position = InitialPosition;

            // Set the bear trap to be active
            Active = true;

            // Set the bear trap move speed
            bearTrapMoveSpeed = 2.5f;
        }


        // Draw the bear trap
        public void Draw(SpriteBatch spriteBatch)
        {
            if(Active)
            {
                bearTrapAnimation.Draw(spriteBatch);
            }
        }

        // Update the bear trap animation
        public void Update(GameTime gameTime)
        {
            bearTrapAnimation.Position = Position;
            Position.X -= bearTrapMoveSpeed;
            bearTrapAnimation.Update(gameTime);
            if(Position.X < 0)
            {
                Active = false;
                Position.X = InitialPosition.X;
                trapCleared = true;
            }
        }

    }
}

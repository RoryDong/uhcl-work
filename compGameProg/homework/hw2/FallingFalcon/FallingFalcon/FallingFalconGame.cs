using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FallingFalcon
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class FallingFalconGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Represents the player 
        Player player;
        // Player states
        enum PlayerStatus { ALIVE, DEAD };
        PlayerStatus playerStatus = PlayerStatus.ALIVE;

        // Keyboard states used to determine key presses
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;
        // A movement speed for the player
        float playerMoveSpeed;

        // The height offset constant (below screen) where the player dies... in px
        const int playerDeathHeightOffset = 20;

        // Parallaxing Layers
        ParallaxingBackground bgLayer1;

        // Status overlays
        private Texture2D playerDeathOverlay;

        public FallingFalconGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Initialize the player class
            player = new Player();

            bgLayer1 = new ParallaxingBackground();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load the player resources
            Animation playerAnimation = new Animation();
            Texture2D playerTexture = Content.Load<Texture2D>("sprites/birdanimation");
            playerAnimation.Initialize(playerTexture, Vector2.Zero, 150, 150, 9, 3, 3, 16, Color.White, 2f, true);

            playerDeathOverlay = Content.Load<Texture2D>("overlays/you_died");

            Vector2 playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y);
            player.Initialize(Window, playerAnimation, playerPosition);

            // Load the parallaxing background
            bgLayer1.Initialize(Content, "backgrounds/background", GraphicsDevice.Viewport.Width, -1);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Collects the game inputs.
        /// </summary>
        protected void collectGameInputs()
        {
            // Save the previous state of the keyboard and game pad to determine single key presses
            previousKeyboardState = currentKeyboardState;
            // Read the current state of the keyboard and gamepad and store it
            currentKeyboardState = Keyboard.GetState();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().GetPressedKeys().Contains(Keys.Back))
                this.Exit();

            // collect the game inputs
            collectGameInputs();

            //Update the player
            if (playerStatus == PlayerStatus.ALIVE)
            {
                player.Update(gameTime, currentKeyboardState);
            }

            // Update the parallaxing background
            bgLayer1.Update();

            // Check for player death
            if (player.Position.Y > Window.ClientBounds.Height+playerDeathHeightOffset)
            {
                playerStatus = PlayerStatus.DEAD;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Rectangle titleSafeArea = GraphicsDevice.Viewport.TitleSafeArea;
            Vector2 center = new Vector2(titleSafeArea.X + titleSafeArea.Width / 2.0f,
                             titleSafeArea.Y + titleSafeArea.Height / 2.0f);

            // Start drawing
            spriteBatch.Begin();

            // Draw the moving background
            bgLayer1.Draw(spriteBatch);

            // Draw the Player
            player.Draw(spriteBatch);

            if (playerStatus == PlayerStatus.DEAD)
            {
                // Draw status message.
                Vector2 deathOverlaySize = new Vector2(playerDeathOverlay.Width, playerDeathOverlay.Height);
                spriteBatch.Draw(playerDeathOverlay, center - deathOverlaySize / 2, Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

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

namespace WalkingBear
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class WalkingBearGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Represents the player 
        Player player;
        // Max possible traps on the screen at once.
        int MAX_TRAPS = 5;
        // Array of bear traps.
        BearTrap[] bearTraps;
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
        ParallaxingBackground bgLayer2;
        ParallaxingBackground bgLayer3;
        ParallaxingBackground bgLayer4;

        // player's score
        private int score = 0;
        // The font used to display UI elements
        SpriteFont font;

        private bool collisionOccured = false;
        private bool inCollision = false;

        public WalkingBearGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 640;
            graphics.PreferredBackBufferWidth = 640;
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
            bgLayer2 = new ParallaxingBackground();
            bgLayer3 = new ParallaxingBackground();
            bgLayer4 = new ParallaxingBackground();

            bearTraps = new BearTrap[MAX_TRAPS];
            for(int bearTrapIndex = 0; bearTrapIndex<MAX_TRAPS; bearTrapIndex++)
            {
                bearTraps[bearTrapIndex] = new BearTrap();
            }

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
            Texture2D playerTexture = Content.Load<Texture2D>("Images/BearWalk");
            playerAnimation.Initialize(playerTexture, Vector2.Zero, 152, 95, 8, 48, Color.White, 1f, true);

            Vector2 playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + playerTexture.Width / 6, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.Height - playerTexture.Height*0.75f);
            player.Initialize(Window, playerAnimation, playerPosition);

            // initialize all bear traps
            for(int bearTrapIndex = 0; bearTrapIndex<MAX_TRAPS; bearTrapIndex++)
            {
                Animation bearTrapAnimation = new Animation();
                Texture2D bearTrapTexture = Content.Load<Texture2D>("Images/BearTrap");
                bearTrapAnimation.Initialize(bearTrapTexture, Vector2.Zero, 104, 74, 1, 48, Color.White, 0.5f, true);
                Vector2 bearTrapPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.Height - bearTrapTexture.Height*0.35f);
                bearTraps[bearTrapIndex] = new BearTrap();
                bearTraps[bearTrapIndex].Initialize(Window, bearTrapAnimation, bearTrapPosition);
                bearTraps[bearTrapIndex].Active = false;
                bearTraps[bearTrapIndex].TrapCleared = false;
            }

            // Load the parallaxing background
            bgLayer1.Initialize(Content, "Images/Sky", GraphicsDevice.Viewport.Width, -1, 1.0f);
            bgLayer2.Initialize(Content, "Images/Mountain", GraphicsDevice.Viewport.Width, -2, 0.02f);
            bgLayer3.Initialize(Content, "Images/Ground", GraphicsDevice.Viewport.Width, -3, 0.15f);
            bgLayer4.Initialize(Content, "Images/Trees", GraphicsDevice.Viewport.Width, -4, 0.1f);

            // Load the score font
            font = Content.Load<SpriteFont>("ScoreFont");
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


        private float timeSinceLastDiceRoll = 0.0f;
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Roll the dice every 1.5 seconds to decide if we should create a new trap
            float delta_t = (1.0f / (1000.0f / (float)gameTime.ElapsedGameTime.Milliseconds));
            timeSinceLastDiceRoll += delta_t;
            if (timeSinceLastDiceRoll>0.5)
            {
                // Used for generating a bear trap
                Random rnd = new Random();
                int newTrapNumber = rnd.Next(1, 10); // creates a number between 1 and 100
                // lucky numbers 2 means a new trap gets created.
                if (newTrapNumber == 2)
                    createNewBearTrap();
                timeSinceLastDiceRoll = 0.0f;
            }


            // Allows the game to exit
            if (Keyboard.GetState().GetPressedKeys().Contains(Keys.Back))
                this.Exit();

            // collect the game inputs
            collectGameInputs();

            // Update the parallaxing background
            bgLayer1.Update();
            bgLayer2.Update();
            bgLayer3.Update();
            bgLayer4.Update();

            //Update the player
            player.Update(gameTime, currentKeyboardState);

            // Update the bear traps
            for (int bearTrapIndex = 0; bearTrapIndex < MAX_TRAPS; bearTrapIndex++)
            {
                if (bearTraps[bearTrapIndex].Active)
                {
                    bearTraps[bearTrapIndex].Update(gameTime);
                }
            }

            // Check collisions
            UpdateCollisions();
            // Update score
            UpdateScore();
            // End game on collision with trap
            if(collisionOccured)

            {
                Exit();
            }

            base.Update(gameTime);
        }

        private void UpdateCollisions()
        {
            collisionOccured = false;
            int bearCollisionBoundaryWidth = (int)((float)player.Width * 0.48f);
            int bearCollisionBoundaryHeight = (int)((float)player.Height * 0.65f);
            Rectangle  playerRect = new Rectangle((int)player.Position.X, (int)player.Position.Y,
                                         bearCollisionBoundaryWidth, bearCollisionBoundaryHeight);

            for (int bearTrapIndex = 0; bearTrapIndex < MAX_TRAPS; bearTrapIndex++)
            {

                int trapCollisionBoundaryWidth = (int)((float)bearTraps[bearTrapIndex].Width * 0.75f);
                int trapCollisionBoundaryHeight = (int)((float)bearTraps[bearTrapIndex].Height * 0.95f);
                Rectangle trapRect = new Rectangle((int)bearTraps[bearTrapIndex].Position.X, (int)bearTraps[bearTrapIndex].Position.Y,
                                        trapCollisionBoundaryWidth, trapCollisionBoundaryHeight);


                if (playerRect.Intersects(trapRect) && !inCollision && !player.isJumping)
                {
                    collisionOccured = true;
                    inCollision = true;
                }

                if(inCollision && !playerRect.Intersects(trapRect))
                {
                    inCollision = false;
                }
            }
        }

        private void UpdateScore()
        {
            for (int bearTrapIndex = 0; bearTrapIndex < MAX_TRAPS; bearTrapIndex++)
            {
                if (bearTraps[bearTrapIndex].TrapCleared)
                {
                    score += 100;
                    bearTraps[bearTrapIndex].TrapCleared = false;
                }
            }
        }


        protected void createNewBearTrap()
        {
            for (int bearTrapIndex = 0; bearTrapIndex < MAX_TRAPS; bearTrapIndex++)
            {
                if (!bearTraps[bearTrapIndex].Active)
                {
                    bearTraps[bearTrapIndex].Active = true;
                    return;
                }
            }
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
            bgLayer2.Draw(spriteBatch);
            bgLayer3.Draw(spriteBatch);
            bgLayer4.Draw(spriteBatch);

            // Draw the Player
            player.Draw(spriteBatch);
            // Draw the bear traps
            for (int bearTrapIndex = 0; bearTrapIndex < MAX_TRAPS; bearTrapIndex++)
            {
                bearTraps[bearTrapIndex].Draw(spriteBatch);
            }

            // Draw the score
            spriteBatch.DrawString(font, "score: " + score, new Vector2(10, 10), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

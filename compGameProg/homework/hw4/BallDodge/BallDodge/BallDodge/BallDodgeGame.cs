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
using Box2D.XNA;

namespace BallDodge
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class BallDodgeGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Ball sprite
        Texture2D ball;

        // Represents the player 
        Player player;
        // A movement speed for the player
        float playerMoveSpeed;

        // Keyboard states used to determine key presses
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        //Game physics world object
        World physicsWorld;
        //Ball body (in Box2D)
        Body ballBody;

        // The font used to display UI elements
        SpriteFont font;


        public BallDodgeGame()
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
            // Set a constant player move speed
            playerMoveSpeed = 8.0f;

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

            //Load the ball sprite
            ball = Content.Load<Texture2D>("sprites/ball");

            //Create the physics world object
            physicsWorld = new World(new Vector2(0, 100), true);

            //Create and add ground object
            AddGround();

            //Create and add ball bosy
            AddBallBody(new Vector2(100, 100), ball);

            // Load the player resources
            Animation playerAnimation = new Animation();
            Texture2D playerTexture = Content.Load<Texture2D>("sprites/shipAnimation");
            playerAnimation.Initialize(playerTexture, Vector2.Zero, 115, 69, 8, 30, Color.White, 1f, true);

            Vector2 playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y
            + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
            player.Initialize(playerAnimation, playerPosition);

            // Load the score font
            font = Content.Load<SpriteFont>("fonts/ScoreFont");

        }

        private void AddBallBody(Vector2 position, Texture2D ballSprite)
        {
            //Ball body definition
            BodyDef bd = new BodyDef();
            bd.type = BodyType.Dynamic;
            bd.position = position;

            //Add circle shaped fixture to ball body
            var circle = new CircleShape();
            circle._radius = 26;
            var fd = new FixtureDef();
            fd.shape = circle;
            fd.restitution = 1.0f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            ballBody = physicsWorld.CreateBody(bd);
            ballBody.CreateFixture(fd);

            //Attach ball sprite reference to ball body
            ballBody.SetUserData(ballSprite);
            ballBody.SetLinearVelocity(new Vector2(50000000.0f, 100000000.0f));
        }

        private void AddGround()
        {
            //Window dimensions
            int windowWidth = Window.ClientBounds.Width;
            int windowHeight = Window.ClientBounds.Height;

            //Ground body definition
            BodyDef bd = new BodyDef();
            Body ground = physicsWorld.CreateBody(bd);

            //Add line fixture to ground body
            PolygonShape bottomBounds = new PolygonShape();
            bottomBounds.SetAsEdge(new Vector2(0.0f, windowHeight-25), new Vector2(windowWidth, windowHeight-25));
            PolygonShape topBounds = new PolygonShape();
            topBounds.SetAsEdge(new Vector2(0.0f, 0.0f), new Vector2(windowWidth, 0.0f));
            PolygonShape leftBounds = new PolygonShape();
            leftBounds.SetAsEdge(new Vector2(25.0f, 0.0f), new Vector2(25.0f, windowHeight));
            PolygonShape rightBounds = new PolygonShape();
            rightBounds.SetAsEdge(new Vector2(windowWidth-25, 0.0f), new Vector2(windowWidth-25, windowHeight));

            ground.CreateFixture(bottomBounds, 10.0f);
            ground.CreateFixture(topBounds, 10.0f);
            ground.CreateFixture(leftBounds, 10.0f);
            ground.CreateFixture(rightBounds, 10.0f);

        }



        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();



            // Save the previous state of the keyboard 
            previousKeyboardState = currentKeyboardState;
            // Read the current state of the keyboard and store it
            currentKeyboardState = Keyboard.GetState();

            //Update the player
            UpdatePlayer(gameTime);

            UpdateBallVelocity(gameTime);

            UpdateCollisions();


            //Update the bodies in physics world
            physicsWorld.Step((float)gameTime.ElapsedGameTime.TotalSeconds, 10, 3);

            base.Update(gameTime);
        }


        private void UpdatePlayer(GameTime gameTime)
        {
            player.Update(gameTime);

            // Use the Keyboard / Dpad
            if (currentKeyboardState.IsKeyDown(Keys.Left))
            {
                player.Position.X -= playerMoveSpeed;
            }
            if (currentKeyboardState.IsKeyDown(Keys.Right))
            {
                player.Position.X += playerMoveSpeed;
            }
            if (currentKeyboardState.IsKeyDown(Keys.Up))
            {
                player.Position.Y -= playerMoveSpeed;
            }
            if (currentKeyboardState.IsKeyDown(Keys.Down))
            {
                player.Position.Y += playerMoveSpeed;
            }
            // Make sure that the player does not go out of bounds
            if (player.Position.X < 0)
                player.Position.X = 0;
            if (player.Position.Y < 0)
                player.Position.Y = 0;
            if (player.Position.X > Window.ClientBounds.Width - player.Width)
                player.Position.X = Window.ClientBounds.Width - player.Width;
            if (player.Position.Y > Window.ClientBounds.Height - player.Height)
                player.Position.Y = Window.ClientBounds.Height - player.Height;
        }



        private void UpdateBallVelocity(GameTime gameTime)
        {
            Vector2 currentLinearVelocity = ballBody.GetLinearVelocity();
            ballBody.SetLinearVelocity(currentLinearVelocity*2.0f);
        }


        private void UpdateCollisions()
        {
            Rectangle playerRect = new Rectangle((int)player.Position.X, (int)player.Position.Y,
                                        player.Width/2, player.Height);

            Rectangle ballRect = new Rectangle((int)ballBody.Position.X, (int)ballBody.Position.Y,
                                        20, 52);
            if (playerRect.Intersects(ballRect))
            {
                Exit();
            }

        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);

            spriteBatch.Begin();

            // Draw the Player
            player.Draw(spriteBatch);

            //Go through all the bodies added to the world
            for (var b = physicsWorld.GetBodyList(); b != null; b = b.GetNext())
            {
                //Update the position of ball sprite according to ball body
                var userData = b.GetUserData();
                if (userData == ball)
                {
                    spriteBatch.Draw(ball, b.Position, Color.White);
                }
            }

            // Draw the score
            spriteBatch.DrawString(font, "Time: " + gameTime.TotalGameTime.Minutes + ":" + gameTime.TotalGameTime.Seconds % 60, new Vector2(10, 10), Color.White);

            spriteBatch.End();

        }
    }
}

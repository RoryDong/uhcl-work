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
        // Keyboard states used to determine key presses
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        //Game physics world object
        World physicsWorld;
        //Ball body (in Box2D)
        Body ballBody;


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
            fd.restitution = 0.8f;
            fd.friction = 0.1f;
            fd.density = 1.0f;
            ballBody = physicsWorld.CreateBody(bd);
            ballBody.CreateFixture(fd);

            //Attach ball sprite reference to ball body
            ballBody.SetUserData(ballSprite);
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
            PolygonShape shape = new PolygonShape();
            shape.SetAsEdge(new Vector2(0.0f, windowHeight), new Vector2(windowWidth, windowHeight));
            ground.CreateFixture(shape, 0.0f);
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

            base.Update(gameTime);

            // Save the previous state of the keyboard 
            previousKeyboardState = currentKeyboardState;
            // Read the current state of the keyboard and store it
            currentKeyboardState = Keyboard.GetState();
            if ((previousKeyboardState.IsKeyDown(Keys.Enter)) && (currentKeyboardState.IsKeyUp(Keys.Enter)))
            {
                //Apply linear velocity on ball body
                Vector2 velocity = new Vector2(0.0f, -100.0f);
                ballBody.SetLinearVelocity(velocity);
            }
            //Update the bodies in physics world
            physicsWorld.Step((float)gameTime.ElapsedGameTime.TotalSeconds, 10, 3);

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

            spriteBatch.End();

        }
    }
}

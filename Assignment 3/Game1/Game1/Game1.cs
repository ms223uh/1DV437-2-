﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.View;
using Game1.View.Game1.View;
using Game1.Controller;
using Ball.Model;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera camera;
        private GameController gameController;
        ExplosionView explosionView;
        MouseState mouseClick;
        MouseState thisMouse;
        public bool isClicked;
        BallSimulation ballSim;

        private Texture2D aimScope;
        private Vector2 cursorPos;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 600;
            graphics.IsFullScreen = false;
            this.IsMouseVisible = false;
            graphics.ApplyChanges();
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

            camera = new Camera(graphics.GraphicsDevice.Viewport);
            // Create a new SpriteBatch, which can be used to draw textures.
            camera.setfieldsize();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ballSim = new BallSimulation();
            gameController = new GameController(Content, camera, spriteBatch, thisMouse, GraphicsDevice, ballSim);
            //  camera = new Camera(GraphicsDevice.Viewport);
            // explosionView = new ExplosionView(camera, spriteBatch, new Vector2(0.5f,0.5f), Content.Load<Texture2D>("explosion"));
            aimScope = Content.Load<Texture2D>("aim2");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }


            thisMouse = Mouse.GetState();
            if (mouseClick.LeftButton == ButtonState.Released && thisMouse.LeftButton == ButtonState.Pressed)
            {
                Vector2 position = gameController.getLogicalCord(thisMouse.X, thisMouse.Y);
                gameController.CreateExplosion(thisMouse.X, thisMouse.Y, spriteBatch, (float)gameTime.ElapsedGameTime.TotalSeconds);
                ballSim.hitBall(position);
            }
            mouseClick = thisMouse;


            cursorPos = new Vector2(thisMouse.X, thisMouse.Y);


            ballSim.simUpdate((float)gameTime.ElapsedGameTime.TotalSeconds);


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            gameController.Draw((float)gameTime.ElapsedGameTime.TotalMilliseconds);

            //  explosionView.Draw((float)gameTime.ElapsedGameTime.TotalMilliseconds);

            spriteBatch.Begin();
            spriteBatch.Draw(aimScope, cursorPos, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
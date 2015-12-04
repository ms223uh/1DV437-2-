using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.View;
using Game1.View.Game1.View;
using Game1.Controller;

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

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = 500;
            graphics.IsFullScreen = false;
            this.IsMouseVisible = true;
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

            camera = new Camera();
            // Create a new SpriteBatch, which can be used to draw textures.
            camera.setfieldsize(graphics.GraphicsDevice.Viewport);
            spriteBatch = new SpriteBatch(GraphicsDevice);

            gameController = new GameController(Content, camera, spriteBatch, thisMouse);
            //  camera = new Camera(GraphicsDevice.Viewport);
            // explosionView = new ExplosionView(camera, spriteBatch, new Vector2(0.5f,0.5f), Content.Load<Texture2D>("explosion"));


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
                gameController.CreateExplosion(thisMouse.X, thisMouse.Y, spriteBatch, (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            mouseClick = thisMouse;

            // TODO: Add your update logic here

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



            base.Draw(gameTime);
        }
    }
}
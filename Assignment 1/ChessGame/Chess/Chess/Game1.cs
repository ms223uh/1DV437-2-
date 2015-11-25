using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Chess
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class ChessGame: Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D whiteRec;
        Texture2D blackRec;
        Texture2D playerIcon;
        Camera camera;

        public ChessGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 320;
            graphics.PreferredBackBufferWidth = 240;
            graphics.ApplyChanges();
            camera = new Camera(graphics);


        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

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

            whiteRec = new Texture2D(GraphicsDevice, 1, 1);
            whiteRec.SetData(new[] { Color.White });

            blackRec = new Texture2D(GraphicsDevice, 1, 1);
            blackRec.SetData(new[] { Color.Black });

            playerIcon = new Texture2D(GraphicsDevice, 1, 1);
            playerIcon.SetData(new[] { Color.Red });


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
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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

            spriteBatch.Begin();

            int a = 0;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (a % 2 == 0)
                    {
                        spriteBatch.Draw(whiteRec, camera.blackScale(x, y), Color.White );
                    }
                    else
                    {
                        spriteBatch.Draw(blackRec, camera.blackScale(x, y), Color.White);
                    }
                    a++;
                }
                a++;
            }
            //spriteBatch.Draw(playerIcon, camera.getCordinations(1, 1), Color.White);
            spriteBatch.Draw(playerIcon, camera.blackScale(2, 2), Color.White);



            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

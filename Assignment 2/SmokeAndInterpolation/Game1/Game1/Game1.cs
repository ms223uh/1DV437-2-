using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.View;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D smokeTexture;
        ParticleSystem particleSystem;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(this.GraphicsDevice);
            smokeTexture = this.Content.Load<Texture2D>("smokePic");
            particleSystem = new ParticleSystem(new Vector2(400, 475)); // // Cordination of smokeSpawn - Position
            particleSystem.addParticle(new Vector2(0.02f, 0.015f), // density
                                        new Vector2(1, -1), new Vector2(0.1f * MathHelper.Pi, 0.25f * -MathHelper.Pi), // rotate
                                        new Vector2(0.5f, 0.75f),
                                        new Vector2(20, 120), new Vector2(225, 575f), // spread
                                        Color.Orange, Color.Black, new Color(Color.Black, 0), new Color(Color.Black, 0),
                                        new Vector2(800, 600), new Vector2(100, 160), 10000, Vector2.Zero, smokeTexture); // particles

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



            // TODO: use this.Content to load your game content here
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

            particleSystem.Update(gameTime.ElapsedGameTime.Milliseconds / 1800f); // speed of smoke

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            particleSystem.Draw(spriteBatch, 1, Vector2.Zero);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
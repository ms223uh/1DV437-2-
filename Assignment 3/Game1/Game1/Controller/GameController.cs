using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Game1.View.Game1.View;
using Game1.View;
using Ball.View;
using Ball.Model;

namespace Game1.Controller
{
    class GameController
    {

        private ContentManager content;
        private Camera camera;
        private SpriteBatch spriteBatch;

        private Texture2D explosionTexture;
        private Texture2D splitterTexture;
        private Texture2D smokeTexture;
        private SplitterView splitterView;
        private SmokeView smokeView;

        private Texture2D ballTexture;
        private BallView ballView;
        private BallSimulation ballSim;
        private GraphicsDevice graphics;

        List<ExplosionView> numberOfExplosions = new List<ExplosionView>();
       

        public static Camera Sprite { get; private set; }

        public GameController(ContentManager cm, Camera cam, SpriteBatch sprite, MouseState mouse, GraphicsDevice graphics, BallSimulation ballSim)
        {
            content = cm;
            camera = cam;
            spriteBatch = sprite;
            this.graphics = graphics;
            this.ballSim = ballSim;

            explosionTexture = content.Load<Texture2D>("explosion");
            splitterTexture = content.Load<Texture2D>("spark");
            smokeTexture = content.Load<Texture2D>("smokePic");
            ballTexture = content.Load<Texture2D>("ball");
            


            splitterView = new SplitterView(spriteBatch,camera, splitterTexture);
            smokeView = new SmokeView(spriteBatch, camera, smokeTexture);
            ballView = new BallView(ballSim, camera, graphics, ballTexture);
           


        }


        public void Draw(float elapsedtime)
        {
            
            ballView.Draw(spriteBatch);
            DrawExplosions(elapsedtime);
            smokeView.Draw(elapsedtime, spriteBatch, camera, smokeTexture);
            splitterView.Draw(elapsedtime, spriteBatch, camera, splitterTexture);
        }

        public void DrawExplosions(float elapsedtime)
        {
            foreach (ExplosionView explosion in numberOfExplosions)
            {
                explosion.Draw(elapsedtime);
            }
        }

        public void CreateExplosion(float xCord, float yCord, SpriteBatch spriteBatch, float elapsedTime)
        {
            Vector2 mouseClick = new Vector2(xCord, yCord);
            Vector2 explosionPosition = camera.getMouseCord(mouseClick);

            if (explosionPosition.X <= 1f && explosionPosition.X >= 0f && explosionPosition.Y <= 1f && explosionPosition.Y >= 0f)
            {
                numberOfExplosions.Add(new ExplosionView(camera, spriteBatch, explosionPosition, explosionTexture));
                splitterView.createParticle(explosionPosition);
                smokeView.createParticle(explosionPosition);

            }

        }

    }
}
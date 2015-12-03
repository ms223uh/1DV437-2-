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

namespace Game1.Controller
{
    class GameController
    {

        private ContentManager content;
        private Camera camera;
        private SpriteBatch spriteBatch;

        private Texture2D explosionTexture;

        List<ExplosionView> numberOfExplosions = new List<ExplosionView>(); 

        public GameController(ContentManager cm, Camera cam, SpriteBatch sprite)
        {
            content = cm;
            camera = cam;
            spriteBatch = sprite;

            explosionTexture = content.Load<Texture2D>("explosion");
        }


        public void Draw(float elapsedtime)
        {
            spriteBatch.Begin();
            DrawExplosions(elapsedtime);
            spriteBatch.End();

        }


        public void DrawExplosions(float elapsedtime)
        {
            foreach (ExplosionView explosion in numberOfExplosions)
            {
                explosion.Draw(elapsedtime);
            }
        }


        public void CreateExplosion(float xCord, float yCord, SpriteBatch spriteBatch)
        {
            Vector2 mouseClick = new Vector2(xCord, yCord);
            Vector2 explosionPosition = camera.getMouseCord(mouseClick);

            if (explosionPosition.X <= 1f && explosionPosition.X >= 0f && explosionPosition.Y <= 1f && explosionPosition.Y >= 0f)
            {
                numberOfExplosions.Add(new ExplosionView(camera, spriteBatch, explosionPosition, explosionTexture));
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.View.Game1.View;

namespace Game1.View
{
    class ExplosionView
    {

        private Camera camera;
        private SpriteBatch spriteBatch;
        private Explosion explosion;

        public ExplosionView(SpriteBatch sprite, Camera cam, Texture2D explosionTexture)
        {
            camera = cam;
            spriteBatch = sprite;
            explosion = new Explosion(explosionTexture);
        }

       

        public void Draw(float elapsedTime)
        {
            spriteBatch.Begin();

            explosion.Draw(spriteBatch, camera, elapsedTime);

            spriteBatch.End();
        }
    }
}

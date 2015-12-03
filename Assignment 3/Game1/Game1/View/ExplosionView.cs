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

        private Vector2 startPosition;
        private float scale = 0.5f;
        private Vector2 explosionPosition;
        private Texture2D explosionTexture;

        public ExplosionView(SpriteBatch sprite, Vector2 startPos, Camera cam, Texture2D explosionTexture)
        {
            camera = cam;
            spriteBatch = sprite;
            startPosition = startPos;

            explosion = new Explosion(explosionTexture, spriteBatch, camera, scale, startPosition);
        }

        public ExplosionView(Camera camera, SpriteBatch spriteBatch, Vector2 explosionPosition, Texture2D explosionTexture)
        {
            this.camera = camera;
            this.spriteBatch = spriteBatch;
            this.explosionPosition = explosionPosition;
            this.explosionTexture = explosionTexture;
        }

        public void Draw(float elapsedTime)
        {
            spriteBatch.Begin();

            explosion.Draw(spriteBatch, camera, elapsedTime);

            spriteBatch.End();
        }
    }
}

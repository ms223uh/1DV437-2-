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
        private float scale = 0.1f;
        private Vector2 explosionPosition;
        private Texture2D _explosionTexture;

        public ExplosionView(Camera camera, SpriteBatch spriteBatch, Vector2 explosionPosition, Texture2D explosionTexture)
        {
            this.camera = camera;
            this.spriteBatch = spriteBatch;
            this.explosionPosition = explosionPosition;
            this._explosionTexture = explosionTexture;
            explosion = new Explosion(_explosionTexture, spriteBatch, camera, explosionPosition);
        }


        public void Draw(float elapsedTime)
        {
            explosion.Draw(spriteBatch, camera, elapsedTime);
        }
    }
}

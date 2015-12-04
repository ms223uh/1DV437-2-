using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game1.View.Game1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1.View
{
    class Particle
    {

        protected int seed;
        protected Vector2 startPosition;
        protected Vector2 position;
        protected Vector2 velocity; // movement for the particles
        protected Vector2 acceleration;
        float radius = 0.001f; // radius/size for the particles

        public virtual void Init(int seed, Vector2 startPosition)
        {
            this.seed = seed;
            this.startPosition = startPosition;
            this.position = new Vector2(startPosition.X, startPosition.Y);
        }

        // update the particles
        internal void Update(float elapsedTime)
        {
            velocity = velocity + acceleration * elapsedTime;
            position = position + velocity * elapsedTime;
        }

        

        // draw
        internal void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D particleTexture)
        {
            //Rectangle sparkRectangleTexture = camera.getRectangle(position.X, position.Y);

            spriteBatch.Draw(particleTexture, camera.getScreenCord(position), null, null, null, 2, Vector2.One * camera.getScale(particleTexture.Width, 0.025f), Color.White,SpriteEffects.None, 0);
        }

    }
}

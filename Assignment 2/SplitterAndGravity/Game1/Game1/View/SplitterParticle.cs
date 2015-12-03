﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1.View
{
    class SplitterParticle
    {

        private int seed;
        private Vector2 startPosition;
        private Vector2 position;
        private Vector2 velocity; // movement for the particles
        private Vector2 acceleration;
        float radius = 0.01f; // radius/size for the particles

        public SplitterParticle(int seed, Vector2 startPosition)
        {
            this.seed = seed;
            this.startPosition = startPosition;
            this.position = new Vector2(startPosition.X, startPosition.Y);
            Random random = new Random(this.seed);

            velocity = new Vector2((float)((random.NextDouble() - 0.5f)), (float)((random.NextDouble() - 0.5f))); // spreed direction
            velocity.Normalize();
            velocity = velocity * ((float)random.NextDouble() * 0.3f); // size between particles
            acceleration = new Vector2(0.0f, 1.0f); // direction for the particles
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
            Rectangle sparkRectangleTexture = camera.getRectangle(position, radius);

            spriteBatch.Draw(particleTexture, sparkRectangleTexture, Color.White);
        }

    }
}

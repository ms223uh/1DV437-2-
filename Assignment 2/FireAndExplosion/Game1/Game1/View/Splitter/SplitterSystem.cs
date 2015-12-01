using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1.View
{
    class SplitterSystem
    {

        private SplitterParticle[] particles;
        private const int numberOfParticles = 100;


        public SplitterSystem(Vector2 startPosition)
        {
            particles = new SplitterParticle[numberOfParticles];

            for (int i = 0; i < numberOfParticles; i++)
            {
                particles[i] = new SplitterParticle(i, startPosition);
            }

        }


        public void Update(float elapsedTime)
        {
            for (int i = 0; i < numberOfParticles; i++)
            {
                particles[i].Update(elapsedTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D particleTexture)
        {
            for (int i = 0; i < numberOfParticles; i++)
            {
                particles[i].Draw(spriteBatch, camera, particleTexture);
            }
        }



    }
}

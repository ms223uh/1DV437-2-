using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.View.Game1.View;

namespace Game1.View
{
    class ParticleSystem<ParticleType> where ParticleType : Particle, new()
    {

        private Particle[] particles; // array of particles
        private int numberOfParticles = 100;  // amount of particles

        // System for simulate the particles in the array
        public ParticleSystem(Vector2 startPosition, int numpart = 55)
        {
            numberOfParticles = numpart;
            particles = new ParticleType[numberOfParticles];

            for (int i = 0; i < numberOfParticles; i++)
            {
                particles[i] = new ParticleType();
                particles[i].Init(i, startPosition);
            }

        }

        // update the particles
        public void Update(float elapsedTime)
        {
            for (int i = 0; i < numberOfParticles; i++)
            {
                particles[i].Update(elapsedTime);
            }
        }

        // draw the particleExplosion
        public void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D particleTexture)
        {
            for (int i = 0; i < numberOfParticles; i++)
            {
                particles[i].Draw(spriteBatch, camera, particleTexture);
            }
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game1.View
{
    class SmokeParticle : Particle
    {
        public override void Init(int seed, Vector2 startPosition)
        {
            base.Init(seed, startPosition);
            Random random = new Random(this.seed);

            velocity = new Vector2((float)((random.NextDouble() - 0.8f)), (float)((random.NextDouble() - 0.8f))); // spreed direction
            velocity.Normalize();
            velocity = velocity * ((float)random.NextDouble() * 0.00011f); // size between particles
            acceleration = new Vector2(0.0f, -0.00000052f); // direction for the particles
        }
    }
}

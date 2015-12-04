using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1.View
{
    class SplitterParticle : Particle
    {
        public override void Init(int seed, Vector2 startPosition)
        {
            base.Init(seed, startPosition);
            Random random = new Random(this.seed);

            velocity = new Vector2((float)((random.NextDouble() - 0.5f)), (float)((random.NextDouble() - 0.5f))); // spreed direction
            velocity.Normalize();
            velocity = velocity * ((float)random.NextDouble() * 0.00057f); // size between particles
            acceleration = new Vector2(0.0f, 0.000005f); // direction for the particles
        }
    }
}

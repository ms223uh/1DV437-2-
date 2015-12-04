using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.View.Game1.View;

namespace Game1.View
{
    class SplitterView
    {

        SpriteBatch spriteBatch;
        List<ParticleSystem<SplitterParticle>> systems;
        Camera camera;
        Texture2D particleTexture;
        float durationTime;
        
        
        //construct
        public SplitterView(SpriteBatch Sprite, Camera camera2, Texture2D particleTexture2)
        {
            spriteBatch = Sprite;
            particleTexture = particleTexture2;
            camera = camera2;
            durationTime = 0;
            systems = new List<ParticleSystem<SplitterParticle>>();
        }

        public SplitterView()
        {
        }

        public void createParticle(Vector2 pos)
        {
            systems.Add(new ParticleSystem<SplitterParticle>(pos));
        }


        public void Draw(float elapsedTime, SpriteBatch spriteBatch, Camera camera, Texture2D splitterTexture)
        {



            spriteBatch.Begin();

            foreach (ParticleSystem<SplitterParticle> s in systems)
            {
                s.Update(elapsedTime);

                // draw the animation

                s.Draw(spriteBatch, camera, splitterTexture);

            }

            spriteBatch.End();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1.View
{
    class GameView
    {

        SpriteBatch spriteBatch;
        SplitterSystem particle;
        Camera camera;
        Texture2D particleTexture;
        float durationTime;
        
        
        //construct
        public GameView(SpriteBatch Sprite, Camera camera2, Texture2D particleTexture2)
        {
            spriteBatch = Sprite;
            particleTexture = particleTexture2;
            camera = camera2;
            durationTime = 0;
            createParticle();
        }


        public void createParticle()
        {
            Vector2 startPosition = new Vector2(0.5f, 0.5f); // postion of the splitter
            particle = new SplitterSystem(startPosition);
        }


        public void Draw(float elapsedTime)
        {
            durationTime += elapsedTime;
            if(durationTime > 2) // set timer between animation
            {
                createParticle();
                durationTime = 0;
            }

            particle.Update(elapsedTime);

            // draw the animation
            spriteBatch.Begin();

            particle.Draw(spriteBatch, camera, particleTexture);

            spriteBatch.End();
        }


    }
}

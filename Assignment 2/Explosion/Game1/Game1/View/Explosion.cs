using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Game1.View.Game1.View;

namespace Game1.View
{
    class Explosion
    {
        private Texture2D explosionTexture;
        private int xframes = 4; // amount of frames in X
        private int yframes = 8; // amount of frames in Y
        private int numberOfFrames = 24; // amount of frames in image
        private int frame;
        private int frameX;
        private int frameY;

        float goneTime;
        float explosionTime;
        float expWidth;
        float expHeight;
        float scale;

        public Explosion(Texture2D explosionTexture)
        {
            this.explosionTexture = explosionTexture;

            explosionTime = 3000.0f; // time for explosion
            
            expHeight = explosionTexture.Height / yframes;
            expWidth = explosionTexture.Width / xframes;
        }

        public void Draw(SpriteBatch spriteBatch, Camera cam, float elapsedTime)
        {
            scale = cam.getScale(0.7f, explosionTexture.Bounds.Width);
            goneTime += elapsedTime;
            if (goneTime >= explosionTime)
            {
                goneTime = 2; // time between explosion
            }
            float animatedTime = goneTime / explosionTime;

            // calc for the imageAnimation
            frame = (int)(animatedTime * numberOfFrames);
            frameX = frame % xframes;
            frameY = frame / xframes;

            // draw the explosion in center
            spriteBatch.Draw(explosionTexture, cam.getScreenCord(new Vector2(1.0f, 1.0f)),
                new Rectangle((int)(expWidth * frameX), (int)(expHeight * frameY), (int)expWidth, (int)expHeight),
                Color.White, 0, new Vector2(expWidth / 2, expHeight / 2), scale, SpriteEffects.None, 0);
        }
    }
}
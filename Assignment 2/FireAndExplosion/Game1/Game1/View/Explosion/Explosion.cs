using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.View;


namespace Game1.View
{
    class Explosion
    {

        private Texture2D explosionTexture;
        private int xFrames = 4;
        private int yFrames = 8;
        private int numberOfFrames = 24;
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
            explosionTime = 1750.0f;
            scale = 1.25f;

            expWidth = explosionTexture.Width / xFrames;
            expHeight = explosionTexture.Height / yFrames;

        }


        public void Draw(SpriteBatch spriteBatch, Camera cam, float elapsedTime)
        {
            goneTime += elapsedTime;
            if(goneTime >= explosionTime)
            {
                goneTime = 0;
            }

            float animatedTime = goneTime / explosionTime;

            frame = (int)(numberOfFrames * animatedTime);
            frameX = frame / xFrames;
            frameY = frame % yFrames;

            spriteBatch.Draw(explosionTexture, cam.getScreenCord(new Vector2(0.5f, 0.5f)),
                new Rectangle((int)(expWidth * frameX), (int)(expHeight * frameY), (int)expWidth, (int)expHeight),
                Color.White, 0, new Vector2(expWidth / 2, expHeight / 2), scale, SpriteEffects.None, 0);

        }

    }
}

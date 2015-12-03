using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.View;
using Game1.View.Game1.View;

namespace Game1.View
{
    class Explosion
    {
        Camera camera;
        private Texture2D explosionTexture;
        private int xframes = 4;
        private int yframes = 8;
        private int numberOfFrames = 24;
        private int frame;
        private int frameX;
        private int frameY;
        private Vector2 currentPos = new Vector2();

        float goneTime;
        float explosionTime;
        float expWidth;
        float expHeight;
        float scale;

        public Explosion(Texture2D explosionTexture, SpriteBatch sprite, Camera cam, float scale, Vector2 startPos)
        {
            this.explosionTexture = explosionTexture;

            currentPos = startPos;

            explosionTime = 1000.0f;
            scale = 1.0f;
            expHeight = explosionTexture.Height / yframes;
            expWidth = explosionTexture.Width / xframes;
        }

      

        public void Draw(SpriteBatch spriteBatch, Camera cam, float elapsedTime)
        {
            goneTime += elapsedTime;
            if (goneTime >= explosionTime)
            {
                goneTime = 0;
            }
            float animatedTime = goneTime / explosionTime;

            frame = (int)(animatedTime * numberOfFrames);
            frameX = frame % xframes;
            frameY = frame / xframes;

            spriteBatch.Draw(explosionTexture, cam.getScreenCord(new Vector2(1.0f, 1.0f)),
                new Rectangle((int)(expWidth * frameX), (int)(expHeight * frameY), (int)expWidth, (int)expHeight),
                Color.White, 0, new Vector2(expWidth / 2, expHeight / 2), scale, SpriteEffects.None, 0);
        }
    }
}

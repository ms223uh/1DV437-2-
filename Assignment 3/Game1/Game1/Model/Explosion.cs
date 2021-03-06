﻿using System;
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
        float size = 0.2f;
        float scale;

        private int frameCount = 0;

        public Explosion(Texture2D explosionTexture, SpriteBatch sprite, Camera cam, Vector2 startPos)
        {
            this.explosionTexture = explosionTexture;
            camera = cam;
            currentPos = startPos;

            explosionTime = 1000.0f;
            expHeight = explosionTexture.Height / yframes;
            expWidth = explosionTexture.Width / xframes;

            scale = camera.getScale(expWidth, size);
        }



        public void Draw(SpriteBatch spriteBatch, Camera cam, float elapsedTime)
        {
            frameCount++;

            if (frameCount <= 32)
            {

                goneTime += elapsedTime;
                if (goneTime > explosionTime)
                {
                    goneTime = 0;
                }
                float animatedTime = goneTime / explosionTime;

                frame = (int)(animatedTime * numberOfFrames);
                frameX = frame % xframes;
                frameY = frame / xframes;

                spriteBatch.Begin();
                spriteBatch.Draw(explosionTexture, camera.getScreenCord(currentPos),
                new Rectangle((int)(expWidth * frameX), (int)(expHeight * frameY), (int)expWidth, (int)expHeight),
                Color.White, 0, new Vector2(expWidth / 2, expHeight / 2), scale, SpriteEffects.None, 0);
                spriteBatch.End();

            }
        }
    }
}
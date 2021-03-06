﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.View
{
    namespace Game1.View
    {
        class Camera
        {
            private float scaleY;
            private float scaleX;

            // get the mid of the screen
            public Camera(Viewport viewport)
            {
                scaleX = viewport.Width / 2;
                scaleY = viewport.Height / 2;
            }

            public float getScale(float radius, int boundWidth)
            {
                return (radius * 2.0f) * (float)scaleX / (float)boundWidth;
            }

            // get the screen cordination
            public Vector2 getScreenCord(Vector2 screenPosition)
            {
                int screenX = (int)((screenPosition.X * scaleX));
                int screenY = (int)((screenPosition.Y * scaleY));
                return new Vector2(screenX, screenY);
            }

            
        }
    }
}
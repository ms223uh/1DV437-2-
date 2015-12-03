using System;
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
            float boarderSize = 24;

            public void setfieldsize(Viewport viewport)
            {
                scaleX = viewport.Width;
                scaleY = viewport.Height;
            }

            public float getScale(float radius, int boundWidth)
            {
                return (radius * 2.0f) * (float)scaleX / (float)boundWidth;
            }

            public Vector2 getScreenCord(Vector2 screenPosition)
            {
                int screenX = (int)((screenPosition.X * scaleX));
                int screenY = (int)((screenPosition.Y * scaleY));
                return new Vector2(screenX, screenY);
            }


            public Vector2 getLogicalCord(float x, float y)
            {
                int screenX = (int)((x / scaleX));
                int screenY = (int)((y / scaleY));
                return new Vector2(screenX, screenY);
            }


            public Vector2 getMouseCord(Vector2 mouseCord)
            {
                float VisualX = (mouseCord.X - boarderSize) / scaleX;
                float VisualY = (mouseCord.Y - boarderSize) / scaleY;

                return new Vector2(VisualX, VisualY);
            }


            public Rectangle getRectangle(float x, float y)
            {
                return new Rectangle((int)(scaleX * x), (int)(scaleY * y), 150, 150);
            }
        }
    }
}

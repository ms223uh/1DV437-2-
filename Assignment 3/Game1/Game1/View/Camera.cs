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
            private float scale;
            float boarderSize = 24;

            public void setfieldsize(Viewport viewport)
            {
                scale = 1f / (Math.Min(viewport.Width, viewport.Height) - boarderSize*2);
            }

            public float getScale(float texturesize, float size)
            {
                return size / texturesize / scale;
            }

            public Vector2 getScreenCord(Vector2 screenPosition)
            {
                int screenX = (int)boarderSize + (int)((screenPosition.X / scale));
                int screenY = (int)boarderSize + (int)((screenPosition.Y / scale));
                return new Vector2(screenX, screenY);
            }


            public Vector2 getLogicalCord(float x, float y)
            {
                int screenX = (int)((x / scale));
                int screenY = (int)((y / scale));
                return new Vector2(screenX, screenY);
            }


            public Vector2 getMouseCord(Vector2 mouseCord)
            {
                float VisualX = (mouseCord.X - boarderSize) * scale;
                float VisualY = (mouseCord.Y - boarderSize) * scale;

                return new Vector2(VisualX, VisualY);
            }


            public Rectangle getRectangle(float x, float y)
            {
                return new Rectangle((int)(scale * x), (int)(scale * y), 150, 150);
            }
        }
    }
}

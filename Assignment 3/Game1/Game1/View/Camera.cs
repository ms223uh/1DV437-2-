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
            float borderSize = 0;
            private Viewport viewport;

            public Camera(Viewport viewPort)
            {
                this.viewport = viewPort;
            }

            public void setfieldsize()
            {
                scale = 1f / (Math.Min(viewport.Width, viewport.Height) - borderSize / 2);
            }

            public float getScale(float texturesize, float size)
            {
                return size / texturesize / scale;
            }

            public Vector2 getScreenCord(Vector2 screenPosition)
            {
                int screenX = (int)borderSize + (int)((screenPosition.X / scale));
                int screenY = (int)borderSize + (int)((screenPosition.Y / scale));
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
                float VisualX = (mouseCord.X - borderSize) * scale;
                float VisualY = (mouseCord.Y - borderSize) * scale;

                return new Vector2(VisualX, VisualY);
            }


            public Rectangle getRectangle(float x, float y)
            {
                return new Rectangle((int)(scale * x), (int)(scale * y), 150, 150);
            }

            public Rectangle gameArea()
            {
                return new Rectangle((int)borderSize, (int)borderSize, (int)viewport.Width, (int)viewport.Height);
            }

            //scale the ball, here can we set the size for the ball
            public float ballScale(float radius, int ballWidth)
            {
                return (radius * 2.0f) * (float)viewport.Width / (int)ballWidth;
            }


        }
    }
}
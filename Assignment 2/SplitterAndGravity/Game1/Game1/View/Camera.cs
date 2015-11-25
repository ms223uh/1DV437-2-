using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.View
{
    class Camera
    {

        private float cordX;
        private float cordY;


        public Camera(Viewport viewport)
        {
            cordX = viewport.Width;
            cordY = viewport.Height;

            if (cordY < cordX)
            {
                cordX = cordY;
            }
            else if (cordY > cordX)
            {
                cordY = cordX;
            }
        }

        public Vector2 screenCord(Vector2 screenPosition)
        {
            int screenX = (int)((screenPosition.X * cordX));
            int screenY = (int)((screenPosition.Y * cordY));
            return new Vector2(screenX, screenY);
        }

        public Rectangle getRectangle(Vector2 screenPosition, float radius)
        {
            Vector2 position = screenCord(screenPosition);
            float textureSize = radius * cordX;

            return new Rectangle((int)(position.X - textureSize), (int)(position.Y - textureSize), (int)(textureSize * 2.0f), (int)(textureSize * 2.0f));
        }

    }
}

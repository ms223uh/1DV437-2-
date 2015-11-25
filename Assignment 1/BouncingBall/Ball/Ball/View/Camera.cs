using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ball.View
{
    class Camera
    {
        private float cordX;
        private float cordY;
        private float borderSize = 40;

        public Camera(Viewport viewport)
        {
            cordX = viewport.Height;
            cordY = viewport.Width;

            if (cordY < cordX)
            {
                cordX = cordY;
            }
            else if(cordX < cordY)
            {
                cordY = cordX;
            }

            cordX = cordX - borderSize * 2;
            cordY = cordY - borderSize * 2;
        }


        public Rectangle gameArea()
        {
            return new Rectangle((int)borderSize, (int)borderSize, (int)cordX, (int)cordY);
        }

        public float ballScale(float radius, int ballWidth)
        {
            return (radius * 2.0f) * (float)cordX / (int)ballWidth;
        }

        public Vector2 screenCord(Vector2 logicalPosition)
        {
            int screenCordX = (int)(logicalPosition.X * cordX) + (int)borderSize;
            int screenCordY = (int)(logicalPosition.Y * cordY) + (int)borderSize;

            return new Vector2(screenCordX, screenCordY);
        }


    }
}

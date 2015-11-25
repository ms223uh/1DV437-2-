using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess
{
    class Camera
    {

        int sizeOfTile = 64;
        int borderSize = 64;
        int visualX;
        int visualY;
        GraphicsDeviceManager graphics;

        public Camera(GraphicsDeviceManager Graphics)
        {
            graphics = Graphics;
        }

        public Rectangle getCordinations(int x, int y)
        {
            visualX = borderSize + x * sizeOfTile;
            visualY = borderSize + y * sizeOfTile;

            return new Rectangle(visualX, visualY, sizeOfTile, sizeOfTile);
        }

        public Rectangle rotateBoard(int xCord, int yCord)
        {
           visualX = (sizeOfTile * 8 + borderSize - sizeOfTile) - (xCord * sizeOfTile);
           visualY = (sizeOfTile * 8 + borderSize - sizeOfTile) - (yCord * sizeOfTile);

            return new Rectangle(visualX, visualY, sizeOfTile, sizeOfTile);
        }

        public Rectangle whiteScale(int x, int y)
        {
            sizeOfTile = graphics.GraphicsDevice.Viewport.Width / 10;
            borderSize = graphics.GraphicsDevice.Viewport.Width / 10;

            visualX = borderSize + x * sizeOfTile;
            visualY = borderSize + y * sizeOfTile;

            return new Rectangle(visualX, visualY, sizeOfTile, sizeOfTile);

        }

        public Rectangle blackScale(int xCord, int yCord)
        {
            sizeOfTile = graphics.GraphicsDevice.Viewport.Width / 10;
            borderSize = graphics.GraphicsDevice.Viewport.Width / 10;

            visualX = (sizeOfTile * 8 + borderSize - sizeOfTile) - (xCord * sizeOfTile);
            visualY = (sizeOfTile * 8 + borderSize - sizeOfTile) - (yCord * sizeOfTile);

            return new Rectangle(visualX, visualY, sizeOfTile, sizeOfTile); ;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.View.Game1.View;
using Game1.View;

namespace Game1.Controller
{
    class GameController
    {
        SpriteBatch spriteBatch;
        Camera camera;
        ExplosionView explosionView;


        public void explosionClicked(Vector2 isClicked)
        {
            Vector2 clicked = camera.getLogicalCord(isClicked.X, isClicked.Y);
            
        }

    }
}

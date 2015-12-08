using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ball.Model;
using Game1.View.Game1.View;

namespace Ball.View 
{
    class BallView
    {
        
        BallSimulation ballSimulation;
        Camera camera;
        Texture2D ballTexture;
        Texture2D gameBox;

        // construct
        public BallView(BallSimulation ballSim, Camera viewCamera, GraphicsDevice graphics, Texture2D psyBall)
        {
            ballSimulation = ballSim;
            camera = viewCamera;
            ballTexture = psyBall;

            gameBox = new Texture2D(graphics, 1, 1);
            gameBox.SetData(new[] { Color.CadetBlue });

        }

        // draw the gameArea and set color
        public void Draw(SpriteBatch sprite)
        {
           

            sprite.Begin();

      
            sprite.Draw(gameBox, camera.gameArea(), Color.CornflowerBlue);

            foreach (Model.Ball ball in ballSimulation.getBalls())
            {
                float psyBallScale = camera.ballScale(ball.getBallRadius(), ballTexture.Bounds.Width);
                sprite.Draw(ballTexture,
                                  camera.getScreenCord(ball.getBallPosition()),
                                  ballTexture.Bounds,
                                  Color.White, 0,
                                  new Vector2(ballTexture.Bounds.Width / 2, ballTexture.Height / 2),
                                  psyBallScale, SpriteEffects.None, 0
                     );
            }
             sprite.End();
        }

    }
}

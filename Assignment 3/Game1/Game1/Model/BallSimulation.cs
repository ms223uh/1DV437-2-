using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ball.Model
{
    class BallSimulation
    {

        Ball ball;
        public BallSimulation()
        {
            ball = new Ball();
        }
        
        public Vector2 simBallPosition()
        {
            return ball.getBallPosition();
        }

        public float simBallRadius()
        {
            return ball.getBallRadius();
        }

        // set collision in wall, ball colloide in postion 1 & 0, between its free example: 0,5 the ball not collide
        public void simUpdate(float gameTime)
        {
            ball.updateBallPosition(gameTime);

            if(ball.getBallPosition().X + ball.getBallRadius() > 1 || ball.getBallPosition().X - ball.getBallRadius() < 0)
            {
                ball.setBallSpeedX();
            }
            

            if (ball.getBallPosition().Y + ball.getBallRadius() > 1 || ball.getBallPosition().Y - ball.getBallRadius() < 0)
            {
                ball.setBallSpeedY();
            }
            

        }

    }
}

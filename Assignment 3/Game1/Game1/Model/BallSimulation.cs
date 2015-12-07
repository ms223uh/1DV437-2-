using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Model;

namespace Ball.Model
{
    class BallSimulation
    {

        Ball ball;

        private const int numberOfBalls = 10;
        private Ball[] balls = new Ball[numberOfBalls];
        AimScope aim = new AimScope();

        public BallSimulation()
        {
            
            for (int i = 0; i < numberOfBalls; i++)
            {
                ball = new Ball();
            }
            
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


        internal void HitBall(Vector2 mousePosition, IModelListener1 view)
        {
            foreach (Ball ball in balls)
            {
                if (ball.ballAlive)
                {
                    Vector2 ballPosition = ball.getBallPosition();
                    if (ballPosition.Y >= (mousePosition.Y - aim.Radius) &&
                        ballPosition.Y <= (mousePosition.Y + aim.Radius) &&
                        ballPosition.X >= (mousePosition.X - aim.Radius) &&
                        ballPosition.X <= (mousePosition.X + aim.Radius))
                    {
                        ball.ballAlive = false;
                        view.HitBall(ballPosition.X, ballPosition.Y);
                    }
                }
            }
        }

    }
}

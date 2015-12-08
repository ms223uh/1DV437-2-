using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ball.Model
{
    class Ball
    {
        Vector2 ballPosition;
        Vector2 ballSpeed;
        float ballRadius = 0.05f; // size and collisionArea for the ball
       // Vector2 velocity2 = new Vector2(0.7f, 0.3f); // speed and direction for the ball
        private bool alive = true;

        Vector2 velocity2;



        public Ball(Random random)
        {
            ballPosition = new Vector2(0.7f, 0.2f);
            // ballSpeed = new Vector2(velocity, velocity);

            velocity2 = new Vector2((float)(random.NextDouble() - 0.7f ), (float)(random.NextDouble() - 0.2f));

            ballSpeed = velocity2;
        }


        // update the direction/postion and speed
        public void updateBallPosition(float time)
        {
            ballPosition.X += ballSpeed.X * time;
            ballPosition.Y += ballSpeed.Y * time;
        }

        // update speed and direction
        public void updateVelocity(float velocityValue)
        {
            velocity2.X += velocityValue;
        }

        public Vector2 getBallPosition()
        {
            return ballPosition;
        }

        // function get/set ballspeed
        public void setBallSpeedX()
        {
           
                ballSpeed.X = -ballSpeed.X;
            
        }

        // function get/set ballspeed
        public void setBallSpeedY()
        {
           
                ballSpeed.Y = -ballSpeed.Y;
            
        }

        public float getBallRadius()
        {
            return ballRadius;
        }

        public bool ballAlive
        {
            get { return alive; }
            set { alive = value; }
        }

    }
}
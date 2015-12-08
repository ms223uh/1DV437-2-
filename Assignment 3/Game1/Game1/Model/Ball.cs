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
        Vector2 velocity2 = new Vector2(0.7f, 0.3f); // speed and direction for the ball
        private bool alive = true;
        
        

        public Ball()
        {
            ballPosition = new Vector2(0.5f, 0.5f);
           // ballSpeed = new Vector2(velocity, velocity);
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
            if (ballSpeed.X < 0)
            {
                ballSpeed.X = velocity2.X;
            }
            else
            {
                ballSpeed.X =- ballSpeed.X;
            }
        }

        // function get/set ballspeed
        public void setBallSpeedY()
        {
            if (ballSpeed.Y < 0)
            {
                ballSpeed.Y = velocity2.Y;
            }
            else
            {
                ballSpeed.Y =- ballSpeed.Y;
            }
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

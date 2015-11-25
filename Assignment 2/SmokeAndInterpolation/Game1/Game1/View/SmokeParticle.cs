using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.View
{
    class SmokeParticle
    {

        public Vector2 smokePosition;
        Vector2 smokeStartDirection;
        Vector2 smokeEndDirection;
        float smokeLifeLeft;
        float smokeStartingLife;
        float smokeScaleBegin;
        float smokeScaleEnd;
        Color smokeStartColor;
        Color smokeEndColor;
        SmokeSystem smokeSystem;
        float smokelifePhase;


        public SmokeParticle(Vector2 Position, Vector2 StartDirection,
            Vector2 EndDirection, float StartingLife,
            float ScaleBegin, float ScaleEnd, Color StartColor,
            Color EndColor, SmokeSystem SmokeSystem)

        {
            this.smokePosition = Position;
            this.smokeStartDirection = StartDirection;
            this.smokeEndDirection = EndDirection;
            this.smokeStartingLife = StartingLife;
            this.smokeLifeLeft = StartingLife;
            this.smokeScaleBegin = ScaleBegin;
            this.smokeScaleEnd = ScaleEnd;
            this.smokeStartColor = StartColor;
            this.smokeEndColor = EndColor;
            this.smokeSystem = SmokeSystem;
        }


        public bool Update(float elapsedTime)
        {
            smokeLifeLeft -= elapsedTime;
            if (smokeLifeLeft <= 0)
            {
                return false;
            }
            smokelifePhase = smokeLifeLeft / smokeStartingLife;
            smokePosition += SmokeCalculate.smokeyCalc(smokeEndDirection, smokeStartDirection, smokelifePhase) * elapsedTime;
            return true;
        }


        public void Draw(SpriteBatch spriteBatch, int Scale, Vector2 Offset)
        {
            float currScale = SmokeCalculate.smokeyCalc(smokeScaleEnd, smokeScaleBegin, smokelifePhase);
            Color currCol = SmokeCalculate.smokeyCalc(smokeEndColor, smokeStartColor, smokelifePhase);
            spriteBatch.Draw(smokeSystem.smokeParticleSprite,
                     new Rectangle((int)((smokePosition.X - 0.5f * currScale) * Scale + Offset.X),
                              (int)((smokePosition.Y - 0.5f * currScale) * Scale + Offset.Y),
                              (int)(currScale * Scale),
                              (int)(currScale * Scale)),
                     null, currCol, 0, Vector2.Zero, SpriteEffects.None, 0);
        }

    }
}
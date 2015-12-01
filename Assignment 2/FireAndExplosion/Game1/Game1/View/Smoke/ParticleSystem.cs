using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.View
{
    class ParticleSystem
    {
        public List<SmokeSystem> smokeList;
        public Vector2 smokePosition;
        Random random;

        public ParticleSystem(Vector2 position)
        {
            this.smokePosition = position;
            random = new Random();
            smokeList = new List<SmokeSystem>();
        }

        public void Update(float dt)
        {
            for (int i = 0; i < smokeList.Count; i++)
            {
                if (smokeList[i].maxSmokeParticle > 0)
                {
                    smokeList[i].Update(dt);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, int Scale, Vector2 Offset)
        {
            for (int i = 0; i < smokeList.Count; i++)
            {
                if (smokeList[i].maxSmokeParticle > 0)
                {
                    smokeList[i].Draw(spriteBatch, Scale, Offset);
                }
            }
        }

        public void Clear()
        {
            for (int i = 0; i < smokeList.Count; i++)
            {
                if (smokeList[i].maxSmokeParticle > 0)
                {
                    smokeList[i].Clear();
                }
            }
        }

        public void addParticle(Vector2 smokeSecPerSpawn, Vector2 smokeSpawnDirection, Vector2 smokeSpawnNoiseAngle, Vector2 smokeStartLife, Vector2 smokeStartScale,
                    Vector2 smokeEndScale, Color smokeStartColor1, Color smokeStartColor2, Color smokeEndColor1, Color smokeEndColor2, Vector2 smokeStartSpeed,
                    Vector2 smokeEndSpeed, int maxSmokeParticle, Vector2 smokeRelPosition, Texture2D smokeParticleSprite)
        {
            SmokeSystem smokeSystem = new SmokeSystem(smokeSecPerSpawn, smokeSpawnDirection, smokeSpawnNoiseAngle,
                                        smokeStartLife, smokeStartScale, smokeEndScale, smokeStartColor1,
                                        smokeStartColor2, smokeEndColor1, smokeEndColor2, smokeStartSpeed,
                                        smokeEndSpeed, maxSmokeParticle, smokeRelPosition, smokeParticleSprite, this.random, this);
            smokeList.Add(smokeSystem);
        }


    }
}
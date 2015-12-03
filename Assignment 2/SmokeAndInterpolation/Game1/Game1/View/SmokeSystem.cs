using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.View
{
    class SmokeSystem
    {
        public Texture2D smokeParticleSprite;
        public int maxSmokeParticle;
        float spawnNextParticle;
        float lastParticle;
        LinkedList<SmokeParticle> activeSmokeParticles; // LinkedList added a collection of SmokeParticle
        Random random;
        public Vector2 smokeRelPosition;

        public Vector2 smokeSecPerSpawn;
        public Vector2 smokeSpawnDirection;
        public Vector2 smokeSpawnNoiseAngle;
        public Vector2 smokeStartLife;
        public Vector2 smokeStartScale;
        public Vector2 smokeEndScale;
        public Color smokeStartColor1;
        public Color smokeStartColor2;
        public Color smokeEndColor1;
        public Color smokeEndColor2;
        public Vector2 smokeStartSpeed;
        public Vector2 smokeEndSpeed;

        public ParticleSystem particleSystem;

        // construct
        public SmokeSystem(Vector2 SecPerSpawn, Vector2 SpawnDirection, Vector2 SpawnNoiseAngle,
                            Vector2 StartLife, Vector2 StartScale, Vector2 EndScale, Color StartColor1,
                            Color StartColor2, Color EndColor1, Color EndColor2, Vector2 StartSpeed,
                            Vector2 EndSpeed, int Budget, Vector2 RelPosition, Texture2D smokeParticleSprite,
                            Random random, ParticleSystem particleSystem)
        {
            this.smokeSecPerSpawn = SecPerSpawn;
            this.smokeSpawnDirection = SpawnDirection;
            this.smokeSpawnNoiseAngle = SpawnNoiseAngle;
            this.smokeStartLife = StartLife;
            this.smokeStartScale = StartScale;
            this.smokeEndScale = EndScale;
            this.smokeStartColor1 = StartColor1;
            this.smokeStartColor2 = StartColor2;
            this.smokeEndColor1 = EndColor1;
            this.smokeEndColor2 = EndColor2;
            this.smokeStartSpeed = StartSpeed;
            this.smokeEndSpeed = EndSpeed;
            this.maxSmokeParticle = Budget;
            this.smokeRelPosition = RelPosition;
            this.smokeParticleSprite = smokeParticleSprite;
            this.random = random;
            this.particleSystem = particleSystem;

            activeSmokeParticles = new LinkedList<SmokeParticle>();

            this.spawnNextParticle = SmokeCalculate.smokeyCalc(smokeSecPerSpawn.X, smokeSecPerSpawn.Y, random.NextDouble());
            this.lastParticle = 0.0f;
        }

        // update particle for smoke animation
        public void Update(float elapsedTime)
        {
            lastParticle += elapsedTime;
            while (lastParticle > spawnNextParticle)
            {
                if (activeSmokeParticles.Count < maxSmokeParticle)
                {
                    // Spawn a particle
                    Vector2 StartDirection = Vector2.Transform(smokeSpawnDirection, Matrix.CreateRotationZ(SmokeCalculate.smokeyCalc(smokeSpawnNoiseAngle.X, smokeSpawnNoiseAngle.Y, random.NextDouble()))); // rotation
                    StartDirection.Normalize();
                    Vector2 EndDirection = StartDirection * SmokeCalculate.smokeyCalc(smokeEndSpeed.X, smokeEndSpeed.Y, random.NextDouble()); // endSpeed for smoke
                    StartDirection *= SmokeCalculate.smokeyCalc(smokeStartSpeed.X, smokeStartSpeed.Y, random.NextDouble()); // startSpeed for smoke
                    activeSmokeParticles.AddLast(new SmokeParticle(  // activate the smokeParticles
                        smokeRelPosition + particleSystem.smokePosition,   // position for the smoke
                        StartDirection,
                        EndDirection,
                        SmokeCalculate.smokeyCalc(smokeStartLife.X, smokeStartLife.Y, random.NextDouble()),   // calc fot the smokeAnimation
                        SmokeCalculate.smokeyCalc(smokeStartScale.X, smokeStartScale.Y, random.NextDouble()),
                        SmokeCalculate.smokeyCalc(smokeEndScale.X, smokeEndScale.Y, random.NextDouble()),
                        SmokeCalculate.smokeyCalc(smokeStartColor1, smokeStartColor2, random.NextDouble()),
                        SmokeCalculate.smokeyCalc(smokeEndColor1, smokeEndColor2, random.NextDouble()),
                        this)
                    );
                }
                lastParticle -= spawnNextParticle;
                spawnNextParticle = SmokeCalculate.smokeyCalc(smokeSecPerSpawn.X, smokeSecPerSpawn.Y, random.NextDouble());
            }

            //spawn particle
            // next particle in LinkedList
            LinkedListNode<SmokeParticle> smokeNode = activeSmokeParticles.First;
            while (smokeNode != null) // if not null/empty spawn next
            {
                bool isAlive = smokeNode.Value.Update(elapsedTime);
                smokeNode = smokeNode.Next;
                if (!isAlive)
                {
                    if (smokeNode == null) // if null/empty remove last or spawn the last particle
                    {
                        activeSmokeParticles.RemoveLast();
                    }
                    else
                    {
                        activeSmokeParticles.Remove(smokeNode.Previous);
                    }
                }
            }
        }

        // draw the particles for smokeAnimatin
        public void Draw(SpriteBatch spriteBatch, int Scale, Vector2 Offset)
        {
            LinkedListNode<SmokeParticle> smokeNode = activeSmokeParticles.First;
            while (smokeNode != null)
            {
                smokeNode.Value.Draw(spriteBatch, Scale, Offset);
                smokeNode = smokeNode.Next;
            }
        }

        // clear the smokeParticle in endPosition
        public void Clear()
        {
            activeSmokeParticles.Clear();
        }

    }

}
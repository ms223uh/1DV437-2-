using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.View
{
    class SmokeCalculate
    {
        public static byte smokeyCalc(byte a, byte b, double t)
        {
            return (byte)(a * (1 - t) + b * t);
        }
        public static float smokeyCalc(float a, float b, double t)
        {
            return (float)(a * (1 - t) + b * t);
        }
        public static Vector2 smokeyCalc(Vector2 a, Vector2 b, double t)
        {
            return new Vector2(smokeyCalc(a.X, b.X, t),
                               smokeyCalc(a.Y, b.Y, t));
        }
        public static Vector4 smokeyCalc(Vector4 a, Vector4 b, double t)
        {
            return new Vector4(smokeyCalc(a.X, b.X, t),
                               smokeyCalc(a.Y, b.Y, t),
                               smokeyCalc(a.Z, b.Z, t),
                               smokeyCalc(a.W, b.W, t));
        }
        public static Color smokeyCalc(Color a, Color b, double t)
        {
            return new Color(smokeyCalc(a.R, b.R, t),
                             smokeyCalc(a.G, b.G, t),
                             smokeyCalc(a.B, b.B, t),
                             smokeyCalc(a.A, b.A, t));
        }

    }
}
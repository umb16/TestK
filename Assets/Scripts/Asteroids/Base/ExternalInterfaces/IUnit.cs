using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace MK.Asteroids
{
    public interface IUnit
    {
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        /// <summary>
        /// In radians
        /// </summary>
        float Angle { get; set; }
        float Radius { get; }
        bool MustBeDestroyed { get; set; }
        void Destroy();
    }
}
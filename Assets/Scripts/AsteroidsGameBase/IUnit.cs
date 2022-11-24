using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace MK.AsteroidsGame
{
    public interface IUnit
    {
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        float Angle { get; set; }
        float Radius { get; }
        void Destroy();
    }
}
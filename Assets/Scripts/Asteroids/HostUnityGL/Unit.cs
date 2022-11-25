
using MK.Pooling;
using System;
using System.Numerics;

namespace MK.Asteroids.HostUnityGL
{
    public class Unit : IUnit
    {
        public UnitType Type { get; private set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Position { get; set; }

        public float Radius { get; }
        public float Angle { get; set; }
        public Action DestroyAction { get; set; }
        public bool MustBeDestroyed { get; set; }

        public Unit(UnitType unitType, float radius)
        {
            Type = unitType;
            Radius = radius;
        }
        public void Destroy() => DestroyAction();
    }
}

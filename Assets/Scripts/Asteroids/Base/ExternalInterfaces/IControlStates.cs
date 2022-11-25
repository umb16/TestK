using System;

namespace MK.Asteroids
{
    public interface IControlStates
    {
        bool Accelerate { get; }
        float Rotate { get; }
        bool FireBullet { get; }
        bool FireRay { get; }
        bool Restart { get; }
    }
}
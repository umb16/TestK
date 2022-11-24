using System;

namespace MK.AsteroidsGame
{
    public interface IControlStates
    {
        bool Accelerate { get; }
        float Rotate { get; }
        bool FireBullet { get; }
        bool FireRay { get; }
    }
}
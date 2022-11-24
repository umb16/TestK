using System;
using System.Numerics;

namespace MK.AsteroidsGame
{
    public class Utils
    {
        private Random _random = new Random();
        private Vector2 _size;
        private Units _units;

        public Utils(Settings settings, Units units)
        {
            _size = settings.screenSize;
            _units = units;
        }
        public bool CheckCollision(IUnit unit1, IUnit unit2)
        {
            float collisionSquaredRange = MathF.Pow((unit1.Radius + unit2.Radius), 2);
            return (unit1.Position - unit2.Position).LengthSquared() < collisionSquaredRange;
        }

        public Vector2 GetRandomSafePointAroundPlayer(float radius)
        {
            return GetRandomSafePointAroundUnit(_units.Player, radius);
        }

        public Vector2 GetRandomSafePointAroundUnit(IUnit unit, float radius)
        {
            var point = new Vector2((float)(_random.NextDouble() - .5) * _size.X, (float)(_random.NextDouble() - .5) * _size.Y);
            if ((unit.Position - point).Length() < unit.Radius * 2 + radius * 2)
                return point + GetRandomDir() * (unit.Radius * 2 + radius * 2);
            return point;
        }
        public Vector2 GetRandomDir()
        {
            float random = (float)_random.NextDouble() * MathF.PI * 2;
            return new Vector2(MathF.Cos(random), MathF.Sin(random));
        }
    }
}
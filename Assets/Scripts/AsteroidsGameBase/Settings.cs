using System.Numerics;

namespace MK.AsteroidsGame
{
    public struct Settings
    {
        public float SpeedFactor { get; }
        public Vector2 ScreenSize { get; }
        public float AsteroidSpeed { get; }
        public float AsteroidPartSpeed { get; }
        public float SaucerSpeed { get; }

        public Settings(Vector2 screenSize,
            float speedFactor = 1,
            float asteroidSpeed = .3f,
            float asteroidPartSpeed = .5f,
            float saucerSpeed = .3f)
        {
            SpeedFactor = speedFactor;
            ScreenSize = screenSize;
            AsteroidSpeed = asteroidSpeed;
            AsteroidPartSpeed = asteroidPartSpeed;
            SaucerSpeed = saucerSpeed;
        }
    }
}
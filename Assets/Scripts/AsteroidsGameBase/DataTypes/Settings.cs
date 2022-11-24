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
        public int AsteroidScore { get; }
        public int SaucerScore { get; }
        public int AsteroidPartScore { get; }
        public float MaxPlayerSpeed { get; }

        public Settings(Vector2 screenSize,
            float speedFactor = 1,
            float asteroidSpeed = .3f,
            float asteroidPartSpeed = .5f,
            float saucerSpeed = .3f,
            int asteroidScore = 10,
            int saucerScore = 20,
            int asteroidPartScore = 11,
            float maxPlayerSpeed = 10)
        {
            SpeedFactor = speedFactor;
            ScreenSize = screenSize;
            AsteroidSpeed = asteroidSpeed;
            AsteroidPartSpeed = asteroidPartSpeed;
            SaucerSpeed = saucerSpeed;
            AsteroidScore = asteroidScore;
            SaucerScore = saucerScore;
            AsteroidPartScore = asteroidPartScore;
            MaxPlayerSpeed = maxPlayerSpeed;
        }
    }
}
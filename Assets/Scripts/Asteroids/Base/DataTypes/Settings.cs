using System.Numerics;

namespace MK.Asteroids
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
        public float BulletSpeed { get; }
        public int MaxRayAmmunition { get; }
        public float RayCooldownFactor { get; }
        public float AsteroidSize { get; }
        public float AsteroidPartSize { get; }
        public float SaucerSize { get; }
        public float PlayerSize { get; }
        public float BulletSize { get; }

        public Settings(Vector2 screenSize,
            float speedFactor = 1,
            float asteroidSpeed = .3f,
            float asteroidPartSpeed = .7f,
            float saucerSpeed = .5f,
            int asteroidScore = 10,
            int saucerScore = 20,
            int asteroidPartScore = 11,
            float bulletSpeed = 10,
            int maxRayAmmunition = 3,
            float rayCooldownSpeed = .1f,
            float asteroidSize = 1,
            float asteroidPartSize =.5f,
            float saucerSize = 1,
            float playerSize =.5f,
            float bulletSize = .1f)
        {
            SpeedFactor = speedFactor;
            ScreenSize = screenSize;
            AsteroidSpeed = asteroidSpeed;
            AsteroidPartSpeed = asteroidPartSpeed;
            SaucerSpeed = saucerSpeed;
            AsteroidScore = asteroidScore;
            SaucerScore = saucerScore;
            AsteroidPartScore = asteroidPartScore;
            BulletSpeed = bulletSpeed;
            MaxRayAmmunition = maxRayAmmunition;
            RayCooldownFactor = rayCooldownSpeed;
            AsteroidSize = asteroidSize;
            AsteroidPartSize = asteroidPartSize;
            SaucerSize = saucerSize;
            PlayerSize = playerSize;
            BulletSize = bulletSize;
        }
    }
}
using System.Numerics;

namespace MK.AsteroidsGame
{
    public class Spawner : IRealtime
    {
        private Units _units;
        private Utils _utils;
        private Settings _settings;

        public Spawner(Settings settings, Units units, Utils utils)
        {
            _units = units;
            _utils = utils;
            _settings = settings;
        }

        public void Update(float deltaTime)
        {
            TrySpawnAsteroid();
            TrySpawnSaucer();
        }

        private void TrySpawnAsteroid()
        {
            if (_units.GetCount(UnitType.Asteroid) < 3)
                CreateAsteroid();
        }
        private void TrySpawnSaucer()
        {
            if (_units.GetCount(UnitType.Saucer) < 2)
                CreateSaucer();
        }

        private void CreateAsteroid()
        {
            var asteroid = _units.CreateUnit(UnitType.Asteroid);
            asteroid.Position = _utils.GetRandomSafePointAroundPlayer(asteroid.Radius);
            asteroid.Velocity = _utils.GetRandomDir() * _settings.AsteroidSpeed;
        }

        private void CreateSaucer()
        {
            var saucer = _units.CreateUnit(UnitType.Saucer);
            saucer.Position = _utils.GetRandomSafePointAroundPlayer(saucer.Radius);
        }
    }
}
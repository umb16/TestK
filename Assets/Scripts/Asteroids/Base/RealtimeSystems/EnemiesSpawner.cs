using System.Numerics;

namespace MK.Asteroids
{
    public class EnemiesSpawner : IRealtime
    {
        private Units _units;
        private Utils _utils;
        private Settings _settings;
        private RealtimeGameData _gameData;
        private int MaxAsteroids => _gameData.Score / 100 + 3;
        private int MaxSaucers => _gameData.Score / 200 + 2;

        public EnemiesSpawner(Settings settings, Units units, Utils utils, RealtimeGameData gameData)
        {
            _units = units;
            _utils = utils;
            _settings = settings;
            _gameData = gameData;
        }

        public void Update(float deltaTime)
        {
            TrySpawnAsteroid();
            TrySpawnSaucer();
        }

        private void TrySpawnAsteroid()
        {
            if (_units.GetCount(UnitType.Asteroid) < MaxAsteroids)
                CreateAsteroid();
        }
        private void TrySpawnSaucer()
        {
            if (_units.GetCount(UnitType.Saucer) < MaxSaucers)
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
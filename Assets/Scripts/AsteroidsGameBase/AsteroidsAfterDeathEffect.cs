using System.Collections.ObjectModel;
using System.Numerics;


namespace MK.AsteroidsGame
{
    public class AsteroidsAfterDeathEffect : IRealtime
    {
        private ReadOnlyCollection<IUnit> _asteroids;
        private Units _units;
        private Settings _settings;
        private Utils _utils;

        public AsteroidsAfterDeathEffect(Settings settings, Units units, Utils utils)
        {
            _asteroids = units.GetCollection(UnitType.Asteroid);
            _units = units;
            _settings = settings;
            _utils = utils;
        }
        public void Update(float deltaTime)
        {
            foreach (var asteroid in _asteroids)
            {
                if (asteroid.MustBeDestroyed)
                {
                    CreateAsteroidPart(asteroid.Position);
                }
            }
        }
        private void CreateAsteroidPart(Vector2 position)
        {
            var part = _units.CreateUnit(UnitType.AsteroidPart);
            part.Position = position;
            part.Velocity = _utils.GetRandomDir() * _settings.AsteroidPartSpeed;
        }
    }
}
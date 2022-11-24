using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace MK.AsteroidsGame
{
    public class ScoreCalculator : IRealtime
    {
        private RealtimeGameData _gameData;
        private IEnumerable<IUnit> _dyingAsteroids;
        private IEnumerable<IUnit> _dyingAsteroidParts;
        private IEnumerable<IUnit> _dyingSaucers;
        private Settings _settings;

        public ScoreCalculator(Settings settings, Units units, RealtimeGameData gameData)
        {

            _dyingAsteroids = units.GetCollection(UnitType.Asteroid).Where(x=> x.MustBeDestroyed);
            _dyingAsteroidParts = units.GetCollection(UnitType.AsteroidPart).Where(x => x.MustBeDestroyed);
            _dyingSaucers = units.GetCollection(UnitType.Saucer).Where(x => x.MustBeDestroyed);
            _settings = settings;
            _gameData = gameData;
        }

        public void Update(float deltaTime)
        {
            _gameData.Score += _dyingAsteroids.Count() * _settings.AsteroidScore;
            _gameData.Score += _dyingAsteroidParts.Count() * _settings.AsteroidPartScore;
            _gameData.Score += _dyingSaucers.Count() * _settings.SaucerScore;
        }
    }
}
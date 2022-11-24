using System.Collections.Generic;
using System.Linq;


namespace MK.AsteroidsGame
{
    public class ScoreCalculator : IRealtime
    {
        private IEnumerable<IUnit> _dyingEnemies;
        private RealtimeGameData _gameData;

        public ScoreCalculator(Units units, RealtimeGameData gameData, IUI ui)
        {

            _dyingEnemies = units.EnemyUnits.Where(x => x.MustBeDestroyed);
            _gameData = gameData;
        }



        public void Update(float deltaTime)
        {
            _gameData.Score += _dyingEnemies.Count();
        }
    }
}
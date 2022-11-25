using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace MK.Asteroids
{
    public class PlayerCollisions : IRealtime
    {
        private IEnumerable<IUnit> _enemies;
        private Units _units;
        private Utils _utils;

        public PlayerCollisions(Units units, Utils utils)
        {
            _units = units;
            _utils = utils;
            _enemies = units.EnemyUnits.Where(x => !x.MustBeDestroyed);
        }

        public void Update(float deltaTime)
        {
            foreach (var enemy in _enemies)
            {
                if (_utils.CheckCollision(_units.Player, enemy))
                {
                    _units.Player.MustBeDestroyed = true;
                    return;
                }
            }
        }
    }
}
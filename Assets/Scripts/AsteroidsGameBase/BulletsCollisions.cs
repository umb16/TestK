using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace MK.AsteroidsGame
{
    public class BulletsCollisions : IRealtime
    {
        private readonly IEnumerable<IUnit> _enemies;
        private readonly Utils _utils;
        private readonly IEnumerable<IUnit> _bullets;

        public BulletsCollisions(Units units, Utils utils)
        {
            _utils = utils;
            _enemies = units.EnemyUnits.Where(x => !x.MustBeDestroyed);
            _bullets = units.GetCollection(UnitType.Bullet).Where(x => !x.MustBeDestroyed);
        }

        public void Update(float deltaTime)
        {
            foreach (var bullet in _bullets)
            {
                foreach (var enemy in _enemies)
                {
                    _utils.CheckCollision(bullet, enemy);
                    bullet.MustBeDestroyed = true;
                    enemy.MustBeDestroyed = true;
                }
            }
        }
    }
}
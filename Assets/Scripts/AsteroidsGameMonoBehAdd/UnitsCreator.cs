using MK.Pooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.AsteroidsGame
{
    public class UnitsCreator : IUnitsCreator
    {
        private Dictionary<UnitType, SimplePool<Unit>> _pools = new Dictionary<UnitType, SimplePool<Unit>>();
        public UnitsCreator( GameObject playerShip, GameObject asteroid, GameObject asteroidPart, GameObject saucer, GameObject bullet)
        {
            _pools.Add(UnitType.PlayerShip, new SimplePool<Unit>(new Unit(playerShip)));
            _pools.Add(UnitType.Asteroid, new SimplePool<Unit>(new Unit(asteroid)));
            _pools.Add(UnitType.AsteroidPart, new SimplePool<Unit>(new Unit(asteroidPart)));
            _pools.Add(UnitType.Saucer, new SimplePool<Unit>(new Unit(saucer)));
            _pools.Add(UnitType.Bullet, new SimplePool<Unit>(new Unit(bullet)));
        }
        public IUnit Create(UnitType type)
        {
            return _pools[type].GetItem();
        }
    }
}

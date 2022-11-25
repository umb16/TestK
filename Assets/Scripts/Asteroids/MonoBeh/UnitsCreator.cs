using MK.Pooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Asteroids.MonoBeh
{
    public class UnitsCreator : IUnitsCreator
    {
        private Dictionary<UnitType, SimplePool<Unit>> _pools = new Dictionary<UnitType, SimplePool<Unit>>();
        public UnitsCreator( GameObject playerShip, GameObject asteroid, GameObject asteroidPart, GameObject saucer, GameObject bullet)
        {
            _pools.Add(UnitType.PlayerShip, new SimplePool<Unit>(new Unit(playerShip,.20f)));
            _pools.Add(UnitType.Asteroid, new SimplePool<Unit>(new Unit(asteroid,.5f)));
            _pools.Add(UnitType.AsteroidPart, new SimplePool<Unit>(new Unit(asteroidPart,.25f)));
            _pools.Add(UnitType.Saucer, new SimplePool<Unit>(new Unit(saucer,.5f)));
            _pools.Add(UnitType.Bullet, new SimplePool<Unit>(new Unit(bullet,.01f)));
        }
        public IUnit Create(UnitType type)
        {
            return _pools[type].GetItem();
        }
    }
}

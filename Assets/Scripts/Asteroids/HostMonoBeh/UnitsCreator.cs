using MK.Pooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Asteroids.HostMonoBeh
{
    public class UnitsCreator : IUnitsCreator
    {
        private Dictionary<UnitType, SimplePool<Unit>> _pools = new Dictionary<UnitType, SimplePool<Unit>>();
        public UnitsCreator( GameObject playerShip, GameObject asteroid, GameObject asteroidPart, GameObject saucer, GameObject bullet, Settings settings)
        {
            _pools.Add(UnitType.PlayerShip, new SimplePool<Unit>(new Unit(playerShip, settings.PlayerSize)));
            _pools.Add(UnitType.Asteroid, new SimplePool<Unit>(new Unit(asteroid, settings.AsteroidSize)));
            _pools.Add(UnitType.AsteroidPart, new SimplePool<Unit>(new Unit(asteroidPart, settings.AsteroidPartSize)));
            _pools.Add(UnitType.Saucer, new SimplePool<Unit>(new Unit(saucer, settings.SaucerSize)));
            _pools.Add(UnitType.Bullet, new SimplePool<Unit>(new Unit(bullet, settings.BulletSize)));
        }
        public IUnit Create(UnitType type)
        {
            return _pools[type].GetItem();
        }
    }
}

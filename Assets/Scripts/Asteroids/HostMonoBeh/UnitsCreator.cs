using MK.Pooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Asteroids.HostMonoBeh
{
    public class UnitsCreator : IUnitsCreator
    {
        private const float PLAYER_RADIUS = .20f;
        private const float ASTEROID_RADIUS = .5f;
        private const float ASTEROID_PART_RADIUS = .25f;
        private const float SAUCER_RADIUS = .5f;
        private const float BULLET_RADIUS = .025f;

        private Dictionary<UnitType, SimplePool<Unit>> _pools = new Dictionary<UnitType, SimplePool<Unit>>();
        public UnitsCreator( GameObject playerShip, GameObject asteroid, GameObject asteroidPart, GameObject saucer, GameObject bullet)
        {
            _pools.Add(UnitType.PlayerShip, new SimplePool<Unit>(new Unit(playerShip, PLAYER_RADIUS)));
            _pools.Add(UnitType.Asteroid, new SimplePool<Unit>(new Unit(asteroid, ASTEROID_RADIUS)));
            _pools.Add(UnitType.AsteroidPart, new SimplePool<Unit>(new Unit(asteroidPart, ASTEROID_PART_RADIUS)));
            _pools.Add(UnitType.Saucer, new SimplePool<Unit>(new Unit(saucer, SAUCER_RADIUS)));
            _pools.Add(UnitType.Bullet, new SimplePool<Unit>(new Unit(bullet, BULLET_RADIUS)));
        }
        public IUnit Create(UnitType type)
        {
            return _pools[type].GetItem();
        }
    }
}

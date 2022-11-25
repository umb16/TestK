

using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine.Playables;

namespace MK.Asteroids
{
    public class PlayerRayFire : IRealtime
    {
        private const float BULLETS_RAY_STEP = .2f;
        private const float BULLETS_RAY_CLEAR_DELAY = .1f;
        private Settings _settings;
        private Units _units;
        private IControlStates _controlStates;
        private RealtimeGameData _gameData;
        private float _maxDistance;
        private List<IUnit> _bullets = new List<IUnit>();
        float _timeSinceLastShot;

        public PlayerRayFire(Settings settings, Units units, IControlStates controlStates, RealtimeGameData gameData)
        {
            _settings = settings;
            _units = units;
            _controlStates = controlStates;
            _gameData = gameData;
            _maxDistance = settings.ScreenSize.Length();
        }
        public void Update(float deltaTime)
        {
            TryDestroyBulletsRayByTime(deltaTime);

            if (_gameData.RayAmmunitionCount < _settings.MaxRayAmmunition)
            {
                _gameData.RayAmmunitionCount += deltaTime * _settings.RayCooldownFactor;
                if (_gameData.RayAmmunitionCount > _settings.MaxRayAmmunition)
                    _gameData.RayAmmunitionCount = _settings.MaxRayAmmunition;
            }

            if (_controlStates.FireRay && _gameData.RayAmmunitionCount >= 1)
            {
                _gameData.RayAmmunitionCount--;
                BulletsRayClear();
                RayAttack();
                _timeSinceLastShot = 0;
            }
        }

        private void TryDestroyBulletsRayByTime(float deltaTime)
        {
            if (_timeSinceLastShot < BULLETS_RAY_CLEAR_DELAY)
            {
                _timeSinceLastShot += deltaTime;
                if (_timeSinceLastShot >= BULLETS_RAY_CLEAR_DELAY)
                    BulletsRayClear();
            }
        }

        private void BulletsRayClear()
        {
            for (int i = 0; i < _bullets.Count; i++)
            {
                _bullets[i].Destroy();

            }
            _bullets.Clear();
        }

        private void RayAttack()
        {
            Vector2 dir = GetPlayerDir();
            var start = _units.Player.Position + dir * _units.Player.Radius;
            var end = start + dir * _maxDistance;

            BulletsRayCreate(dir, start, BULLETS_RAY_STEP);

            foreach (var enemy in _units.EnemyUnits)
            {
                if (RayIntersectEnemy(start, end, enemy))
                    enemy.MustBeDestroyed = true;
            }
        }

        private bool RayIntersectEnemy(Vector2 start, Vector2 end, IUnit enemy)
        {
            var point1 = start - enemy.Position;
            var point2 = end - enemy.Position;
            (float a, float b, float c) = ConvertToABC(point1, point2);
            var r = enemy.Radius;
            return c * c <= r * r * (a * a + b * b);
        }

        private void BulletsRayCreate(Vector2 dir, Vector2 start, float step)
        {
            for (float i = 0; i < _maxDistance; i += step)
            {
                var bullet = _units.CreateRawUnit(UnitType.Bullet);
                bullet.Position = start + dir * i;
                _bullets.Add(bullet);
            }
        }

        private Vector2 GetPlayerDir()
        {
            return new Vector2(MathF.Sin(_units.Player.Angle), MathF.Cos(_units.Player.Angle));
        }
        private (float a, float b, float c) ConvertToABC(Vector2 p1, Vector2 p2)
        {
            return (p1.Y - p2.Y,
                p2.X - p1.X,
                p1.X * p2.Y - p2.X * p1.Y);
        }
    }
}
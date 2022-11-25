

using System;
using System.Numerics;

namespace MK.Asteroids
{
    public class PlayerBulletFire : IRealtime
    {
        private const float FIRE_DELAY = .4f; 
        private Settings _settings;
        private Units _units;
        private IControlStates _controlStates;
        float _timeSinceLastShot;

        public PlayerBulletFire(Settings settings, Units units, IControlStates controlStates)
        {
            _settings = settings;
            _units = units;
            _controlStates = controlStates;
        }
        public void Update(float deltaTime)
        {
            _timeSinceLastShot += deltaTime;
            if (_controlStates.FireBullet)
            {
                if (_timeSinceLastShot > FIRE_DELAY)
                {
                    CreateBullet();
                    _timeSinceLastShot = 0;
                }
            }
        }
        private void CreateBullet()
        {
            var part = _units.CreateUnit(UnitType.Bullet);
            var dir = new Vector2(MathF.Sin(_units.Player.Angle), MathF.Cos(_units.Player.Angle));
            part.Position = _units.Player.Position + dir * _units.Player.Radius;
            part.Velocity = dir * _settings.BulletSpeed;
        }

    }
}
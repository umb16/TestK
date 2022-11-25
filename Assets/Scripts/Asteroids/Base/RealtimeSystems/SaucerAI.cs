
using System;
using System.Collections.ObjectModel;
using System.Numerics;


namespace MK.Asteroids
{
    public class SaucerAI : IRealtime
    {
        private Settings _settings;
        private Units _units;
        private ReadOnlyCollection<IUnit> _saucers;
        public SaucerAI(Settings settings, Units units)
        {
            _settings = settings;
            _units = units;
            _saucers = units.GetCollection(UnitType.Saucer);
        }
        public void Update(float deltaTime)
        {
            foreach (var sauser in _saucers)
            {
                sauser.Velocity = Vector2.Normalize(_units.Player.Position - sauser.Position) * _settings.SaucerSpeed * deltaTime + sauser.Velocity * MathF.Max(0, (1 - deltaTime));
            }
        }
    }
}
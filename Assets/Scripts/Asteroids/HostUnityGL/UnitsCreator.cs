using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MK.Asteroids.HostUnityGL
{
    public class UnitsCreator : IUnitsCreator
    {
        private Settings _settings;

        public ReadOnlyCollection<Unit> Units { get; }
        private List<Unit> _units = new();
        public UnitsCreator(Settings settings)
        {
            _settings = settings;
            Units = new ReadOnlyCollection<Unit>(_units);
        }
        public IUnit Create(UnitType type)
        {
            float radius = 1;
            switch (type)
            {
                case UnitType.Asteroid:
                    radius = _settings.AsteroidSize;
                    break;
                case UnitType.AsteroidPart:
                    radius = _settings.AsteroidPartSize;
                    break;
                case UnitType.Bullet:
                    radius = _settings.BulletSize;
                    break;
                case UnitType.Saucer:
                    radius = _settings.SaucerSize;
                    break;
                case UnitType.PlayerShip:
                    radius = _settings.PlayerSize;
                    break;
                default:
                    return null;
            }

            Unit unit = new(type, radius);
            _units.Add(unit);
            unit.DestroyAction = () => _units.Remove(unit);
            return unit;
        }

    }
}

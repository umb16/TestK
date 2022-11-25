using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MK.Asteroids.HostUnityGL
{
    public class UnitsCreator : IUnitsCreator
    {
        private const float PLAYER_RADIUS = .20f;
        private const float ASTEROID_RADIUS = .5f;
        private const float ASTEROID_PART_RADIUS = .25f;
        private const float SAUCER_RADIUS = .5f;
        private const float BULLET_RADIUS = .025f;
        public ReadOnlyCollection<Unit> Units { get; }
        private List<Unit> _units = new();
        public UnitsCreator()
        {
            Units = new ReadOnlyCollection<Unit>(_units);
        }
        public IUnit Create(UnitType type)
        {
            float radius = 1;
            switch (type)
            {
                case UnitType.Asteroid:
                    radius = ASTEROID_RADIUS;
                    break;
                case UnitType.AsteroidPart:
                    radius = ASTEROID_PART_RADIUS;
                    break;
                case UnitType.Bullet:
                    radius = BULLET_RADIUS;
                    break;
                case UnitType.Saucer:
                    radius = SAUCER_RADIUS;
                    break;
                case UnitType.PlayerShip:
                    radius = PLAYER_RADIUS;
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

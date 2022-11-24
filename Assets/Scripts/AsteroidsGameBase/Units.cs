using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace MK.AsteroidsGame
{
    public class Units
    {
        private IUnitsCreator _unitsCreator;

        private Dictionary<UnitType, List<IUnit>> _units = new Dictionary<UnitType, List<IUnit>>();
        public IEnumerable<IUnit> AllUnits { get; private set; }
        public IEnumerable<IUnit> DangerousUnits { get; private set; }

        public IUnit Player => _units[UnitType.PlayerShip].FirstOrDefault();

        public Units(IUnitsCreator unitsCreator)
        {
            _unitsCreator = unitsCreator;

            foreach (UnitType unitType in Enum.GetValues(typeof(UnitType)))
            {
                _units.Add(unitType, new List<IUnit>());
            }

            AllUnits = _units.Values.Aggregate<IEnumerable<IUnit>>((accum, x) => accum.Union(x));

            DangerousUnits = _units[UnitType.Asteroid]
                .Union(_units[UnitType.AsteroidPart])
                .Union(_units[UnitType.Saucer]);
        }
        public int GetCount(UnitType unitType)
        {
            return _units[unitType].Count;
        }
        public ReadOnlyCollection<IUnit> GetCollection(UnitType unitType)
        {
            return new ReadOnlyCollection<IUnit>(_units[unitType]);
        }
        public void Clear()
        {
            foreach (var unit in AllUnits)
            {
                unit.Destroy();
            }
            foreach (var unitsList in _units.Values)
            {
                unitsList.Clear();
            }
        }

        public IUnit CreateUnit(UnitType unitType)
        {
            var newUnit = _unitsCreator.Create(unitType);
            _units[unitType].Add(newUnit);
            return newUnit;
        }

        public void DestroyUnit(UnitType unitType, IUnit unit)
        {
            _units[unitType].Remove(unit);
            unit.Destroy();
        }
    }
}
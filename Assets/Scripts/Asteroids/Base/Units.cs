using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace MK.Asteroids
{
    public class Units
    {
        private IUnitsCreator _unitsCreator;

        private Dictionary<UnitType, List<IUnit>> _units = new Dictionary<UnitType, List<IUnit>>();
        public IEnumerable<IUnit> AllUnits { get; private set; }
        public IEnumerable<IUnit> EnemyUnits { get; private set; }

        public IUnit Player => _units[UnitType.PlayerShip].FirstOrDefault();

        public Units(IUnitsCreator unitsCreator)
        {
            _unitsCreator = unitsCreator;

            foreach (UnitType unitType in Enum.GetValues(typeof(UnitType)))
            {
                _units.Add(unitType, new List<IUnit>());
            }

            AllUnits = _units.Values.Aggregate<IEnumerable<IUnit>>((accum, x) => accum.Union(x));

            EnemyUnits = _units[UnitType.Asteroid]
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
        public IUnit CreateRawUnit(UnitType unitType)
        {
            return _unitsCreator.Create(unitType);
        }
        public void RemoveDestroyedUnits()
        {
            foreach (var pair in _units)
            {
                for (int i = 0; i < pair.Value.Count;)
                {
                    if (pair.Value[i].MustBeDestroyed)
                    {
                        pair.Value[i].Destroy();
                        pair.Value.RemoveAt(i);
                        continue;
                    }
                    i++;
                }
            }
        }
    }
}
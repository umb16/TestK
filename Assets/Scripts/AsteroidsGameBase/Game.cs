using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine.UIElements;

namespace MK.AsteroidsGame
{
    public class Game
    {
        private Random _random = new Random();
        private IUnitsCreator _unitsCreator;
        private IControlStates _controlStates;
        private IUI _ui;
        private Vector2 _size;
        private Dictionary<UnitType, List<IUnit>> _units = new Dictionary<UnitType, List<IUnit>>();
        private IEnumerable<IUnit> _allUnits;

        private IUnit FirstPlayer => _units[UnitType.PlayerShip][0];

        public Game(IUnitsCreator unitsCreator, IControlStates controlStates, IUI ui, Vector2 size)
        {
            _unitsCreator = unitsCreator;
            _controlStates = controlStates;
            _ui = ui;
            _size = size;
            foreach (UnitType unitType in Enum.GetValues(typeof(UnitType)))
            {
                _units.Add(unitType, new List<IUnit>());
            }
            _allUnits = _units.Values.Aggregate<IEnumerable<IUnit>>((accum, x) => accum.Union(x));
        }

        public void Update(float deltaTime)
        {

        }

        private void Start()
        {
            CreateUnit(UnitType.PlayerShip);

            for (int i = 0; i < 3; i++)
            {
                CreateAsteroid();
            }
            for (int i = 0; i < 2; i++)
            {
                CreateSaucer();
            }
        }

        private void MoveUnits(float deltaTime)
        {
            foreach (var unit in _allUnits)
            {
                unit.Position += unit.Velocity * deltaTime;
            }
        }

        private void CreateAsteroid()
        {
            var asteroid = CreateUnit(UnitType.Asteroid);
            asteroid.Position = GetRandomSafePointAroundPlayer();
            asteroid.Velocity = GetRandomDir();
        }

        private void CreateAsteroidPart(Vector2 position)
        {
            var part = CreateUnit(UnitType.AsteroidPart);
            part.Position = position;
            part.Velocity = GetRandomDir() * 2;
        }

        private void CreateSaucer()
        {
            var asteroid = CreateUnit(UnitType.Saucer);
            asteroid.Position = GetRandomSafePointAroundPlayer();
        }

        private IUnit CreateUnit(UnitType unitType)
        {
            var newUnit = _unitsCreator.Create(unitType);
            _units[unitType].Add(newUnit);
            return newUnit;
        }

        private void DestroyUnit(UnitType unitType, IUnit unit)
        {
            _units[unitType].Remove(unit);
            unit.Destroy();
        }

        private Vector2 GetRandomSafePointAroundPlayer()
        {
            var point = new Vector2((float)(_random.NextDouble() - .5) * _size.X, (float)(_random.NextDouble() - .5) * _size.Y);
            if ((FirstPlayer.Position - point).Length() < FirstPlayer.Radius * 2)
                return point + GetRandomDir() * 2;
            return point;

        }
        private Vector2 GetRandomDir()
        {
            float random = (float)_random.NextDouble();
            return new Vector2(MathF.Cos(random), MathF.Sin(random));
        }
    }
}
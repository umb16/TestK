using System.Collections.Generic;
using System.Linq;

namespace MK.Asteroids
{
    public class RotateAsteroids : IRealtime
    {
        private IEnumerable<IUnit> _asteroids;

        public RotateAsteroids(Units units)
        {
            _asteroids = units.GetCollection(UnitType.Asteroid).Union(units.GetCollection(UnitType.AsteroidPart));
        }
        public void Update(float deltaTime)
        {
            foreach (var asteroid in _asteroids)
            {
                if (asteroid.Velocity.X + asteroid.Velocity.Y < 0)
                    asteroid.Angle += asteroid.Velocity.Length() * deltaTime;
                else
                    asteroid.Angle -= asteroid.Velocity.Length() * deltaTime;
            }
        }
    }
    public class Game
    {
        private IUnitsCreator _unitsCreator;
        private IControlStates _controlStates;
        private RealtimeGameData _gameData;
        private IUI _ui;
        private Settings _settings;
        private Utils _utils;
        private Units _units;

        private IRealtime[] _realTimeSystems;

        public Game(IUnitsCreator unitsCreator, IControlStates controlStates, IUI ui, Settings settings)
        {
            _units = new Units(unitsCreator);
            _controlStates = controlStates;
            _ui = ui;
            _settings = settings;
            _utils = new Utils(settings, _units);
            _gameData = new RealtimeGameData(_settings.MaxRayAmmunition);
            Start();
            _realTimeSystems = new IRealtime[]
            {
                new EnemiesSpawner(settings, _units, _utils, _gameData),
                new SaucerAI(settings, _units),
                new BulletsCollisions(_units, _utils),
                new PlayerCollisions(_units, _utils),
                new MoveUnits(settings, _units),
                new RotateAsteroids(_units),
                new PlayerBulletFire(settings, _units, controlStates),
                new PlayerRayFire(settings, _units, controlStates, _gameData),
                new PlayerMovement(settings, _units, controlStates),
                new ScoreCalculator(settings, _units, _gameData),
                new AsteroidsAfterDeathEffect(settings, _units, _utils),
                new GameOverChecker(_units, _gameData, ui),
                new PlayerUIUpdater(_units, ui, _gameData, settings)
            };
        }

        public void Update(float deltaTime)
        {
            if (_gameData.GameIsOver)
            {
                if (_controlStates.Restart)
                {
                    Restart();
                }
                return;
            }
            foreach (var sys in _realTimeSystems)
            {
                sys.Update(deltaTime);
            }
            _units.RemoveDestroyedUnits();
        }

        private void Restart()
        {
            _units.Clear();
            Start();
        }

        private void Start()
        {
            _gameData.Reset();
            _ui.HideGameOver();
            _units.CreateUnit(UnitType.PlayerShip);
        }
    }
}
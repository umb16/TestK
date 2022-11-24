using System.Collections.ObjectModel;
using UnityEngine.Diagnostics;
using UnityEngine.Rendering.VirtualTexturing;
using static UnityEngine.UI.CanvasScaler;


namespace MK.AsteroidsGame
{
    public class Game
    {
        private IUnitsCreator _unitsCreator;
        private IControlStates _controlStates;
        private RealtimeGameData _gameData = new RealtimeGameData();
        private IUI _ui;
        private Settings _settings;
        private Utils _utils;
        private int _score = 0;
        private bool _gameIsOver = false;
        private Units _units;

        private IRealtime[] _realTimeSystems;

        public Game(IUnitsCreator unitsCreator, IControlStates controlStates, IUI ui, Settings settings)
        {
            _units = new Units(unitsCreator);
            _controlStates = controlStates;
            _ui = ui;
            _settings = settings;
            _utils = new Utils(settings, _units);
            _realTimeSystems = new IRealtime[]
            {
                new Spawner(settings, _units, _utils),
                new SaucerAI(settings, _units),
                new MoveUnits(settings, _units),
                new BulletsCollisions(_units, _utils),
                new ScoreCalculator(_units, _gameData, ui),
                new AsteroidsAfterDeathEffect(settings, _units, _utils)
            };
            Start();
        }

        public void Update(float deltaTime)
        {
            if (_gameIsOver)
            {
                if (_controlStates.FireBullet)
                {
                    Restart();
                }
                return;
            }
            _gameIsOver = CheckGameOver();
            foreach (var sys in _realTimeSystems)
            {
                sys.Update(deltaTime);
            }
            _units.RemoveDestroyedUnits();
        }

        private void Restart()
        {
            _units.Clear();
            _score = 0;
            Start();
        }

        private void Start()
        {
            _gameIsOver = false;
            _units.CreateUnit(UnitType.PlayerShip);
        }

        private bool CheckGameOver()
        {
            foreach (var unit in _units.EnemyUnits)
            {
                if (_utils.CheckCollision(_units.Player, unit))
                {
                    _gameIsOver = true;
                    _units.Player.Destroy();
                    return true;
                }
            }
            return false;
        }
    }
}
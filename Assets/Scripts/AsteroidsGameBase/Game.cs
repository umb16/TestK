using System.Collections.ObjectModel;
using UnityEngine.Diagnostics;
using UnityEngine.Playables;
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
                new BulletsCollisions(_units, _utils),
                new PlayerCollisions(_units, _utils),
                new MoveUnits(settings, _units),
                new ScoreCalculator(settings, _units, _gameData),
                new AsteroidsAfterDeathEffect(settings, _units, _utils),
                new GameOverChecker(_units, _gameData, ui),
                new UIUpdater(_units, ui, _gameData)
            };
            Start();
        }

        public void Update(float deltaTime)
        {
            if (_gameData.GameIsOver)
            {
                if (_controlStates.FireBullet)
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
            _score = 0;
            Start();
        }

        private void Start()
        {
            _ui.HideGameOver();
            _gameData.GameIsOver = false;
            _units.CreateUnit(UnitType.PlayerShip);
        }
    }
}
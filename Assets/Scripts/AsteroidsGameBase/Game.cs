using static UnityEngine.UI.CanvasScaler;


namespace MK.AsteroidsGame
{
    public class Game
    {
        private IUnitsCreator _unitsCreator;
        private IControlStates _controlStates;
        private IUIEvents _ui;
        private Settings _settings;
        private Utils _utils;
        private Spawner _spawner;
        private SaucerAI _saucerAI;
        private MoveUnits _moveUnits;
        private int _score = 0;
        private bool _gameIsOver = false;

        private Units _units;

        public Game(IUnitsCreator unitsCreator, IControlStates controlStates, IUIEvents ui, Settings settings)
        {
            _units = new Units(unitsCreator);
            _controlStates = controlStates;
            _ui = ui;
            _settings = settings;
            _utils = new Utils(settings, _units);
            _spawner = new Spawner(settings, _units, _utils);
            _saucerAI = new SaucerAI(settings, _units);
            _moveUnits = new MoveUnits(settings, _units);
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
            _spawner.Update(deltaTime);
            _saucerAI.Update(deltaTime);
            _moveUnits.Update(deltaTime);
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
            foreach (var unit in _units.DangerousUnits)
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
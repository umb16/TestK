namespace MK.Asteroids
{
    public class GameOverChecker : IRealtime
    {
        private Units _units;
        private RealtimeGameData _gameData;
        private IUI _ui;

        public GameOverChecker(Units units, RealtimeGameData gameData, IUI ui)
        {
            _units = units;
            _gameData = gameData;
            _ui = ui;
        }

        public void Update(float deltaTime)
        {
            if (_units.Player.MustBeDestroyed)
            {
                _gameData.GameIsOver = true;
                _ui.ShowGameOver(_gameData.Score);
            }
        }
    }
}
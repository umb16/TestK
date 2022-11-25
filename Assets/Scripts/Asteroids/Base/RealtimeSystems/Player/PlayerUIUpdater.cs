using System;

namespace MK.Asteroids
{
    public class PlayerUIUpdater : IRealtime
    {
        private IUI _ui;
        private Units _units;
        private RealtimeGameData _gameData;
        private Settings _settings;

        public PlayerUIUpdater(Units units, IUI ui, RealtimeGameData gameData, Settings settings)
        {
            _ui = ui;
            _units = units;
            _gameData = gameData;
            _settings = settings;
        }

        public void Update(float deltaTime)
        {
            _ui.SetScore(_gameData.Score);
            _ui.SetCoords(_units.Player.Position);
            _ui.SetAngle(_units.Player.Angle * 57.29578f);
            _ui.SetSpeed(_units.Player.Velocity.Length());
            if (_gameData.RayAmmunitionCount == _settings.MaxRayAmmunition)
                _ui.SetRayCooldown(0);
            else
                _ui.SetRayCooldown((1 - _gameData.RayAmmunitionCount % 1));
            _ui.SetRayAmmunitionCount((int)_gameData.RayAmmunitionCount);
        }
    }
}
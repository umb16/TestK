using System;

namespace MK.Asteroids
{
    public class PlayerUIUpdater : IRealtime
    {
        private IUI _ui;
        private Units _units;
        private RealtimeGameData _gameData;

        public PlayerUIUpdater(Units units, IUI ui, RealtimeGameData gameData)
        {
            _ui = ui;
            _units = units;
            _gameData = gameData;
        }

        public void Update(float deltaTime)
        {
            _ui.SetScore(_gameData.Score);
            _ui.SetCoords(_units.Player.Position);
            _ui.SetAngle(_units.Player.Angle* 57.29578f);
            _ui.SetSpeed(_units.Player.Velocity.Length());
            _ui.SetRayCooldown(_gameData.RayCooldown);
            _ui.SetRayAmmunitionCount(_gameData.RayAmmunitionCount);
        }
    }
}
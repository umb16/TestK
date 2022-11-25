using System;
using System.Numerics;

namespace MK.Asteroids
{
    public class PlayerMovement : IRealtime
    {
        private readonly Settings _settings;
        private readonly Units _units;
        private IControlStates _controlStates;

        public PlayerMovement(Settings settings, Units units, IControlStates controlStates)
        {
            _settings = settings;
            _units = units;
            _controlStates = controlStates;
        }
        public void Update(float deltaTime)
        {
            if (_controlStates.Rotate != 0)
            {
                _units.Player.Angle += _controlStates.Rotate * deltaTime * 5;
                if (_units.Player.Angle < 0)
                {
                    _units.Player.Angle = MathF.PI * 2 - _units.Player.Angle;
                }
                else
                {
                    _units.Player.Angle %= MathF.PI * 2;
                }
            }
            if (_controlStates.Accelerate)
            {
                _units.Player.Velocity += new Vector2(MathF.Sin(_units.Player.Angle), MathF.Cos(_units.Player.Angle)) * deltaTime;
            }
        }
    }
}
using System.Linq;
using System.Numerics;


namespace MK.Asteroids
{
    public class MoveUnits : IRealtime
    {
        private Settings _settings;
        private Units _units;

        public MoveUnits(Settings settings, Units units)
        {
            _settings = settings;
            _units = units;
        }

        public void Update(float deltaTime)
        {
            float x = _settings.ScreenSize.X;
            float y = _settings.ScreenSize.Y;

            foreach (var unit in _units.AllUnits)
            {
                Vector2 newPos = unit.Position + unit.Velocity * deltaTime * _settings.SpeedFactor;
                if (newPos.X - unit.Radius > x * .5f)
                {
                    newPos.X = -x * .5f - unit.Radius;
                }
                else if (newPos.X + unit.Radius < -x * .5f)
                {
                    newPos.X = x * .5f + unit.Radius;
                }
                if (newPos.Y - unit.Radius > y * .5f)
                {
                    newPos.Y = -y * .5f - unit.Radius;
                }
                else if (newPos.Y + unit.Radius < -y * .5f)
                {
                    newPos.Y = y * .5f + unit.Radius;
                }
                unit.Position = newPos;
            }
        }
    }
}
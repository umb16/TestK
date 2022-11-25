

using System.Numerics;

namespace MK.Asteroids
{
    public interface IUI
    {
        void SetScore(int score);
        void SetCoords(Vector2 coords);
        void SetAngle(float value);
        void SetSpeed(float value);
        void SetRayAmmunitionCount(int value);
        void SetRayCooldown(float value);
        void ShowGameOver(int score);
        void HideGameOver();
    }
}
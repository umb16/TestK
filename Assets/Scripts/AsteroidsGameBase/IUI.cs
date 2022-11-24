

using System.Numerics;

namespace MK.AsteroidsGame
{
    public interface IUI
    {
        void SetScore(int score);
        void SetCoords(Vector2 coords);
        void SetAngle(float value);
        void SetSpeed(float value);
        void SetRayAmmunitionCount(float value);
        void SetRayCooldown(float value);
        void ShowGameOver(int score);
        void HideGameOver();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Asteroids.UnityUI
{
    public class UIAsteroids : MonoBehaviour, IUI
    {
        [SerializeField] private UIValueText _gameOver;
        [SerializeField] private UIValueText _score;
        [SerializeField] private UIValueText _shipAngle;
        [SerializeField] private UIValueText _shipSpeed;
        [SerializeField] private UIValueText _shipX;
        [SerializeField] private UIValueText _shipY;
        [SerializeField] private UIValueText _rayAmmunition;
        [SerializeField] private UIValueText _rayCooldown;

        public void SetScore(int score) => _score.SetValue(score);
        public void SetAngle(float value) => _shipAngle.SetValue(value);
        public void SetSpeed(float value) => _shipSpeed.SetValue(value);
        public void SetCoords(System.Numerics.Vector2 coords)
        {
            _shipX.SetValue(coords.X);
            _shipY.SetValue(coords.Y);
        }

        public void SetRayAmmunitionCount(int value) => _rayAmmunition.SetValue(value);
        public void SetRayCooldown(float value) => _rayCooldown.SetValue(value);
        public void ShowGameOver(int score) => _gameOver.Show(score);
        public void HideGameOver() => _gameOver.Hide();
    }
}

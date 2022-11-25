using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MK.Asteroids.UnityInput
{
    public class ControlStates : IControlStates
    {
        private PlayerInputActions _playerInputActions;

        public ControlStates(PlayerInputActions playerInputActions)
        {
            _playerInputActions = playerInputActions;
        }
        public bool Accelerate => _playerInputActions.Player.Accelerate.IsPressed();

        public float Rotate => _playerInputActions.Player.Rotate.ReadValue<float>();

        public bool FireBullet => _playerInputActions.Player.FireBullet.IsPressed();

        public bool FireRay => _playerInputActions.Player.FireRay.triggered;
    }
}
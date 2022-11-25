
using MK.Pooling;
using System;
using UnityEngine;

namespace MK.Asteroids
{
    public class Unit : IUnit, IPoolObject
    {
        private GameObject _gameObject;

        private System.Numerics.Vector2 _position;
        private float _angle;
        public System.Numerics.Vector2 Velocity { get; set; }
        public System.Numerics.Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                _gameObject.transform.position = new Vector3(value.X, value.Y, 0);
            }
        }

        public float Radius { get; }
        public float Angle
        {
            get => _angle;
            set
            {
                _angle = value;
                _gameObject.transform.eulerAngles = new Vector3(0, 0, -_angle * Mathf.Rad2Deg);
            }
        }
        public Action DestroyAction { get; set; }
        public bool MustBeDestroyed { get; set; }

        public Unit(GameObject gameObject, float radius)
        {
            _gameObject = gameObject;
            Radius = radius;
        }

        public void OnOverflowDestroy()
        {
            GameObject.Destroy(_gameObject);
        }

        public IPoolObject CreateNew()
        {
            var obj = new Unit(GameObject.Instantiate(_gameObject), Radius);
            return obj;
        }

        public void Reset()
        {
            Angle = 0;
            Position = System.Numerics.Vector2.Zero;
            Velocity = System.Numerics.Vector2.Zero;
            MustBeDestroyed = false;
        }

        public void SetActive(bool v)
        {
            _gameObject.SetActive(v);
        }

        public void Destroy() => DestroyAction();
    }
}

﻿
using MK.Pooling;
using System;
using UnityEngine;

namespace MK.AsteroidsGame
{
    public class Unit : IUnit, IPoolObject
    {
        private GameObject _gameObject;

        private System.Numerics.Vector2 _position;
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

        public float Radius { get; set; }
        public float Angle { get; set; }
        public Action DestroyAction { get; set; }

        public Unit(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public void OnOverflowDestroy()
        {
            GameObject.Destroy(_gameObject);
        }

        public IPoolObject CreateNew()
        {
            var obj = new Unit(GameObject.Instantiate(_gameObject));
            return obj;
        }

        public void Reset()
        {
            Angle = 0;
            Position = System.Numerics.Vector2.Zero;
            Velocity = System.Numerics.Vector2.Zero;
            Radius = 1;
        }

        public void SetActive(bool v)
        {
            _gameObject.SetActive(v);
        }

        public void Destroy() => DestroyAction();
    }
}

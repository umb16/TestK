using MK.Asteroids.UnityInput;
using MK.Asteroids.UnityUI;
using UnityEngine;
using System.Numerics;
using Vector2 = System.Numerics.Vector2;
using System.Collections.Generic;
using System;
using UnityEngine.UIElements;

namespace MK.Asteroids.HostUnityGL
{
    public class GameHost : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private UIAsteroids _ui;
        [SerializeField] private Material _material;

        private Game _game;
        private UnitsCreator _unitsCreator;

        private Dictionary<UnitType, Vector2[]> _unitsVisuals = new Dictionary<UnitType, Vector2[]>();

        private void Start()
        {
            InitUnitsVisuals();

            var screenSize = new Vector2(_camera.orthographicSize * 2 * _camera.aspect, _camera.orthographicSize * 2);

            Settings settings = new Settings(screenSize, 2,
                saucerSize: .5f,
                asteroidSize: .5f,
                asteroidPartSize: .25f,
                bulletSize: .025f,
                playerSize: .2f);

            _unitsCreator = new UnitsCreator(settings);

            var inputActions = new PlayerInputActions();
            ControlStates controlStates = new ControlStates(inputActions);
            inputActions.Enable();

            _game = new Game(_unitsCreator, controlStates, _ui, settings);
        }

        private void InitUnitsVisuals()
        {
            _unitsVisuals[UnitType.PlayerShip] = new[] { new Vector2(-1, -1), new Vector2(1, -1), new Vector2(0, 1) };
            _unitsVisuals[UnitType.Bullet] = new[] { new Vector2(-1, -1), new Vector2(1, -1), new Vector2(0, 1) };
            _unitsVisuals[UnitType.Asteroid] = new[] { new Vector2(-.9f, 0), new Vector2(0.1f, -.8f), new Vector2(0.4f, -.5f), new Vector2(1, -.2f), new Vector2(1, .5f), new Vector2(.2f, 1) };
            _unitsVisuals[UnitType.AsteroidPart] = new[] { new Vector2(-.9f, 0), new Vector2(0.1f, -.8f), new Vector2(0.4f, -.5f), new Vector2(1, -.2f), new Vector2(1, .5f), new Vector2(.2f, 1) };
            _unitsVisuals[UnitType.Saucer] = new[] { new Vector2(-1, 0), new Vector2(0, -.7f), new Vector2(1, 0), new Vector2(0, .8f) };
        }

        private void Update()
        {
            _game.Update(Time.deltaTime);
        }

        private void OnPostRender()
        {
            _material.SetPass(0);
            foreach (var unit in _unitsCreator.Units)
            {
                DrawUnit(_unitsVisuals[unit.Type], unit.Position, unit.Radius, unit.Angle);
            }
        }

        private void DrawUnit(Vector2[] points, Vector2 pos, float scale, float angle)
        {
            var axisY = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
            var axisX = new Vector2(axisY.Y, -axisY.X);
            GL.Begin(GL.LINE_STRIP);
            for (int i = 0; i <= points.Length; i++)
            {
                var point = points[i % points.Length] * scale;

                point = point.X * axisX + point.Y * axisY+ pos;
                GL.Vertex3(point.X, point.Y, -1);
            }
            GL.End();
        }
    }
}

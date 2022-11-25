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

            _unitsCreator = new UnitsCreator();

            var inputActions = new PlayerInputActions();
            ControlStates controlStates = new ControlStates(inputActions);
            inputActions.Enable();

            var size = new System.Numerics.Vector2(_camera.orthographicSize * 2 * _camera.aspect, _camera.orthographicSize * 2);
            Settings settings = new(size, 2);

            _game = new Game(_unitsCreator, controlStates, _ui, settings);

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
            //GL.PushMatrix();
            // Set transformation matrix for drawing to
            // match our transform
            //GL.MultMatrix(transform.localToWorldMatrix);

            // Draw lines
            /* GL.Begin(GL.LINES);
             for (int i = 0; i < lineCount; ++i)
             {
                 float a = i / (float)lineCount;
                 float angle = a * Mathf.PI * 2;
                 // Vertex colors change from red to green
                 GL.Color(new Color(a, 1 - a, 0, 0.8F));
                 // One vertex at transform position
                 GL.Vertex3(0, 0, 0);
                 // Another vertex at edge of circle
                 GL.Vertex3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, -10);
             }
             GL.End();*/
            //GL.PopMatrix();
            foreach (var unit in _unitsCreator.Units)
            {
                DrawShip(_unitsVisuals[unit.Type], unit.Position, unit.Radius, unit.Angle);
            }
        }

        private void DrawShip(Vector2[] points, Vector2 pos, float scale, float angle)
        {
            var vector2 = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
            var vector = new Vector2(vector2.Y, -vector2.X);
            GL.Begin(GL.LINE_STRIP);
            for (int i = 0; i <= points.Length; i++)
            {
                var point = points[i % points.Length] * scale;

                point = point.X * vector + point.Y * vector2+ pos;
                GL.Vertex3(point.X, point.Y, -1);
            }
            GL.End();
        }

        Vector2 rotate(float angle)
        {
            return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }
    }
}

using MK.Asteroids.UnityInput;
using MK.Asteroids.UnityUI;
using UnityEngine;

namespace MK.Asteroids.HostMonoBeh
{
    public class GameHost : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject shipPrefab;
        [SerializeField] private GameObject asteroidPrefab;
        [SerializeField] private GameObject asteroidPartPrefab;
        [SerializeField] private GameObject saucerPrefab;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private UIAsteroids _ui;

        private Game _game;

        void Start()
        {
            var screenSize = new System.Numerics.Vector2(_camera.orthographicSize * 2 * _camera.aspect, _camera.orthographicSize * 2);

            Settings settings = new Settings(screenSize, 2,
                saucerSize: .5f,
                asteroidSize: .5f,
                asteroidPartSize: .25f,
                bulletSize: .025f,
                playerSize: .2f);

            UnitsCreator unitsCreator = new UnitsCreator(
                shipPrefab,
                asteroidPrefab,
                asteroidPartPrefab,
                saucerPrefab,
                bulletPrefab, settings);

            var inputActions = new PlayerInputActions();
            ControlStates controlStates = new ControlStates(inputActions);
            inputActions.Enable();

            
            

            _game = new Game(unitsCreator, controlStates, _ui, settings);
        }

        void Update()
        {
            _game.Update(Time.deltaTime);
        }
    }
}

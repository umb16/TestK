using MK.AsteroidsGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMonoBeh : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject shipPrefab;
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private GameObject asteroidPartPrefab;
    [SerializeField] private GameObject saucerPrefab;
    [SerializeField] private GameObject bulletPrefab;
    private Game _game;

    void Start()
    {
        UnitsCreator unitsCreator = new UnitsCreator(
            shipPrefab,
            asteroidPrefab,
            asteroidPartPrefab,
            saucerPrefab,
            bulletPrefab);

        var inputActions = new PlayerInputActions();
        ControlStates controlStates = new ControlStates(inputActions);
        inputActions.Enable();

        var size = new System.Numerics.Vector2(_camera.orthographicSize * 2, _camera.orthographicSize * 2 / _camera.aspect);
        Settings settings = new(size);

        _game = new Game(unitsCreator, controlStates, new UIEvents(), settings);
    }

    void Update()
    {
        _game.Update(Time.deltaTime);
    }
}
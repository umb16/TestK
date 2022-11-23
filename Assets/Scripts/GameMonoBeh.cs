using MK.AsteroidsGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMonoBeh : MonoBehaviour
{
    [SerializeField] private GameObject shipPrefab;
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private GameObject asteroidPartPrefab;
    [SerializeField] private GameObject saucerPrefab;
    [SerializeField] private GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        UnitsCreator unitsCreator = new UnitsCreator(
            shipPrefab,
            asteroidPrefab,
            asteroidPartPrefab,
            saucerPrefab,
            bulletPrefab);
        //new Game(unitsCreator,)
    }

    // Update is called once per frame
    void Update()
    {

    }
}

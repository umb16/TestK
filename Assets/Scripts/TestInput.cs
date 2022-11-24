using MK.AsteroidsGame;
using MK.Pooling;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{
    public GameObject asteroid;
    PlayerInputActions inputActions;
    // Start is called before the first frame update
    void Start()
    {
        //SimplePool<Unit> pool = new SimplePool<Unit>(new Unit(asteroid));

       // IUnit x = pool.GetItem();
        //x.Destroy();
        //pool.ReleaseItem(x);
        inputActions = new PlayerInputActions();
        //inputActions.Enable();
       /* inputActions.Player.FireBullet.PerformInteractiveRebinding()
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => { Debug.Log("RebindOk"); inputActions.Enable(); }).Start();*/
        //print("ok");
        inputActions.Enable();
        List<int> ints = new List<int>(new[] { 1, 2 });
        List<int> ints2 = new List<int>(new[] { 3, 4 });
        var union = ints.Union(ints2);
        Debug.Log(union.Count());
        ints.Add(22);
        Debug.Log(union.Count());

    }

    // Update is called once per frame
    void Update()
    {
        
        if (inputActions.Player.FireRay.triggered)
            Debug.Log("fireray");
        //Debug.Log("rotate"+ inputActions.Player.Rotate.ReadValue<float>());
        /*if (inputActions.Player.FireBullet.ReadValue<float>()>0)
            Debug.Log("firebullet");*/
        /*if (inputActions.Player.FireRay.ReadValue<bool>())
        {
            Debug.Log("fireray");
        }*/
        // Debug.Log(inputActions.Player.Accelerate.ReadValue<float>());
    }
}

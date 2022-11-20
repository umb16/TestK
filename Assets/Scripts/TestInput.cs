using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{
    PlayerInputActions inputActions;
    // Start is called before the first frame update
    void Start()
    {
        inputActions = new PlayerInputActions();
        //inputActions.Enable();
       /* inputActions.Player.FireBullet.PerformInteractiveRebinding()
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => { Debug.Log("RebindOk"); inputActions.Enable(); }).Start();*/
        //print("ok");
       // inputActions.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (inputActions.Player.FireBullet.ReadValue<float>() > 0)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

internal class MovableObj : IMovebleObj, IPoolObject
{
    private GameObject _gameObject;
    public Vector2 Velocity { get; set; }
    public Vector2 Position
    {
        get => _gameObject.transform.position;
        set => _gameObject.transform.position = value;
    }

    public float Radius { get; set; }

    public void SetGameObject(GameObject gameObject)
    {
        _gameObject = gameObject;
    }

    public void Destroy()
    {
        GameObject.Destroy(_gameObject);
    }

    public IPoolObject CreateNew()
    {
        var obj = new MovableObj();
        obj.SetGameObject(_gameObject);
        return obj;
    }

    public void Reset()
    {
        Velocity = new Vector2(0, 0);
    }

    public void SetActive(bool v)
    {
        _gameObject.SetActive(v);
    }
}

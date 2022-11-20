using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SimplePool<T> where T : class, IPoolObject
{
    private ObjectPool<T> _pool;
    private IPoolObject _template;

    public SimplePool(T template)
    {
        _pool = new ObjectPool<T>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject);
        _template = template;
    }

    public T Get()
    {
       return _pool.Get();
    }

    T CreatePooledItem()
    {
        var obj = (T)_template.CreateNew();
        obj.Reset();
        return obj;
    }

    void OnReturnedToPool(T obj)
    {
        obj.SetActive(false);
        obj.Reset();
    }

    void OnTakeFromPool(T obj)
    {
        obj.SetActive(true);
    }

    void OnDestroyPoolObject(T obj)
    {
        obj.Destroy();
    }
}

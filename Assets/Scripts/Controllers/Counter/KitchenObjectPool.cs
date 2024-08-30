using System;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectPool : IPool
{
    public List<IObjectPool> ObjectList { get; private set; }
    private int _currentSize => ObjectList.Count;
    private int _poolSize;
    private Transform _poolTransform;

    public KitchenObjectPool(int size, Transform transform)
    {
        _poolSize = size;

        ObjectList = new List<IObjectPool>();
        _poolTransform = transform;
    }

    public void AddToPool(IObjectPool objectPool)
    {
        if (_currentSize >= _poolSize) return;

        objectPool.OnReturnToPool += () =>
        {
            objectPool.GetTransform().SetParent(_poolTransform);
        };

        ObjectList.Add(objectPool);
        objectPool.ReturnToPool();
    }

    public IObjectPool GetObjectPool(Func<IObjectPool, bool> predicate)
    {
        IObjectPool objectPool = ObjectList.Find(obj => predicate(obj));
        if (objectPool == null) return null;
        objectPool.Reset();

        return objectPool;
    }
}

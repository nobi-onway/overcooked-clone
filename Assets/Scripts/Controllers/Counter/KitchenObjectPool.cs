using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectPool : IPool<KitchenObjectController>
{
    private List<IObjectPool<KitchenObjectController>> _objectList;
    private int _currentSize => _objectList.Count;
    private int _poolSize;
    private Transform _poolTransform;

    public KitchenObjectPool(int size, Transform transform)
    {
        _poolSize = size;

        _objectList = new List<IObjectPool<KitchenObjectController>>();
        _poolTransform = transform;
    }

    public void AddToPool(IObjectPool<KitchenObjectController> objectPool)
    {
        if (_currentSize >= _poolSize) return;

        objectPool.OnReturnToPool += () =>
        {
            objectPool.GetObject().SetParent(_poolTransform);
        };

        _objectList.Add(objectPool);
        objectPool.ReturnToPool();
    }

    public IObjectPool<KitchenObjectController> GetObjectPool()
    {
        IObjectPool<KitchenObjectController> objectPool = _objectList.Find(obj => !obj.IsActivated);
        if (objectPool == null) return null;
        objectPool.Reset();

        return objectPool;
    }
}

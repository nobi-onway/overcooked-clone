using System;
using UnityEngine;

public interface IObjectPool
{
    public event Action OnReturnToPool;
    public void ReturnToPool();
    public void Reset();
    public Transform GetTransform();
    public bool IsActivated { get; }
}

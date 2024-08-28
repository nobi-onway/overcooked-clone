using System;

public interface IObjectPool<T>
{
    public event Action OnReturnToPool;
    public void ReturnToPool();
    public void Reset();
    public T GetObject();
    public bool IsActivated { get; }
}

using System.Collections.Generic;
using System;

public interface IPool
{
    public void AddToPool(IObjectPool objectPool);
    public IObjectPool GetObjectPool(Func<IObjectPool, bool> predicate);
    public List<IObjectPool> ObjectList { get; }
}

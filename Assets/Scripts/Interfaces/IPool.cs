public interface IPool<T>
{
    public void AddToPool(IObjectPool<T> objectPool);
    public IObjectPool<T> GetObjectPool();
}

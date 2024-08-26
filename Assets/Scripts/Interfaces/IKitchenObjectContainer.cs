public interface IKitchenObjectContainer
{
    public void SetKitchenObject(KitchenObjectController kitchenObject);
    public bool IsEmpty();
    public void ClearKitchenObject();
    public KitchenObjectController GetKitchenObject();
}

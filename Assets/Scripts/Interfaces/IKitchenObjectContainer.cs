using System;

public interface IKitchenObjectContainer
{
    public void SetKitchenObject(KitchenObjectController kitchenObject);
    public bool IsEmpty();
    public void ClearKitchenObject();
    public KitchenObjectController GetKitchenObject();
    public event Action<KitchenObjectController> OnSetKitchenObject;
}

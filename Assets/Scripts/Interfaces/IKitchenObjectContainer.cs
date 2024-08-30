using System;

public interface IKitchenObjectContainer
{
    public void SetKitchenObject(IKitchenObject kitchenObject);
    public bool IsEmpty();
    public void ClearKitchenObject();
    public IKitchenObject GetKitchenObject();
    public event Action<IKitchenObject> OnSetKitchenObject;
    public bool CanContain(IKitchenObject kitchenObject);
}

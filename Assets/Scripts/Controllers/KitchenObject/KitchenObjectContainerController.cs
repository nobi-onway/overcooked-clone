using System;
using UnityEngine;

public class KitchenObjectContainerController : MonoBehaviour, IKitchenObjectContainer
{
    private IKitchenObject _kitchenObject;

    public event Action<IKitchenObject> OnSetKitchenObject;

    public void ClearKitchenObject()
    {
        _kitchenObject = null;
        OnSetKitchenObject?.Invoke(null);
    }

    public IKitchenObject GetKitchenObject()
    {
        return _kitchenObject;
    }

    public bool IsEmpty() => _kitchenObject == null;

    public void SetKitchenObject(IKitchenObject kitchenObject)
    {
        _kitchenObject = kitchenObject;
        _kitchenObject.SetParent(this.transform);

        OnSetKitchenObject?.Invoke(kitchenObject);
    }
}

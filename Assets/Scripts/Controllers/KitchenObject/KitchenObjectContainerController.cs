using System;
using UnityEngine;

public class KitchenObjectContainerController : MonoBehaviour, IKitchenObjectContainer
{
    private IKitchenObject _kitchenObject;

    public event Action<IKitchenObject> OnSetKitchenObject;

    public bool CanContain(IKitchenObject kitchenObject)
    {
        if (IsEmpty() || kitchenObject == null) return false;

        IContainableObject containableObject = _kitchenObject.GetTransform().GetComponent<IContainableObject>();
        if (containableObject == null) return false;

        return containableObject.TryContainObject(kitchenObject);
    }

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

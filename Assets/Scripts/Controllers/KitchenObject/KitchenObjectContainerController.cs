using System;
using UnityEngine;

public class KitchenObjectContainerController : MonoBehaviour, IKitchenObjectContainer
{
    private KitchenObjectController _kitchenObject;

    public event Action<KitchenObjectController> OnSetKitchenObject;

    public void ClearKitchenObject()
    {
        _kitchenObject = null;
        OnSetKitchenObject?.Invoke(null);
    }

    public KitchenObjectController GetKitchenObject()
    {
        return _kitchenObject;
    }

    public bool IsEmpty() => _kitchenObject == null;

    public void SetKitchenObject(KitchenObjectController kitchenObject)
    {
        _kitchenObject = kitchenObject;
        _kitchenObject.SetParent(this.transform);

        OnSetKitchenObject?.Invoke(kitchenObject);
    }
}

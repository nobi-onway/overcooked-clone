using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectContainerController : MonoBehaviour, IKitchenObjectContainer
{
    private KitchenObjectController _kitchenObject;

    public void ClearKitchenObject()
    {
        _kitchenObject = null;
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
    }
}

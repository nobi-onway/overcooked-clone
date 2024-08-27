using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterController : ClearCounterController
{
    private SliceObject _sliceObject;

    protected override bool CanInteractWith(KitchenObjectController kitchenObject)
    {
        if (kitchenObject == null) return true;

        return kitchenObject.TryGetComponent(out _sliceObject);
    }

    public override void AlternateInteract(IKitchenObjectContainer kitchenObjectContainer)
    {
        if (_sliceObject == null) return;

        _sliceObject.Slice(_kitchenObjectContainer.GetKitchenObject());
    }
}

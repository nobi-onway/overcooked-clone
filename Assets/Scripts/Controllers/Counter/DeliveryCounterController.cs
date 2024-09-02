using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounterController : BaseCounterController
{
    public override void Interact(IKitchenObjectContainer kitchenObjectContainer)
    {
        if (kitchenObjectContainer.IsEmpty()) return;

        PlateController plateController = kitchenObjectContainer.GetKitchenObject().GetTransform().GetComponent<PlateController>();
        if (plateController == null) return;

        TaskManager.Instance.TryHandleDelivery(plateController.GetContainedKitchenObject());

        plateController.ReturnToPool();
        kitchenObjectContainer.ClearKitchenObject();
    }
}

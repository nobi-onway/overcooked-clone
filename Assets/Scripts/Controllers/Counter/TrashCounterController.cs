public class TrashCounterController : BaseCounterController
{
    public override void Interact(IKitchenObjectContainer kitchenObjectContainer)
    {
        KitchenObjectController kitchenObject = kitchenObjectContainer.GetKitchenObject();
        if (kitchenObject == null) return;

        kitchenObject.ReturnToPool();
        kitchenObjectContainer.ClearKitchenObject();
    }
}

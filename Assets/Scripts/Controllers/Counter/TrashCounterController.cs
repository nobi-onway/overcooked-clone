public class TrashCounterController : BaseCounterController
{
    public override void Interact(IKitchenObjectContainer kitchenObjectContainer)
    {
        IKitchenObject kitchenObject = kitchenObjectContainer.GetKitchenObject();
        if (kitchenObject == null) return;

        kitchenObject.GetTransform().GetComponent<IObjectPool>().ReturnToPool();
        kitchenObjectContainer.ClearKitchenObject();
    }
}

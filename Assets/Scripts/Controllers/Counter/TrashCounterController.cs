public class TrashCounterController : BaseCounterController
{
    public override void Interact(IKitchenObjectContainer kitchenObjectContainer)
    {
        Destroy(kitchenObjectContainer.GetKitchenObject().gameObject);
    }
}

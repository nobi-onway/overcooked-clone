public class ClearCounterController : BaseCounterController
{
    protected IKitchenObjectContainer _kitchenObjectContainer;
    protected virtual void Start()
    {
        _kitchenObjectContainer = GetComponentInChildren<IKitchenObjectContainer>();
    }

    public override void Interact(IKitchenObjectContainer kitchenObjectContainer)
    {
        if (!CanInteractWith(kitchenObjectContainer.GetKitchenObject())) return;

        if (_kitchenObjectContainer.IsEmpty() && !kitchenObjectContainer.IsEmpty())
        {
            ShiftKitchenObject(kitchenObjectContainer, _kitchenObjectContainer);
            return;
        }

        if (!_kitchenObjectContainer.IsEmpty() && kitchenObjectContainer.IsEmpty())
        {
            ShiftKitchenObject(_kitchenObjectContainer, kitchenObjectContainer);
            return;
        }
    }

    private void ShiftKitchenObject(IKitchenObjectContainer from, IKitchenObjectContainer to)
    {
        to.SetKitchenObject(from.GetKitchenObject());
        from.ClearKitchenObject();
    }
}

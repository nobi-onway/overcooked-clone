public class ClearCounterController : BaseCounterController
{
    private IKitchenObjectContainer _kitchenObjectContainer;

    private void Start()
    {
        _kitchenObjectContainer = GetComponentInChildren<IKitchenObjectContainer>();
    }

    public override void Interact(IKitchenObjectContainer kitchenObjectContainer)
    {
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

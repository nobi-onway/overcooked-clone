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

        if(_kitchenObjectContainer.CanContain(kitchenObjectContainer.GetKitchenObject()))
        {
            TakeKitchenObject(kitchenObjectContainer);
            return;
        }

        if (kitchenObjectContainer.CanContain(_kitchenObjectContainer.GetKitchenObject()))
        {
            TakeKitchenObject(_kitchenObjectContainer);
            return;
        }
    }

    private void ShiftKitchenObject(IKitchenObjectContainer from, IKitchenObjectContainer to)
    {
        to.SetKitchenObject(from.GetKitchenObject());
        from.ClearKitchenObject();
    }

    private void TakeKitchenObject(IKitchenObjectContainer from)
    {
        from.GetKitchenObject().GetTransform().GetComponent<IObjectPool>().ReturnToPool();
        from.ClearKitchenObject();
    }
}

public class PlateController : KitchenObjectController
{
    protected override void SetActivated(bool isActivated)
    {
        IsActivated = isActivated;
    }

    public override void Reset()
    {
        SetActivated(false);
    }

    public override void ReturnToPool()
    {
        SetActivated(true);
        InvokeReturnToPoolAction();
    }
}

using UnityEngine;

public class PlateCounterController : BaseCounterController
{
    private const int POOL_SIZE = 10;

    [SerializeField] private KitchenObjectSettings _plateSetting;
    [SerializeField] private Transform _plateHolder;
    private KitchenObjectPool _platePool;

    private void Start()
    {
        InitPool();
        RearrangePlate();
    }

    protected override bool CanInteractWith(IKitchenObject kitchenObject)
    {
        if (kitchenObject == null) return true;

        return true;
    }
    public override void Interact(IKitchenObjectContainer kitchenObjectContainer)
    {
        if (!kitchenObjectContainer.IsEmpty()) return;

        IObjectPool plateObjectPool = _platePool.GetObjectPool((obj) => obj.IsActivated);
        IKitchenObject plateClone = plateObjectPool.GetTransform().GetComponent<IKitchenObject>();

        kitchenObjectContainer.SetKitchenObject(plateClone);
        RearrangePlate();
    }

    private void InitPool()
    {
        _platePool = new KitchenObjectPool(POOL_SIZE, _plateHolder);

        for(int i = 0; i < POOL_SIZE; i++)
        {
            IObjectPool plateClone = Instantiate(_plateSetting.prefab, _plateHolder).GetComponent<IObjectPool>();
            plateClone.OnReturnToPool += () =>
            {
                plateClone.GetTransform().SetParent(_plateHolder);
                RearrangePlate();
            };
            _platePool.AddToPool(plateClone);
        }
    }

    private void RearrangePlate()
    {
        int count = 0;
        float heightOffset = 0.1f;

        foreach(IObjectPool plate in _platePool.ObjectList)
        {
            if (!plate.IsActivated) continue;

            plate.GetTransform().localPosition = new Vector3(0, heightOffset * count, 0);
            count++;
        }
    }
}

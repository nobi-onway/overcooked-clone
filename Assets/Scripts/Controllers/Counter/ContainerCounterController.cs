using UnityEngine;

public class ContainerCounterController : BaseCounterController
{
    private const string OPEN_CLOSE = "OpenClose";
    private const int POOL_SIZE = 5;

    [SerializeField] private KitchenObjectSettings _kitchenObjectSettings;
    [SerializeField] private SpriteRenderer _objectSprite;

    private Animator _animator;
    private KitchenObjectPool _kitchenObjectPool;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _objectSprite.sprite = _kitchenObjectSettings.sprite;

        InitPool();
    }

    public override void Interact(IKitchenObjectContainer kitchenObjectContainer)
    {
        if (!kitchenObjectContainer.IsEmpty()) return;

        _animator.SetTrigger(OPEN_CLOSE);

        IObjectPool<KitchenObjectController> kitchenObjectClone = _kitchenObjectPool.GetObjectPool();

        if (kitchenObjectClone == null) return;

        kitchenObjectContainer.SetKitchenObject(kitchenObjectClone.GetObject());
    }

    private void InitPool()
    {
        GameObject kitchenObjectHolder = new GameObject("kitchen_object_holder");
        kitchenObjectHolder.transform.parent = this.transform;
        kitchenObjectHolder.transform.position = Vector3.zero;

        _kitchenObjectPool = new KitchenObjectPool(POOL_SIZE, kitchenObjectHolder.transform);

        for (int i = 0; i < POOL_SIZE; i++)
        {
            KitchenObjectController kitchenObjectClone = Instantiate(_kitchenObjectSettings.prefab, kitchenObjectHolder.transform).GetComponent<KitchenObjectController>();
            _kitchenObjectPool.AddToPool(kitchenObjectClone);
        }
    }
}

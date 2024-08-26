using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterController : MonoBehaviour, IInteractableCounter
{
    private const string OPEN_CLOSE = "OpenClose";

    [SerializeField] private KitchenObjectSettings _kitchenObjectSettings;
    [SerializeField] private SpriteRenderer _objectSprite;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _objectSprite.sprite = _kitchenObjectSettings.sprite;
    }

    public void Interact(IKitchenObjectContainer kitchenObjectContainer)
    {
        _animator.SetTrigger(OPEN_CLOSE);

        KitchenObjectController kitchenObjectClone = Instantiate(_kitchenObjectSettings.prefab).GetComponent<KitchenObjectController>();
        kitchenObjectContainer.SetKitchenObject(kitchenObjectClone);
    }

    public IInteractableCounter Selected()
    {
        return this;
    }

    public void DeSelected()
    {

    }
}

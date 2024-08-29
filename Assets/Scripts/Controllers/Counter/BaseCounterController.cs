using UnityEngine;

public abstract class BaseCounterController : MonoBehaviour, IInteractableCounter
{
    #region UnityEditor
    [SerializeField] private Transform[] _selectedVisuals;
    #endregion
    protected virtual bool CanInteractWith(IKitchenObject kitchenObject) => true;

    public void DeSelected() => EnableSelectedVisualIf(false);

    public IInteractableCounter Selected()
    {
        EnableSelectedVisualIf(true);

        return this;
    }

    private void EnableSelectedVisualIf(bool enabled)
    {
        foreach (Transform selectedVisual in _selectedVisuals)
        {
            selectedVisual.gameObject.SetActive(enabled);
        }
    }
    public abstract void Interact(IKitchenObjectContainer kitchenObjectContainer);

    public virtual void AlternateInteract(IKitchenObjectContainer kitchenObjectContainer) { }
}

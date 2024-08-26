using UnityEngine;

public abstract class BaseCounterController : MonoBehaviour, IInteractableCounter
{
    #region UnityEditor
    [SerializeField] private GameObject _selectedVisual;
    #endregion

    public void DeSelected()
    {
        _selectedVisual.gameObject.SetActive(false);
    }

    public IInteractableCounter Selected()
    {
        _selectedVisual.gameObject.SetActive(true);
        return this;
    }
    public abstract void Interact(IKitchenObjectContainer kitchenObjectContainer);
}

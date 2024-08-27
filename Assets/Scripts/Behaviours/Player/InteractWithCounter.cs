using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithCounter : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _counterLayerMask;

    private IInteractableCounter _selectedCounter;
    private IKitchenObjectContainer _kitchenObjectContainer;

    private void Start()
    {
        _kitchenObjectContainer = GetComponentInChildren<IKitchenObjectContainer>();
    }

    private void Update()
    {
        HandleInteract();
    }

    private void HandleInteract()
    {
        bool hasAnyCounter = Physics.Raycast(this.transform.position, this.transform.forward, out RaycastHit hitInfo ,_distance, _counterLayerMask);
        if (!hasAnyCounter) { SetSelectedCounter(null); return; }

        bool isInteractableCounter = hitInfo.transform.TryGetComponent(out IInteractableCounter interactableCounter);
        if (!isInteractableCounter) { SetSelectedCounter(null); return; }

        SetSelectedCounter(interactableCounter);
    }

    private void SetSelectedCounter(IInteractableCounter counter)
    {
        _selectedCounter?.DeSelected();
        _selectedCounter = counter?.Selected();
    }

    public void Interact()
    {
        if (_selectedCounter == null) return;

        _selectedCounter.Interact(_kitchenObjectContainer);
    }

    public void AlternateInteract()
    {
        if (_selectedCounter == null) return;

        _selectedCounter.AlternateInteract(_kitchenObjectContainer);
    }
}
using System;

public interface IInteractableCounter
{
    public IInteractableCounter Selected();
    public void DeSelected();
    public void Interact(IKitchenObjectContainer kitchenObjectContainer);
}

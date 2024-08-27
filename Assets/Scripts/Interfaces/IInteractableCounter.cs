using System;

public interface IInteractableCounter
{
    public IInteractableCounter Selected();
    public void DeSelected();
    public void Interact(IKitchenObjectContainer kitchenObjectContainer);

    public void AlternateInteract(IKitchenObjectContainer kitchenObjectContainer);
}

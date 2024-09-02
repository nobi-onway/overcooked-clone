using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IContainableObject
{
    public bool TryContainObject(IKitchenObject kitchenObject);
    public List<KitchenObjectSettings> GetContainedKitchenObject();
}

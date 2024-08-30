using System;
using UnityEngine;

public interface IKitchenObject 
{
    public void SetParent(Transform transform);
    public Transform GetTransform();
    public KitchenObjectSettings GetData();
    public bool IsProcessed { get; set; }
    public event Action OnReset;
}

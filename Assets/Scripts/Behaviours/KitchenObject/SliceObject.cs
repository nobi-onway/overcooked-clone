using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceObject : MonoBehaviour
{
    [SerializeField] private Transform _sliceVisual;

    public void Slice(KitchenObjectController kitchenObject)
    {
        kitchenObject.currentVisual.gameObject.SetActive(false);
        _sliceVisual.gameObject.SetActive(true);
    }
}

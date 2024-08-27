using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectController : MonoBehaviour
{
    public Transform currentVisual;

    public void Init()
    {
        currentVisual.gameObject.SetActive(true);
    }

    public void SetParent(Transform transform)
    {
        this.transform.parent = transform;
        this.transform.localPosition = Vector3.zero;
    }
}

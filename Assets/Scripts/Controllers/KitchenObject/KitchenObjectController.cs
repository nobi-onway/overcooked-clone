using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectController : MonoBehaviour
{
    public void SetParent(Transform transform)
    {
        this.transform.parent = transform;
        this.transform.localPosition = Vector3.zero;
    }
}

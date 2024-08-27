using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectController : MonoBehaviour
{
    private KitchenObjectSettings _settings;

    public void Init(KitchenObjectSettings kitchenObjectSettings)
    {
        _settings = kitchenObjectSettings;

        Transform visualPrefab = Instantiate(_settings.visualPrefab, this.transform);
        visualPrefab.position = Vector3.zero;
    }

    public void SetParent(Transform transform)
    {
        this.transform.parent = transform;
        this.transform.localPosition = Vector3.zero;
    }
}

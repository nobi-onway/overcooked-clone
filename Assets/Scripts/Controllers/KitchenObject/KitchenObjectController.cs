using System;
using UnityEngine;

public class KitchenObjectController : MonoBehaviour, IObjectPool<KitchenObjectController>
{
    public bool IsActivated { get; private set; }

    public event Action OnReturnToPool;
    private IObjectVisual[] _objectVisualArray;

    private void Start()
    {
        _objectVisualArray = GetComponents<IObjectVisual>();

        ResetVisual();
    }

    public void ReturnToPool()
    {
        OnReturnToPool?.Invoke();
        ResetVisual();
        SetActivated(false);
    }

    public void Reset()
    {
        SetActivated(true);
    }

    public void SetParent(Transform transform)
    {
        this.transform.parent = transform;
        this.transform.localPosition = Vector3.zero;
    }

    public KitchenObjectController GetObject() => this;

    private void SetActivated(bool isActivated)
    {
        IsActivated = isActivated;
        this.gameObject.SetActive(isActivated);
    }

    private void ResetVisual()
    {
        if (_objectVisualArray == null) return;

        foreach (IObjectVisual visual in _objectVisualArray)
        {
            visual.Reset();
        }
    }
}

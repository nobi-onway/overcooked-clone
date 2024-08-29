using System;
using UnityEngine;

public class KitchenObjectController : MonoBehaviour, IObjectPool, IKitchenObject
{
    public bool IsActivated { get; protected set; }

    public event Action OnReturnToPool;
    private IObjectVisual[] _objectVisualArray;

    private void Start()
    {
        _objectVisualArray = GetComponents<IObjectVisual>();

        ResetVisual();
    }

    public virtual void ReturnToPool()
    {
        OnReturnToPool?.Invoke();
        ResetVisual();
        SetActivated(false);
    }

    public virtual void Reset()
    {
        SetActivated(true);
    }

    public void SetParent(Transform transform)
    {
        this.transform.parent = transform;
        this.transform.localPosition = Vector3.zero;
    }

    protected virtual void SetActivated(bool isActivated)
    {
        IsActivated = isActivated;
        this.gameObject.SetActive(isActivated);
    }

    protected void InvokeReturnToPoolAction() => OnReturnToPool?.Invoke();

    private void ResetVisual()
    {
        if (_objectVisualArray == null) return;

        foreach (IObjectVisual visual in _objectVisualArray)
        {
            visual.Reset();
        }
    }

    public Transform GetTransform() => this.transform;
}

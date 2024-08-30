using System;
using UnityEngine;

public class KitchenObjectController : MonoBehaviour, IObjectPool, IKitchenObject
{
    private KitchenObjectSettings _settings;
    public bool IsActivated { get; protected set; }
    public bool IsProcessed { get; set; }

    public event Action OnReturnToPool;
    public event Action OnReset;

    public void Init(KitchenObjectSettings settings)
    {
        _settings = settings;
        IsProcessed = true;
    }

    public virtual void ReturnToPool()
    {
        InvokeReturnToPoolAction();
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

    protected void InvokeReturnToPoolAction()
    {
        OnReturnToPool?.Invoke();
        OnReset?.Invoke();
    }

    public Transform GetTransform() => this.transform;

    public KitchenObjectSettings GetData()
    {
        return _settings;
    }
}

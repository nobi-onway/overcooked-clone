using System;
using UnityEngine;

public class CuttingCounterController : ClearCounterController, IProgressTracker
{
    private const string CUT = "Cut";
    
    private ISlicableKitchenObject _sliceObject;
    private Animator _animator;

    public float ProgressValue { get; private set; }

    public event Action<float> OnProgressChange;

    protected override void Start()
    {
        base.Start();
        _animator = GetComponentInChildren<Animator>();

        _kitchenObjectContainer.OnSetKitchenObject += (kitchenObject) =>
        {
            SetProgress(0);

            if (kitchenObject == null) return;
            if (_sliceObject == null && !kitchenObject.GetTransform().TryGetComponent(out _sliceObject)) return;

            SetProgress(_sliceObject.GetSliceProgress());
        };
    }

    protected override bool CanInteractWith(IKitchenObject kitchenObject)
    {
        if (kitchenObject == null) return true;

        return kitchenObject.GetTransform().TryGetComponent(out _sliceObject);
    }

    public override void AlternateInteract(IKitchenObjectContainer kitchenObjectContainer)
    {
        if (_sliceObject == null) return;
        if (_sliceObject.IsSliced) return;

        _animator.SetTrigger(CUT);
        _sliceObject.Slice();
        SetProgress(_sliceObject.GetSliceProgress());
    }

    private void SetProgress(float value)
    {
        ProgressValue = value;
        OnProgressChange?.Invoke(value);
    }
}

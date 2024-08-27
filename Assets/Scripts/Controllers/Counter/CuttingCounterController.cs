using UnityEngine;

public class CuttingCounterController : ClearCounterController
{
    #region UnityEditor
    [SerializeField] private ProgressBarController _progressBar;
    #endregion

    private const string CUT = "Cut";
    
    private ISlicableKitchenObject _sliceObject;
    private Animator _animator;

    protected override void Start()
    {
        base.Start();
        _animator = GetComponentInChildren<Animator>();

        _progressBar.ShowIf(false);

        _kitchenObjectContainer.OnSetKitchenObject += (kitchenObject) =>
        {
            _progressBar.ShowIf(kitchenObject != null);

            if (kitchenObject == null) return;
            if (_sliceObject == null && !kitchenObject.TryGetComponent(out _sliceObject)) return;

            _progressBar.SetProgressValue(_sliceObject.GetSliceProgress());
        };
    }

    protected override bool CanInteractWith(KitchenObjectController kitchenObject)
    {
        if (kitchenObject == null) return true;

        return kitchenObject.TryGetComponent(out _sliceObject);
    }

    public override void AlternateInteract(IKitchenObjectContainer kitchenObjectContainer)
    {
        if (_sliceObject == null) return;
        if (_sliceObject.IsSliced) return;

        _animator.SetTrigger(CUT);
        _sliceObject.Slice();
        _progressBar.SetProgressValue(_sliceObject.GetSliceProgress());
    }
}

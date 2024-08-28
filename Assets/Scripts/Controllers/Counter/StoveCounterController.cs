using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterController : ClearCounterController
{
    #region UnityEditor
    [SerializeField] private ProgressBarController _progressBar;
    #endregion

    private IStovableObject _stovableObject;
    private IEnumerator _stoveCoroutine;

    protected override void Start()
    {
        base.Start();

        _progressBar.ShowIf(false);

        _kitchenObjectContainer.OnSetKitchenObject += (kitchenObject) =>
        {
            _progressBar.ShowIf(kitchenObject != null);

            if (kitchenObject == null) { StopCoroutine(_stoveCoroutine); return; }
            if (_stovableObject == null && !kitchenObject.TryGetComponent(out _stovableObject)) { StopCoroutine(_stoveCoroutine); return; }

            _stoveCoroutine = Stove(_stovableObject);
            StartCoroutine(_stoveCoroutine);
        };
    }

    protected override bool CanInteractWith(KitchenObjectController kitchenObject)
    {
        if (kitchenObject == null) return true;

        return kitchenObject.TryGetComponent(out _stovableObject);
    }

    private IEnumerator Stove(IStovableObject kitchenObject)
    {
        while(kitchenObject != null && kitchenObject.IsStovable)
        {
            _progressBar.SetProgressValue(kitchenObject.GetStoveProgress());
            kitchenObject.Stove();
            yield return new WaitForEndOfFrame();
        }
    }
}

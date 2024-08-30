using System;
using System.Collections;
using UnityEngine;

public enum EStoveCounterState { IDLE, STOVING }
public class StoveCounterController : ClearCounterController, IProgressTracker
{
    #region UnityEditor
    [SerializeField] private Transform _stoveOnVisual;
    [SerializeField] private ParticleSystem _sizzlingParticle;
    #endregion

    private IStovableObject _stovableObject;
    private IEnumerator _stoveCoroutine;

    private EStoveCounterState state;

    public float ProgressValue { get; private set; }

    private event Action<EStoveCounterState> OnStateChange;
    public event Action<float> OnProgressChange;

    protected override void Start()
    {
        base.Start();

        OnStateChange += (state) =>
        {
            switch(state)
            {
                case EStoveCounterState.IDLE:
                    SetProgress(0);
                    _stoveOnVisual.gameObject.SetActive(false);
                    _sizzlingParticle.gameObject.SetActive(false);
                    if(_stoveCoroutine != null) StopCoroutine(_stoveCoroutine);
                    break;
                case EStoveCounterState.STOVING:
                    _stoveOnVisual.gameObject.SetActive(true);
                    _sizzlingParticle.gameObject.SetActive(true);
                    StartCoroutine(_stoveCoroutine);
                    break;
            }
        };

        _kitchenObjectContainer.OnSetKitchenObject += (kitchenObject) =>
        {
            if (kitchenObject == null) { SetState(EStoveCounterState.IDLE); return; }
            if (_stovableObject == null && !kitchenObject.GetTransform().TryGetComponent(out _stovableObject)) { SetState(EStoveCounterState.IDLE); return; }

            _stoveCoroutine = Stove(_stovableObject);
            SetState(EStoveCounterState.STOVING);
        };

        SetState(EStoveCounterState.IDLE);
    }

    protected override bool CanInteractWith(IKitchenObject kitchenObject)
    {
        if (kitchenObject == null) return true;

        return kitchenObject.GetTransform().TryGetComponent(out _stovableObject);
    }

    private IEnumerator Stove(IStovableObject kitchenObject)
    {
        while (kitchenObject != null && kitchenObject.IsStovable)
        {
            SetProgress(kitchenObject.GetStoveProgress());
            kitchenObject.Stove();
            yield return new WaitForEndOfFrame();
        }
    }

    private void SetProgress(float value)
    {
        ProgressValue = value;
        OnProgressChange?.Invoke(value);
    }

    private void SetState(EStoveCounterState state)
    {
        this.state = state;
        OnStateChange?.Invoke(state);
    }
}

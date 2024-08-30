using System;
using UnityEngine;

public class SliceObject : MonoBehaviour, ISlicableKitchenObject, IChangableVisual
{
    [SerializeField] private int _maxSliceTime;
    private int _currentSliceTime;
    private IKitchenObject _kitchenObject;

    public ESliceState SliceState { get; private set; }
    public event Action<ESliceState> OnSliceStateChange;

    public int VisualIndex { get; private set; }
    public event Action<int> OnVisualChange;
    public bool IsSliced => SliceState == ESliceState.SLICED;

    private void Start()
    {
        _kitchenObject = GetComponent<IKitchenObject>();
        _kitchenObject.OnReset += () => SetSliceState(ESliceState.UNSLICED);

        SetSliceState(ESliceState.UNSLICED);
    }
    private void SetVisual(int visualIndex)
    {
        VisualIndex = visualIndex;
        OnVisualChange?.Invoke(visualIndex);
    }

    private void SetSliceState(ESliceState sliceState)
    {
        _kitchenObject.IsProcessed = sliceState == ESliceState.SLICED;
        _currentSliceTime = sliceState == ESliceState.UNSLICED ? 0 : _currentSliceTime;
        SetVisual((int) sliceState);

        SliceState = sliceState;
        OnSliceStateChange?.Invoke(sliceState);
    }

    public void Slice()
    {
        _currentSliceTime++;
        if (_currentSliceTime > _maxSliceTime) _currentSliceTime = _maxSliceTime;
        if (_currentSliceTime == _maxSliceTime) SetSliceState(ESliceState.SLICED);
    }

    public float GetSliceProgress() => (float) _currentSliceTime/ _maxSliceTime;
    
}

using System;
using UnityEngine;

public class SliceObject : MonoBehaviour, ISlicableKitchenObject
{
    [SerializeField] private Transform _slicedVisual;
    [SerializeField] private Transform _unslicedVisual;

    [SerializeField] private int _maxSliceTime;
    private int _currentSliceTime;

    public bool IsSliced { get; private set; }

    private void Start()
    {
        SetSliced(false);
        _currentSliceTime = 0;
    }

    public void Slice()
    {
        _currentSliceTime++;
        if (_currentSliceTime > _maxSliceTime) _currentSliceTime = _maxSliceTime;
        if(_currentSliceTime == _maxSliceTime) SetSliced(true);
    }

    private void SetSliced(bool isSliced)
    {
        IsSliced = isSliced;
        _slicedVisual.gameObject.SetActive(isSliced);
        _unslicedVisual.gameObject.SetActive(!isSliced);
    }

    public float GetSliceProgress() => (float) _currentSliceTime/ _maxSliceTime;
}

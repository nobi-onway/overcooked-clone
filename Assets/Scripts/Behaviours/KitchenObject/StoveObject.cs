using System;
using UnityEngine;

public class StoveObject : MonoBehaviour, IStovableObject, IChangableVisual
{
    [SerializeField] private float _maxStoveTime;
    private float _currentStoveTime;
    private IKitchenObject _kitchenObject;

    private float _cookedTime => _maxStoveTime * 1 / 2;
    public bool IsStovable => StoveState != EStoveState.BURNED;

    public int VisualIndex { get; private set; }
    public event Action<int> OnVisualChange;

    public EStoveState StoveState { get; private set; }
    public event Action<EStoveState> OnStoveStateChange;

    private void Start()
    {
        _kitchenObject = GetComponent<IKitchenObject>();
        _kitchenObject.OnReset += () => SetStoveState(EStoveState.UNCOOKED);

        SetStoveState(EStoveState.UNCOOKED);
    }

    public float GetStoveProgress() => _currentStoveTime / _maxStoveTime;

    public void Stove()
    {
        _currentStoveTime += Time.deltaTime;

        if (_currentStoveTime >= _maxStoveTime) { SetStoveState(EStoveState.BURNED); return; }
        if (_currentStoveTime >= _cookedTime) { SetStoveState(EStoveState.COOKED); return; }
    }

    private void SetVisual(int visualIndex)
    {
        VisualIndex = visualIndex;
        OnVisualChange?.Invoke(visualIndex);
    }

    private void SetStoveState(EStoveState stoveState)
    {
        StoveState = stoveState;
        OnStoveStateChange?.Invoke(stoveState);

        _kitchenObject.IsProcessed = stoveState == EStoveState.COOKED;
        _currentStoveTime = stoveState == EStoveState.UNCOOKED ? 0 : _currentStoveTime;
        SetVisual((int)stoveState);
    }
}

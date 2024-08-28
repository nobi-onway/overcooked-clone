using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveObject : MonoBehaviour, IStovableObject, IObjectVisual
{
    [SerializeField] private Transform _uncookedVisual;
    [SerializeField] private Transform _cookedVisual;
    [SerializeField] private Transform _burnedVisual;

    [SerializeField] private float _maxStoveTime;
    private float _currentStoveTime;
    private Transform _currentVisual;

    private float _cookedTime => _maxStoveTime * 1 / 2;
    public bool IsStovable => _currentStoveTime < _maxStoveTime;

    public float GetStoveProgress() => _currentStoveTime / _maxStoveTime;

    public void Reset()
    {
        SetCurrentVisual(_uncookedVisual);
        _currentStoveTime = 0;
    }

    public void Stove()
    {
        _currentStoveTime += Time.deltaTime;

        if (_currentStoveTime >= _maxStoveTime) { SetCurrentVisual(_burnedVisual); return; }
        if (_currentStoveTime >= _cookedTime) { SetCurrentVisual(_cookedVisual); return; }
    }

    private void SetCurrentVisual(Transform visual)
    {
        _currentVisual?.gameObject.SetActive(false);
        _currentVisual = visual;
        _currentVisual.gameObject.SetActive(true);
    }
}

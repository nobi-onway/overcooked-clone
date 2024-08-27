using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlayerState { IDLE, WALKING }
public class PlayerController : MonoBehaviour, IController<EPlayerState>
{
    #region UnityEditor
    [SerializeField] private InputController _inputController;

    [Space, Header("Space")]
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    #endregion

    #region Behaviour
    private InteractWithCounter _interactWithCounter;
    #endregion

    private EPlayerState _state;
    public EPlayerState State 
    { 
        get => _state; 
        set
        {
            if(_state != value) OnStateChange?.Invoke(value);
            _state = value;
        }
    }

    private Rigidbody _rb;

    public event Action<EPlayerState> OnStateChange;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _interactWithCounter = GetComponent<InteractWithCounter>();

        _inputController.OnInteract += _interactWithCounter.Interact;
        _inputController.OnAlternateInteract += _interactWithCounter.AlternateInteract;
    }

    private void FixedUpdate()
    {
        Vector2 movementVector = _inputController.MovementVectorNormalized;
        Vector3 direction = new Vector3(movementVector.x, 0, movementVector.y);

        State = direction == Vector3.zero ? EPlayerState.IDLE : EPlayerState.WALKING;

        _rb.MovePosition(this.transform.position + direction * _speed * Time.deltaTime);
        this.transform.forward = Vector3.Slerp(this.transform.forward, direction, _rotateSpeed * Time.deltaTime);
    }
}

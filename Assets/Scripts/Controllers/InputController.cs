using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private InputActions _inputActions;

    public event Action OnInteract;

    private void Awake()
    {
        _inputActions = new InputActions();
        _inputActions.Player.Enable();
        _inputActions.Player.Interact.performed += OnInteractPerformed;
    }

    private void OnInteractPerformed(InputAction.CallbackContext callbackContext)
    {
        OnInteract?.Invoke();
    }

    public Vector2 MovementVectorNormalized => _inputActions.Player.Move.ReadValue<Vector2>().normalized;
}

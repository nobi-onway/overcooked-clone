using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private InputActions _inputActions;

    public event Action OnInteract;
    public event Action OnAlternateInteract;

    private void Awake()
    {
        _inputActions = new InputActions();
        _inputActions.Player.Enable();
        _inputActions.Player.Interact.performed += OnInteractPerformed;
        _inputActions.Player.AlternateInteract.performed += OnAlternateInteractPerformed;
    }

    private void OnInteractPerformed(InputAction.CallbackContext callbackContext)
    {
        OnInteract?.Invoke();
    }
    private void OnAlternateInteractPerformed(InputAction.CallbackContext callbackContext)
    {
        OnAlternateInteract?.Invoke();
    }

    public Vector2 MovementVectorNormalized => _inputActions.Player.Move.ReadValue<Vector2>().normalized;
}

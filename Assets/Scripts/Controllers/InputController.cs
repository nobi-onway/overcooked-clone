using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private InputActions _inputActions;

    private void Awake()
    {
        _inputActions = new InputActions();
        _inputActions.Player.Enable();
    }

    public Vector2 MovementVectorNormalized => _inputActions.Player.Move.ReadValue<Vector2>().normalized;
}

using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";

    private IController<EPlayerState> _controller;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponentInParent<IController<EPlayerState>>();

        _controller.OnStateChange += (state) =>
        {
            _animator.SetBool(IS_WALKING, state == EPlayerState.WALKING);
        };
    }
}

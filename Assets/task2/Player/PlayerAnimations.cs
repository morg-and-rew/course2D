using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    private readonly int IsMovingHash = Animator.StringToHash("IsMoving");

    private Animator _animator;

    private bool IsMoving;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetIsMoving(bool isMoving)
    {
        IsMoving = isMoving;
        _animator.SetBool(IsMovingHash, IsMoving);
    }
}
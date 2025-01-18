using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private SpriteRenderer _characterSprite;

    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    private float _speed = 5f;
    private float _jumpHeight = 30f;

    private Vector3 _horizontalInput;

    private bool _isMoving;
    private bool _isGrounded;

    private Rigidbody2D _rigidBody;
    private PlayerAnimations _playerAnimations;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void FixedUpdate()
    {
        Move();
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            Jump();
    }

    private void Move()
    {
        _horizontalInput = new Vector2(Input.GetAxis(HorizontalAxis), 0);
        transform.position += _horizontalInput * _speed * Time.deltaTime;

        _isMoving = _horizontalInput.x != 0;

        Vector3 currentScale = _characterSprite.transform.localScale;
        _characterSprite.transform.localScale = new Vector3(Mathf.Sign(_horizontalInput.x) * Mathf.Abs(currentScale.x), currentScale.y, currentScale.z);

        _playerAnimations.SetIsMoving(_isMoving);
    }

    private void Jump()
    {
        _rigidBody.AddForce(transform.up * _jumpHeight, ForceMode2D.Impulse);
    }
}

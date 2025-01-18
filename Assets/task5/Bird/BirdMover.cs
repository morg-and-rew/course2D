using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    private float _tapForse = 250f;
    private float _speed = 2.5f;
    private float _rotationSpeed = 1f;
    private float _maxRotationZ = 35f;
    private float _minRotationZ = -60f;

    private Vector2 _startPosition;
    private Rigidbody2D _rigidbody2D;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private KeyCode _jumpKey = KeyCode.Space;

    private void Start()
    {
        _startPosition = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D> ();

        _maxRotation = Quaternion.Euler (0f, 0f, _maxRotationZ);
        _minRotation = Quaternion.Euler (0f, 0f, _minRotationZ);

        Reset();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            _rigidbody2D.velocity = new Vector2(_speed, 0);
            transform.rotation = _maxRotation;
            _rigidbody2D.AddForce(Vector2.up * _tapForse, ForceMode2D.Force);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        _rigidbody2D.velocity = Vector2.zero;
    }
}

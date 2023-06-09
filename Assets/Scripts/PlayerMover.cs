using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _reversSpeed;
    [SerializeField] private float _sideSpeed;
    [SerializeField] private float _rotateSpeed;

    private Rigidbody _rigidbody;
    private float _horizontalDirection;
    private float _verticalDirection;
    private float _rotateDirection;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _horizontalDirection = Input.GetAxis("Horizontal");
        _verticalDirection = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.E))
        {
            _rotateDirection = 1;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            _rotateDirection = -1;
        }
        else
        {
            _rotateDirection = 0;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 currentVelocity = new Vector3(_horizontalDirection * _sideSpeed, _rigidbody.velocity.y, _verticalDirection > 0 ? _forwardSpeed : _verticalDirection < 0 ? -_reversSpeed : 0);
        _rigidbody.velocity = currentVelocity;
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, _rotateDirection * _rotateSpeed);
    }
}

using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class AdvancedCharacterController : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _gravity = 9.8f;
    [SerializeField] private float _jumpForce = 8.0f;
    [SerializeField] private float _slopeForce = 5.0f;
    [SerializeField] private float _slopeRayLength = 1.5f;
    [SerializeField] private float _rotationSpeed = 300.0f;

    private CharacterController _controller;
    private Vector3 _moveDirection = Vector3.zero;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_controller.isGrounded)
        {
            SetMoveDirection();

            if (Input.GetButton("Jump"))
            {
                Jump();
            }
        }

        Rotate();

        _moveDirection.y -= _gravity * Time.deltaTime;
        _controller.Move(_moveDirection * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Slope();
    }

    private void SetMoveDirection()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontalInput, 0, verticalInput);
        inputDirection = transform.TransformDirection(inputDirection);
        _moveDirection = inputDirection * _speed;
    }

    private void Jump()
    {
        _moveDirection.y = _jumpForce;
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.up, -_rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }

    private void Slope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, _slopeRayLength) == false)
            return;

        if (Vector3.Angle(hit.normal, Vector3.up) > _controller.slopeLimit)
        {
            _moveDirection.x += (1f - hit.normal.y) * hit.normal.x * _slopeForce;
            _moveDirection.z += (1f - hit.normal.y) * hit.normal.z * _slopeForce;
            _moveDirection.y -= _slopeForce;
        }
    }
}
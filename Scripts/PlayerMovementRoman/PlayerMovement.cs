using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis(Horizontal);
        transform.Rotate(rotation * _rotateSpeed * Time.deltaTime * Vector3.up);
    }

    private void Move()
    {
        float direction = Input.GetAxis(Vertical);
        float distance = direction * _moveSpeed * Time.deltaTime;

        transform.Translate(distance * Vector3.forward);
    }
}
using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _playerPosition;

    private void Start()
    {
        _playerPosition = transform.position - _player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = _player.transform.position + _playerPosition;
    }
}
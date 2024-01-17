﻿using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _zoomSpeed = 10f;
    [SerializeField] private float _rotateSpeed = 10f;

    [SerializeField] private float _minZoom = 15f;
    [SerializeField] private float _maxZoom = 30f;

    private void Update()
    {
        TryRotate(-_rotateSpeed, KeyCode.A);
        TryRotate(_rotateSpeed, KeyCode.D);

        Move();
        Zoom();
    }

    private void TryRotate(float rotateSpeed, KeyCode key)
    {
        if (Input.GetKey(key))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self);
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0, vertical) * Time.deltaTime, Space.Self);
    }

    private void Zoom()
    {
        transform.position += transform.up * _zoomSpeed * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, _minZoom, _maxZoom), transform.position.z);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _checkGroundTransform;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private int coins;
    [SerializeField] private Text coinsText;
    [Header("Settings")]
    [SerializeField] private float _checkRadiusSphere = 0.2f;
    [SerializeField] private float _gravity = -10f;
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _speedRun = 7f;
    [SerializeField] private float _jumpHeight = 1f;

    [Range(1, 15)]
    [SerializeField] private float _sensetivity = 7f;

    float rotationX;
    bool isGrounded;

    Vector3 velocity;
    Vector3 move;

    void Update()
    {
        Velocity();
        Move();
        Rotate();
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensetivity;
        float mouseY = Input.GetAxis("Mouse Y") * _sensetivity;

        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        _cameraTransform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        transform.Rotate(Vector3.up * mouseX);
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        move = transform.forward * moveY + transform.right * moveX;

        if (Input.GetKey(KeyCode.LeftShift) && (moveX != 0 || moveY != 0))
        {
            _characterController.Move(move * _speedRun * Time.deltaTime);
        }
        else
        {
            _characterController.Move(move * _speed * Time.deltaTime);
        }
    }

    private void Velocity()
    {
        isGrounded = Physics.CheckSphere(_checkGroundTransform.position, _checkRadiusSphere, _groundMask);

        velocity.y += Time.deltaTime * _gravity;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }

        _characterController.Move(velocity * Time.deltaTime);
    }
}

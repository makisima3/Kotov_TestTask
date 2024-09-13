using System;
using Code.Player.Configs;
using UnityEngine;
using Zenject;

namespace Code.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [Inject] private PlayerActionConfig playerActionConfig;

        private CharacterController _characterController;
        private Camera _camera;

        private float _cameraRotationX;
        private bool _isGrounded;
        private Vector3 velocity;
        
        private void Awake()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            _characterController = GetComponent<CharacterController>();
            _camera = Camera.main;
        }

        private void Update()
        {
            ProcessCamera();
            ProcessMovement();
        }

        private void ProcessCamera()
        {
            var mouseX = Input.GetAxis("Mouse X") * playerActionConfig.CameraSensitivity * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * playerActionConfig.CameraSensitivity * Time.deltaTime;

            _cameraRotationX -= mouseY;
            _cameraRotationX = Mathf.Clamp(_cameraRotationX, playerActionConfig.MinVerticalAngel, playerActionConfig.MaxVerticalAngel);

            _camera.transform.localRotation = Quaternion.Euler(_cameraRotationX, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }

        private void ProcessMovement()
        {
            _isGrounded = Physics.CheckSphere(transform.position, playerActionConfig.DistanceToGround, playerActionConfig.GroundMask);

            if(_isGrounded && velocity.y < 0)
                velocity.y = -2f;

            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            var move = transform.right * x + transform.forward * z;

            _characterController.Move(move * playerActionConfig.MoveSpeed * Time.deltaTime);

            if(Input.GetButtonDown("Jump") && _isGrounded)
            {
                velocity.y = Mathf.Sqrt(playerActionConfig.JumpForce * -2f * -playerActionConfig.Gravity);
            }

            velocity.y += -playerActionConfig.Gravity * Time.deltaTime;

            _characterController.Move(velocity * Time.deltaTime);
        }
    }
}
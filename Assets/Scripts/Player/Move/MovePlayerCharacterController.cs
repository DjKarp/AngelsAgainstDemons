using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AngelsAgainstDemons
{
    [RequireComponent(typeof(CharacterController))]
    public class MovePlayerCharacterController : MovePlayer
    {
        private CharacterController _characterController;
        private MovePlayerCharacterControllerGravity _gravity;

        private Vector2 _moveDirection;

        private float _jumpMaxHeight = 2.0f;
        private float _jumpStartVelocity = 3.0f;
        private float _jumpTimeOnMaxHeight = 0.4f;


        public MovePlayerCharacterController(CharacterController characterController)
        {
            _characterController = characterController;

            _gravity = new MovePlayerCharacterControllerGravity();

            _gravity.GravityForce = (2.0f * _jumpMaxHeight) / Mathf.Pow(_jumpTimeOnMaxHeight, 2);
            _jumpStartVelocity = (2.0f * _jumpMaxHeight) / _jumpTimeOnMaxHeight;
        }

        public override bool IsGrounded()
        {
            return _characterController.isGrounded;
        }

        public override void Move(Vector2 moveVector)
        {
            Jump(moveVector);

            _moveDirection.x = moveVector.x * Speed;
            _moveDirection.y = _gravity.CalculateGravity(_moveDirection.y);
            _characterController.Move(_moveDirection * Time.deltaTime);
        }

        private void Jump(Vector2 moveVector, bool isJump = false)
        {
            if (_characterController.isGrounded && (isJump || moveVector.y > 0.1f))
                _moveDirection.y = _jumpStartVelocity;
        }
    }
}

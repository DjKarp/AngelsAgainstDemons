using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AngelsAgainstDemons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovePlayerRigidbody : MovePlayer
    {
        private Rigidbody2D _rigidbody2D;

        private Vector2 _moveOffset = Vector2.zero;
        private bool _isJumping = false;
        private float _jumpingForce = 50.0f;
        private float _distanceCheckGroung = 1.3f;
        private float _checkGroundDelay = 1.0f;

        public MovePlayerRigidbody(Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
        }

        public override bool IsGrounded()
        {
            return !_isJumping;
        }

        public override void Move(Vector2 moveVector)
        {
            if (moveVector != Vector2.zero)
            {
                if (!_isJumping && moveVector.y > 0.0f)
                {
                    _rigidbody2D.AddForce(new Vector2(0.0f, _jumpingForce), ForceMode2D.Impulse);
                    _isJumping = true;
                    _checkGroundDelay = 1.0f;
                }
                else
                {
                    _moveOffset = new Vector2(moveVector.x, 0.0f) * Speed;
                    _rigidbody2D.velocity = _moveOffset;
                }
            }

            if (_isJumping)
                CheckGroungUnderPlayer();
        }

        private void CheckGroungUnderPlayer()
        {
            if (_checkGroundDelay > 0)
                _checkGroundDelay -= Time.deltaTime;
            else
            {
                RaycastHit2D hit2D = Physics2D.Raycast(_rigidbody2D.position, Vector2.down, _distanceCheckGroung, LayerMask.GetMask("Ground"));
                if (hit2D.collider != null)
                {
                    _isJumping = false;
                }
            }
        }  
    }
}

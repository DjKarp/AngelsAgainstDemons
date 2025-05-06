using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngelsAgainstDemons
{
    public class AnimationController : MonoBehaviour
    {
        private Animator _animator;
        private Transform _transform;

        private void Start()
        {
            _animator = gameObject.GetComponent<Animator>();
            _transform = gameObject.GetComponent<Transform>();
        }

        public void SetMoveJumpAnimation(Vector2 inputDirection, MovePlayer movePlayer)
        {
            if (inputDirection.x != 0.0f)
            {
                Run(true);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, inputDirection.x < 0 ? 180.0f : 0.0f, transform.rotation.eulerAngles.z);
            }
            else if (movePlayer.IsGrounded() && _animator.GetBool("isRun"))
                Run(false);

            if (inputDirection.y != 0.0f)
                Jump(true);
            else if (movePlayer.IsGrounded() && _animator.GetBool("isJump"))
                Jump(false);
        }

        private void Jump(bool isJump)
        {
            _animator.SetBool("isJump", isJump);
        }

        private void Run(bool isRun)
        {
            _animator.SetBool("isRun", isRun);
        }    
    }
}

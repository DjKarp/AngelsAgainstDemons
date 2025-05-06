using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngelsAgainstDemons
{    
    public class Player : MonoBehaviour
    {
        private MovePlayer _movePlayer;
        private GameInput _inputMove;
        private AnimationController _animationController;

        private Vector2 _inputDirection;

        public void Init(MovePlayer movePlayer, GameInput inputMove)
        {
            _movePlayer = movePlayer;
            _inputMove = inputMove;
            _animationController = gameObject.AddComponent<AnimationController>();
        }

        private void LateUpdate()
        {
            _inputDirection = _inputMove.GetMoveDirection();
            _movePlayer.Move(_inputDirection);
            _animationController.SetMoveJumpAnimation(_inputDirection, _movePlayer);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AngelsAgainstDemons
{
    public abstract class MovePlayer
    {
        protected float Speed = 5.0f;

        public abstract void Move(Vector2 moveVector);

        public abstract bool IsGrounded();        
    }
}

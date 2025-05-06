using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngelsAgainstDemons
{
    public abstract class GameInput : MonoBehaviour
    {
        protected Vector2 JoystickDirection;

        public abstract Vector2 GetMoveDirection();
    }
}

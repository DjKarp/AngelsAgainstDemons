using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngelsAgainstDemons
{
    public class JoystickMove : Joystick
    {
        public override Vector2 GetMoveDirection()
        {
            return JoystickDirection;
        }
    }
}
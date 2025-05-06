using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngelsAgainstDemons
{
    public class KeyboardMove : GameInput
    {
        public override Vector2 GetMoveDirection()
        {
            JoystickDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            return JoystickDirection;
        }
    }
}

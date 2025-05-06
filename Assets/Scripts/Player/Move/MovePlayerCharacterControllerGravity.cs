using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngelsAgainstDemons
{
    public class MovePlayerCharacterControllerGravity
    {
        private float _gravityForce = 1.0f;
        public float GravityForce { get => _gravityForce; set => _gravityForce = value; }

        public float CalculateGravity(float moveDirectionY)
        {
            moveDirectionY -= _gravityForce * Time.deltaTime;
            return moveDirectionY;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngelsAgainstDemons
{
    public class PlayerCharacterController : Player
    {
        [SerializeField] private CharacterController _characterController;
        public CharacterController CharacterController { get => _characterController; }

    }
}

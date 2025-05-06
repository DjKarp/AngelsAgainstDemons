using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngelsAgainstDemons
{
    public class PlayerRigidbody : Player
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        public Rigidbody2D Rigidbody2D { get => _rigidbody2D; }
    }
}

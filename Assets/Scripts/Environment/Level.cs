using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngelsAgainstDemons
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;
        public Vector3 StartPointPosition { get => _startPoint.position; }
    }
}

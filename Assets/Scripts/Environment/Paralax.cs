using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngelsAgainstDemons
{
    public class Paralax : MonoBehaviour
    {
        private Transform _transform;
        private Transform _cameraTransform;

        [SerializeField, Range(0.0f, 1.0f)] private float _paralaxSpeed = 0.5f;
        private Vector3 _previousCameraPosition;
        private Vector3 _differentPosition;

        private void Start()
        {
            _transform = gameObject.transform;
            _cameraTransform = Camera.main.transform;
        }

        private void LateUpdate()
        {
            _differentPosition = _cameraTransform.position - _previousCameraPosition;
            _differentPosition.y = 0.0f;
            _previousCameraPosition = _cameraTransform.position;
            _transform.position += _differentPosition * _paralaxSpeed;
        }
    }
}

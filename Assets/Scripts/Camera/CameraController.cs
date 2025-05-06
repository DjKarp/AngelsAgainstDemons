using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AngelsAgainstDemons
{
    public class CameraController : MonoBehaviour
    {
        public Transform PlayerTransform { set => _playerTransform = value; }
        private Transform _playerTransform;
        private Transform _cameraTransform;
        private float _cameraSpeed = 1.0f;

        private void Awake()
        {
            _cameraTransform = gameObject.transform;
        }

        private void LateUpdate()
        {
            if (_playerTransform != null && Mathf.Abs(_playerTransform.position.x - _cameraTransform.position.x) > 4.0f)
            {
                var newX = Mathf.LerpUnclamped(_cameraTransform.position.x, _playerTransform.position.x, Time.deltaTime * _cameraSpeed);
                _cameraTransform.position = new Vector3(newX, _cameraTransform.position.y, _cameraTransform.position.z);
            }
        }
    }
}

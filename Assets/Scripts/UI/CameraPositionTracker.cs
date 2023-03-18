using System;
using UnityEngine;

namespace UI
{
    public class CameraPositionTracker : MonoBehaviour
    {
        private Transform _cameraTransform;
        private Vector3 _lastPosition;

        public event Action<Vector3> onOnCameraPositionChanged;

        private void Start()
        {
            _cameraTransform = Camera.allCameras[0].transform;
            _lastPosition = _cameraTransform.position;
        }

        private void LateUpdate()
        {
            CheckCameraPosition();
        }

        private void CheckCameraPosition()
        {
            if (_cameraTransform.position == _lastPosition) return;
            _lastPosition = _cameraTransform.position;
            onOnCameraPositionChanged?.Invoke(_lastPosition);
        }
    }
}
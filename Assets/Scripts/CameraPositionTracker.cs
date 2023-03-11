using System;
using UnityEngine;

public class CameraPositionTracker: MonoBehaviour
{
    private Transform _cameraTransform;
    private Vector3 _lastPosition;
        
    public event Action<Vector3> onOnCameraPositionChanged;
        
    private void Start()
    {
        _lastPosition = _cameraTransform.position;
        _cameraTransform = Camera.allCameras[0].transform;
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
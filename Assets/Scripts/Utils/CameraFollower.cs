using System;
using UnityEngine;

namespace Utils
{
    /*
     * CameraFollower work only in Play mode
     */
    public sealed class CameraFollower : MonoBehaviour
    {
        [SerializeField] [Range(0,2f)] private float _smoothTime = 0.5f;
        [SerializeField] private Transform _characterSkeleton;

        [SerializeField] private Vector3 _offset;
        private Vector3 currentVelocity = Vector3.zero;

        private void Awake()
        {
            if (enabled)
            {
                if (!_characterSkeleton) throw new NotImplementedException("[CameraFollower]: not inited _characterSkeleton ");
                UpdateCameraPosition();
            }
        }

        private void UpdateCameraPosition(bool useSmooth = false)
        {
            Vector3 cameraTargetPosition = _characterSkeleton.position + _offset;
            if (useSmooth)
            {
                cameraTargetPosition = Vector3.SmoothDamp(transform.position, cameraTargetPosition,
                    ref currentVelocity, _smoothTime);
            }
            transform.position = cameraTargetPosition;
        }

        private void FixedUpdate()
        {
            UpdateCameraPosition(true);
        }
    }
}
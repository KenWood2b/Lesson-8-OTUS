using UnityEngine;

namespace Components
{
    public sealed class RotateComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform rotationTarget;
        
        [SerializeField]
        private float angularSpeed = 180;

        [SerializeField]
        private Vector3 rotationDirection;
        
        public Vector3 RotationDirection
        {
            get => rotationDirection;
            set => rotationDirection = value;
        }

        private void FixedUpdate()
        {
            if (rotationDirection == Vector3.zero)
            {
                return;
            }

            Quaternion currentRotation = rotationTarget.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(rotationDirection);
            Quaternion nextRotation = Quaternion.RotateTowards(currentRotation, targetRotation, angularSpeed);

            rotationTarget.rotation = nextRotation;
        }
    }
}
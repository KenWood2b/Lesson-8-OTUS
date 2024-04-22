using UnityEngine;

namespace Game.Engine
{
    public sealed class SmoothRotateAction : MonoBehaviour
    {
        [SerializeField]
        private Transform rotationTransform;

        [SerializeField, Range(1, 50)]
        private float rotationSpeed = 25.0f;

        public void RotateTowards(Vector3 direction, float deltaTime)
        {
            this.RotateTowards(direction, deltaTime, this.rotationSpeed);
        }
        
        public void RotateTowards(Vector3 direction, float deltaTime, float speed)
        {
            float percent = speed * deltaTime;
            Quaternion currentRotation = this.rotationTransform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Quaternion nextRotation = Quaternion.Slerp(currentRotation, targetRotation, percent);
            this.rotationTransform.rotation = nextRotation;
        }
    }
}
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private Vector3 moveDirection;
        
        public Vector3 MoveDirection
        {
            get => moveDirection;
            set => moveDirection = value;
        }

        public bool IsMoving => MoveDirection != Vector3.zero;
    }

}
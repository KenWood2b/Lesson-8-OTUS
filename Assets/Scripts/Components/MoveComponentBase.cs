using UnityEngine;

namespace Components
{
    public abstract class MoveComponentBase : MonoBehaviour
    {
        [SerializeField]
        private Vector3 moveDirection;

        public Vector3 MoveDirection
        {
            get => moveDirection;
            set => moveDirection = value;
        }

        public abstract bool IsWalking { get; }
    }
}
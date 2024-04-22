using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Rigidbody))]
    public class MoveWalkComponent : MoveComponentBase
    {
        //public bool IsMoving => MoveDirection != Vector3.zero;
        public override bool IsWalking => MoveDirection != Vector3.zero;
    }
}



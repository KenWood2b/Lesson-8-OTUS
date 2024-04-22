using Components;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public sealed class MoveAnimatorController : MonoBehaviour
    {
        [SerializeField] private MoveComponentBase moveComponent;
        
        private Animator _animator;
        
        private static readonly int HashIsWalking = Animator.StringToHash("IsMoving");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetBool(HashIsWalking, moveComponent.IsWalking);
        }
    }
}
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public sealed class ShootAnimatorTrigger : MonoBehaviour
    {
        private Animator _animator;
        
        private static readonly int Shoot = Animator.StringToHash("Shoot");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetShootTrigger()
        {
            _animator.SetTrigger(Shoot);
        }
    }
}
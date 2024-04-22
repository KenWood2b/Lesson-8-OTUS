using Components;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public sealed class DeathAnimatorTrigger : MonoBehaviour
    {
        [SerializeField]
        private HealthComponent healthComponent;

        private Animator _animator;
        
        private static readonly int Death = Animator.StringToHash("Death");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            healthComponent.OnDeath += SetDeathTrigger;
        }
        
        private void OnDisable()
        {
            healthComponent.OnDeath -= SetDeathTrigger;
        }
        private void SetDeathTrigger()
        {
            _animator.SetTrigger(Death);
        }
    }
}
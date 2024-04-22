using Components;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public sealed class TakeDamageAnimatorTrigger : MonoBehaviour
    {
        [SerializeField] private HealthComponent healthComponent;
        
        private Animator _animator;
        
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            healthComponent.OnTakeDamage += SetDamageTrigger;
        }

        private void OnDisable()
        {
            healthComponent.OnTakeDamage -= SetDamageTrigger;
        }
        private void SetDamageTrigger()
        {
            _animator.SetTrigger(TakeDamage);
        }
    }
}
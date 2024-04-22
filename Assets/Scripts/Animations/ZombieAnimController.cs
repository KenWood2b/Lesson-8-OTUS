using Components;
using Game.Engine;
using UnityEngine;

namespace Game.Content
{
    [RequireComponent(typeof(Animator))]
    public sealed class ZombieAnimController : MonoBehaviour
    {
        private const string ExtraLayer = "Extra Layer";
        private const string DeathState = "Death";
        
        //private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Death = Animator.StringToHash("Death");
        
        private Animator animator;

        private int extraLayerIndex;
        
        [SerializeField] private HealthComponent healthComponent;
        [SerializeField] private MoveComponentBase _moveComponent;
        
        private void Awake()
        {
            this.animator = this.GetComponent<Animator>();
            this.extraLayerIndex = this.animator.GetLayerIndex(ExtraLayer);
        }

        private void FixedUpdate()
        {
            this.CheckAttack();
            this.CheckDeath();
        }

        private void CheckAttack()
        {
            if (_moveComponent.IsWalking)
            {
                this.animator.ResetTrigger(Attack);
            }
        }

        private void CheckDeath()
        {
            if (this.healthComponent.IsAlive)
            {
                return;
            }

            AnimatorStateInfo state = this.animator.GetCurrentAnimatorStateInfo(this.extraLayerIndex);
            if (state.IsName(DeathState))
            {
                return;
            }

            this.animator.SetTrigger(Death);
        }
    }
}
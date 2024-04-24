using UnityEngine;
using Components;
using Game.Engine;
using System;

namespace Game.Content
{
    public sealed class Zombie : MonoBehaviour
    {
        [SerializeField] private HealthComponent healthComponent;
        [SerializeField] private ZombieController _zombieController;
        [SerializeField] private AimComponent aimComponent;
        [SerializeField] private SmoothRotateAction rotateAction;
        [SerializeField] private Collider _zombiCollider;
        [SerializeField] private MoveComponentBase moveComponent;
        [SerializeField] private Rigidbody _rb;
        private bool isAlive;

        /* FixedUpdate()
         * При наступление смерти Zombie ZombieController, AimComponent и SmoothRotateAction должны перестать работать
         * SmoothRotateAction.RotateTowards должен использовать для вращения Zombie только если есть цель (направление) вращения
         */
        private void Start()
        {
            isAlive = true;
            _zombiCollider.enabled = true;
        }

        private void OnEnable()
        {
            healthComponent.OnDeath += Die;
        }

        private void OnDisable()
        {
            healthComponent.OnDeath -= Die;
        }

        private void Die()
        {
            isAlive = false;
            _zombiCollider.enabled = false;
             moveComponent.MoveDirection = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            _rb.velocity = Vector3.zero;
        }

        private void FixedUpdate()
        {
            if (!isAlive)
            {
                return;
            }
                
            SmoothRotate();
            _zombieController.OnFixedUpdate();
            
        }

        /*
         * При наступление смерти Zombie он не должен мешать передвижени других зомби и игрока (Реакция по наступлению события)
         */
        private void SmoothRotate()
        {
            if(aimComponent.IsRotating)
            {
                rotateAction.RotateTowards(aimComponent.DirectionToAim, Time.fixedDeltaTime);
            }
            
        }
    }
}
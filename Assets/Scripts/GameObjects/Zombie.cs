using UnityEngine;
using Components;
using Game.Engine;

namespace Game.Content
{
    public sealed class Zombie : MonoBehaviour
    {
        [SerializeField] private HealthComponent healthComponent;
        [SerializeField] private ZombieController _zombieController;
        [SerializeField] private AimComponent aimComponent;
        [SerializeField] private SmoothRotateAction rotateAction;
        
        /* FixedUpdate()
         * При наступление смерти Zombie ZombieController, AimComponent и SmoothRotateAction должны перестать работать
         * SmoothRotateAction.RotateTowards должен использовать для вращения Zombie только если есть цель (направление) вращения
         */

        private void FixedUpdate()
        {
            CheckIsDead();
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
        private void CheckIsDead()
        {
            if (healthComponent.Health == 0)
            {
                _zombieController.enabled = false;
                aimComponent.enabled = false;
                rotateAction.enabled = false;
            }
        }
    }
}
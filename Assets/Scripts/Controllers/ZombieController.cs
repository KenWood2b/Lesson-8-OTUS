#pragma warning disable 414
using System;
using Components;
using Game.Content;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Engine
{
    public enum ZombieState
    {
        IDLE,
        TryCatchEnemy,
        AttackEnemy,
    }
    
    [Serializable]
    public sealed class ZombieController : MonoBehaviour
    {
        [SerializeField] private Transform _enemyTransform;
        [SerializeField] private Transform _zombieTransform;
        [SerializeField] private float _attackDistance = 1.1f;
        [Tooltip("Only for information")]
        [ShowInInspector,ReadOnly] private ZombieState _state;  //Used only for debug
        private MoveComponentBase _myMoveComponent;
        private AimComponent _myAimComponent;
        private HealthComponent _enemyHealthComponent;

        private void Awake()
        {
            _enemyHealthComponent = _enemyTransform.GetComponentInParent<HealthComponent>();
            _myMoveComponent = GetComponent<MoveComponentBase>();
            _myAimComponent = GetComponent<AimComponent>();
        }
        public void OnFixedUpdate()
        {
            /*
             * Действия в ZombieController должны вызываться синхроно с Zombie
             * В случае смерти цели зомби не должен двигаться, отсутствие цели не должно вызывать ошибку
             */
          
            if(!_enemyTransform)
            {
                return;
            }
            if (!_enemyHealthComponent.IsAlive)
            {
                IdleState();
                return;
            }
            Vector3 directionToEnemy = GetDirectionToEnemy();
            float distance = directionToEnemy.magnitude;

            if (distance < _attackDistance)
            {
                AttackEnemy(directionToEnemy);
            }
            else
            {
                TryCatchEnemy(directionToEnemy);
            }
        }


        private Vector3 GetDirectionToEnemy()
        {
            /*
             * Определяет вектор движения на каждой итерации цикла (необходимо чтобы перемещение было только в рамках плоскости ХZ)
             */
            Vector3 myPosition = _zombieTransform.position;
            Vector3 targetPosition = _enemyTransform.position;
            Vector3 moveDirection = targetPosition - myPosition;
            moveDirection.y = 0;
            Debug.DrawRay(myPosition, moveDirection, Color.red);  //- Can be used for Debug

            
            return moveDirection;
        }

        private void IdleState()
        {
            _state = ZombieState.IDLE;

            /*
             *   Zombie не должен двигаться, но должен поворачиваться на цель
             *   Должен находиться в данном состояние в случае сметри цели
             *   Имеет преимущества на всеми другими состояниями
             */
            _myMoveComponent.MoveDirection = Vector3.zero;
            _myAimComponent.SetDirection(_zombieTransform.forward);
            //_myAimComponent.SetDirection(new Vector3 (1, 0, 0));
        }

        private void TryCatchEnemy(Vector3 moveDirection)
        {
            _state = ZombieState.TryCatchEnemy;

            /*
             *  Zombie должен двигаться по направлению к цели и поворачиваться  на цель
             *   Должен переходить в данное состояние если расстояние до цели больше дистанции атаки
             */
            _myMoveComponent.MoveDirection = moveDirection;
            _myAimComponent.SetDirection(moveDirection);
        }

        private void AttackEnemy(Vector3 moveDirection)
        {
			_state = ZombieState.AttackEnemy;
			
            /*
             *  Zombie должен атаковать цель (в данный HW не используется)
             */
            
			// код ниже только для Debug в рамках данной HW
			Debug.LogWarning($"[ZombieController]: AttackEnemy({moveDirection})");
            IdleState();
            this.GetComponent<Zombie>().enabled = false;
        }
    }
}
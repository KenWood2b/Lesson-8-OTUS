using System;
using UnityEngine;
using Utils;

namespace Components
{   
    public sealed class MoveWithJumpComponent : MoveComponentBase
    {
        public override bool IsWalking => !_isJumping && MoveDirection != Vector3.zero;

        [SerializeField] private float _minLenghtJump;
        [SerializeField] [Range(0, 10)] private float _minDelayJump = 2f;
        [Tooltip("_minDelayJump * (1 + _addToMinDelayJump")]
        [SerializeField] [Range(0, 2)] private float _addToMinDelayJump = 1f;
        [SerializeField] private JumpComponent _jumpComponent;
         private TimerRandomDelay _jumpTimer;
         private bool _isJumping;
        

        private void Awake()
        {
            _isJumping = false;
            float maxDelay = _minDelayJump * (1 + _addToMinDelayJump);
            _jumpTimer = new TimerRandomDelay(_minDelayJump, maxDelay, Time.fixedDeltaTime);
        }

        private void FixedUpdate()
        {
            /*
             * В случае если расстояние до цели больше чем _minLenghtJump
             * после задержки прыжка (через таймер) на интервал времени, определяемый переменными _minDelayJump и maxDelay
             * осуществить прыжок по направлению движения (угол прыжка 45 градсов к плоски перемещения)
             * следующий прыжок только через новый интервал времени, пределяемый переменными _minDelayJump и maxDelay
             *  для осуществления прыжка использовать метод JumpComponent.MoveByJump
             *
             *  Во всех остальных случаях зомби должен перемещаться by walking root animations
             */
            if (_isJumping)
                return;
            float distance = MoveDirection.magnitude;
            if(distance < _minLenghtJump)
            {
                return;
            }
            if (_jumpTimer.IsTimeFinish())
            {
                _isJumping = true;
                _jumpComponent.MoveByJump(AfterJump);
            }


        }

        private void AfterJump()
        {
            _isJumping = false;
            _jumpTimer.ResetTimer();

        }
    }
}
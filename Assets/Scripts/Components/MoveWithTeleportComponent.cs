using System;
using UnityEngine;
using UnityEngine.UIElements;
using Utils;
using Random = UnityEngine.Random;

namespace Components
{   
    public sealed class MoveWithTeleportComponent : MoveComponentBase
    {
        public override bool IsWalking => !_isTeleporting && MoveDirection != Vector3.zero;

        [SerializeField] private float _maxLenghtTeleport = 10f;
        [SerializeField] private float _minLenghtTeleport = 4f;
        [SerializeField] [Range(0, 10)] private float _minDelayTeleport = 2f;

        [Tooltip("_minDelayJump * (1 + _addToMinDelayTeleport")]
        [SerializeField] [Range(0, 2)] private float _addToMinDelayTeleport = 1f;
        [SerializeField] private TeleportComponent _teleportComponent;
        private TimerRandomDelay _teleportTimer;
        private bool _isTeleporting;

        private void Awake()
        {
            _isTeleporting = false;
            float maxDelay = _minDelayTeleport * (1 + _addToMinDelayTeleport);
            _teleportTimer = new TimerRandomDelay(_minDelayTeleport, maxDelay, Time.fixedDeltaTime);
        }

        private void FixedUpdate()
        {
            /*
             * В случае если расстояние до цели больше чем _maxLenghtTeleport
             * после задержки телепорта (через таймер) на интервал времени, определяемый переменными _minDelayTeleport и maxDelay
             * осуществить телепорт по направлению движения
             * на дистанцию определяумый случайной величиное в диапозе между  _minLenghtTeleport и _maxLenghtTeleport включительно
             * следующий телепорт только через новый интервал времени, пределяемый переменными _minDelayJump и maxDelay
             *  для осуществления телепорта использовать метод TeleportComponent.MoveByTeleport
             *
             * Во всех остальных случаях зомби должен перемещаться by walking root animations
             */
            if (_isTeleporting)
                return;
            float distance = MoveDirection.magnitude;
            if (distance < _maxLenghtTeleport)
            {
                return;
            }
            if (_teleportTimer.IsTimeFinish())
            {
                _isTeleporting = true;
               float lenght = Random.Range(_minLenghtTeleport, _maxLenghtTeleport);
                _teleportComponent.MoveByTeleport(AfterTeleporting, MoveDirection, lenght);
            }
        }

        private void AfterTeleporting()
        {
            _isTeleporting = false;
            _teleportTimer.ResetTimer();
        }
    }
}
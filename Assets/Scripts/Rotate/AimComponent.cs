using UnityEngine;

namespace Game.Engine
{
    public sealed class AimComponent : MonoBehaviour
    {
        public Vector3 DirectionToAim => _currentDirection;
        public bool IsRotating => _turnONAiming && _currentDirection.sqrMagnitude > 0;

        private Vector3 _currentDirection;
        private bool _turnONAiming;

        private void Awake()
        {
            _turnONAiming = true;
        }

        public void SetDirection(Vector3 moveDirection)
        {
            _currentDirection = moveDirection;
        }

        /// <summary>
        /// ONLY FYI Возможность временно отключить фиксацию направления поворота зомби на цель, через влияние на значения свойства IsRotating
        /// </summary>
        /// <param name="activate"></param>
        public void TurnONAiMing(bool activate)
        {
            _turnONAiming = activate;
        }
    }
}
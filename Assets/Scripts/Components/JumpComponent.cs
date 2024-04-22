using System;
using System.Collections;
using Animations;
using JetBrains.Annotations;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class JumpComponent : MonoBehaviour
    {
        [SerializeField] private float _powerJump = 1000f;
        [SerializeField] private Transform _jumpDirection;
        [SerializeField] private JumpAnimatorTrigger _jumpTrigger;

        private Rigidbody _rg;
        private Action _actionAfterJump;

        private void Awake()
        {
            _rg = GetComponent<Rigidbody>();
        }

        public void MoveByJump(Action actionAfterJump)
        {
            _actionAfterJump = actionAfterJump;
            //Запустить анимацию прыжка
            _jumpTrigger.SetTrigger();
        }
        
        [UsedImplicitly]
        public void Jump()
        {
            _rg.AddForce(_jumpDirection.up * _powerJump, ForceMode.Impulse);
            StartCoroutine(CoroutineIsGrounded());
        }

        private IEnumerator CoroutineIsGrounded()
        {
            do
                yield return null;
            while (_rg.velocity != Vector3.zero);
            _actionAfterJump.Invoke();
        }
    }
}
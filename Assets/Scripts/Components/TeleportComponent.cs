using System;
using System.Collections;
using Animations;
using Game.Engine;
using JetBrains.Annotations;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class TeleportComponent : MonoBehaviour
    {
        [SerializeField] private AimComponent _aimComponent;
        [SerializeField] private float _burrowSpeed = 1f;
        [SerializeField] private float _burrowDepth = 2f;
        [SerializeField] private float _speedMoveUnderground = 1f;
        [SerializeField] private SpinAnimatorTrigger _spinTrigger;

        private bool _nowToBurrow;
        private Rigidbody _rg;
        private Collider _collider;
        private float _burrowSpeedPerFixUpdate;
        private Action _actionAfterTeleport;
        private Vector3 _teleportVectorNorm;
        private float _lenghtTeleport;

        private void Awake()
        {
            _rg = GetComponent<Rigidbody>();
            _collider = GetComponentInChildren<Collider>();
            _nowToBurrow = true;
            _burrowSpeedPerFixUpdate = _burrowSpeed * Time.fixedDeltaTime;
        }

        public void MoveByTeleport(Action actionAfterTeleport, Vector3 MoveDirection, float lenghtTeleport)
        {
            _lenghtTeleport = lenghtTeleport;
            _actionAfterTeleport = actionAfterTeleport;
            _teleportVectorNorm = MoveDirection.normalized ;
            _aimComponent.TurnONAiMing(false);
            //Запустить анимацию телепорта
            _spinTrigger.SetTrigger();
        }

        [UsedImplicitly]
        public void Teleport()
        {
            if (_nowToBurrow)
            {
                PrepareToTeleport(true);
                StartCoroutine(CoroutineBurrow());
            }
            else
            {
                StartCoroutine(CoroutineDigOut());
            }
        }

        [UsedImplicitly]
        public void TeleportEnd()
        {
            if (_nowToBurrow)
            {
                _nowToBurrow = false;
            }
            else
            {
                PrepareToTeleport(false);
                _aimComponent.TurnONAiMing(true);
                _nowToBurrow = true;
                _actionAfterTeleport.Invoke();
            }
        }

        private IEnumerator CoroutineBurrow()
        {
            yield return CoroutineGoUnderground();
            yield return new WaitForSeconds(_lenghtTeleport / _speedMoveUnderground);
            transform.Translate(_teleportVectorNorm * _lenghtTeleport,Space.World);
            //Запустить анимацию телепорта
            _spinTrigger.SetTrigger();
        }

        private IEnumerator CoroutineGoUnderground()
        {
            float targetPosY = transform.position.y - _burrowDepth;
            do
            {
                transform.Translate(Vector3.down * _burrowSpeedPerFixUpdate,Space.Self);
                yield return new WaitForFixedUpdate();
            } while (transform.position.y > targetPosY);
        }

        private IEnumerator CoroutineDigOut()
        {
            float targetPosY = transform.position.y + _burrowDepth;
            do
            {
                transform.Translate(Vector3.up * _burrowSpeedPerFixUpdate,Space.Self);
                yield return new WaitForFixedUpdate();
            } while (targetPosY > transform.position.y);
        }

        private void PrepareToTeleport(bool active)
        {
            _rg.useGravity = !active;
            _collider.enabled = !active;
        }
    }
}
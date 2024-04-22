using System;
using Components;
using UnityEngine;

namespace Controllers
{
    public sealed class FireController : MonoBehaviour
    {
        [SerializeField]
        private GameObject characterGameObject;
        
        private AttackComponent _attackComponent;

        private void Start()
        {
            _attackComponent = characterGameObject.GetComponent<AttackComponent>();
            if (!_attackComponent) throw new NotImplementedException("[FireController]: Absent AttackComponent");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _attackComponent.Attack();
            }
        }
    }
}
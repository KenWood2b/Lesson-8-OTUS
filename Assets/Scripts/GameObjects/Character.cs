using Components;
using UnityEngine;

namespace GameObjects
{
    public sealed class Character : MonoBehaviour
    {
        [SerializeField] private HealthComponent healthComponent;
        [SerializeField] private MoveWalkComponent moveComponent;
        [SerializeField] private RotateComponent rotateComponent;
        [SerializeField] private WeaponComponent weaponComponent;
        private void FixedUpdate()
        {
            UpdateRotation();
            CheckIsAlive();
        }

        private void UpdateRotation()
        {
            rotateComponent.RotationDirection = moveComponent.MoveDirection;
        }

        private void CheckIsAlive()
        {
            if (healthComponent.Health == 0)
            {
                moveComponent.enabled = false;
                rotateComponent.enabled = false;
                weaponComponent.CanFire = false;
            }
        }
    }
}
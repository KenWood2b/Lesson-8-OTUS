using Components;
using UnityEngine;

namespace Animations.VFX
{
    public sealed class ShootWeaponVFXAnimationEvent : MonoBehaviour
    {
        [SerializeField] private WeaponComponent _weaponComponent;

        private void OnEnable()
        {
            _weaponComponent.OnFire += PlayShootVFX;
        }

        private void OnDisable()
        {
            _weaponComponent.OnFire  -= PlayShootVFX;
        }

        private void PlayShootVFX()
        {
            Debug.Log("[ShootWeaponVFXAnimationEvent]: ShootVFX()");
        }
    }
}
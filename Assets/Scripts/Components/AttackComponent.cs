using Animations;
using UnityEngine;

namespace Components
{
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField] private ShootAnimatorTrigger _shootAnimatorTrigger;

        [SerializeField] private WeaponComponent _weaponComponent;

        public void Attack()
        {
            if (_weaponComponent.CanFire)
            {
                _shootAnimatorTrigger.SetShootTrigger();
            }
        }
    }
}
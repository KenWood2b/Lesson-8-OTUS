using System;
using UnityEngine;

namespace Components
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        public event Action OnFire;
        
        [SerializeField]
        private Transform firePoint;

        [SerializeField]
        private GameObject bulletPrefab;
        
        [SerializeField]
        private bool canFire = true;

        [SerializeField]
        private float bulletForce = 10;

        [SerializeField]
        private ForceMode forceMode;
        
        public bool CanFire
        {
            get => canFire;
            set => canFire = value;
        }

        public void Fire()
        {
            if (!CanFire) return;
            
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Vector3 force = firePoint.forward * bulletForce;
            bullet.GetComponent<Rigidbody>().AddForce(force, forceMode);
                
            OnFire?.Invoke();
        }
    }
}
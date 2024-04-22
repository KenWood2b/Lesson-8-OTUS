using System;
using UnityEngine;

namespace Components
{
    public sealed class HealthComponent : MonoBehaviour
    {
        public event Action OnTakeDamage;
        public event Action OnDeath;
        
        [SerializeField]
        private int health;
        
        public int Health => health;

        public void TakeDamage(int damage)
        {
            health = Mathf.Max(0, health - damage);
            
            if (health <= 0)
                OnDeath?.Invoke();
            else
                OnTakeDamage?.Invoke();
        }
        
        public bool IsAlive => health > 0;
    }
}
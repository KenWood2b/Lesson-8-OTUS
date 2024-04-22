using Components;
using UnityEngine;

namespace Game.Engine
{
    public sealed class DealDamageAction : MonoBehaviour
    {
        public bool DealDamage(Collider collider, int damage)
        {
            HealthComponent lifeComponent = collider.GetComponentInParent<HealthComponent>();
            if (lifeComponent != null)
            {
                lifeComponent.TakeDamage(damage);
                return true;
            }

            return false;
        }
    }
}
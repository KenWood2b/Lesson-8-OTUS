using System;
using UnityEngine;

namespace Components
{
    public sealed class LifetimeComponent : MonoBehaviour
    {
        [SerializeField]
        private float lifetime;

        private void FixedUpdate()
        {
            if (lifetime > 0)
            {
                lifetime -= Time.fixedDeltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
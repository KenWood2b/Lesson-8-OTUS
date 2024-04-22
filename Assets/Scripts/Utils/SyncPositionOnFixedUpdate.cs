using UnityEngine;

namespace Utils
{
    public sealed class SyncPositionOnFixedUpdate : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        
        private void FixedUpdate()
        {
            transform.position = target.position;
        }
    }
}
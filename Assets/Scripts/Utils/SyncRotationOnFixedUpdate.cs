using UnityEngine;

namespace Utils
{
    public class SyncRotationOnFixedUpdate : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        
        private void FixedUpdate()
        {
            transform.rotation = target.rotation;
        }
    }
}
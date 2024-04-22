using UnityEngine;

namespace Utils
{
    public sealed class SetParentOnAwake : MonoBehaviour
    {
        [SerializeField]
        private Transform parent;

        [SerializeField]
        private bool worldPositionStays;
        
        private void Awake()
        {
            transform.SetParent(parent, worldPositionStays);
        }
    }
}
using UnityEngine;

namespace Animations.VFX
{
    public sealed class BloodDamageVFXAnimationEvent : MonoBehaviour
    {
        [SerializeField] private AnimationEventListener animationEventListener;

        private const string DamageEvent = "damage_event";

        private void OnEnable()
        {
            animationEventListener.OnMessageReceived += PlayBloodVFX;
        }

        private void OnDisable()
        {
            animationEventListener.OnMessageReceived -= PlayBloodVFX;
        }

        private void PlayBloodVFX(string message)
        {
            if (string.Equals(message, DamageEvent))
            {
                Debug.Log("[BloodDamageVFXAnimationEvent]: PlayBloodVFX()");
            }
        }
    }
}
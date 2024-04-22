using UnityEngine;

namespace Animations.VFX
{
    public sealed class DeathVFXAnimationEvent : MonoBehaviour
    {
        [SerializeField] private AnimationEventListener animationEventListener;

        private const string DamageEvent = "death_event";

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
                Debug.Log("[DeathVFXAnimationEvent]: PlayDeathVFX()");
            }
        }
    }
}
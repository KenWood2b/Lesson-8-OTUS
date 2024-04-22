using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public sealed class AnimationEventListener : MonoBehaviour
    {
        public event Action<string> OnMessageReceived;

        [SerializeField]
        private AnimationEvent[] events;
        
        [UsedImplicitly]
        private void ReceiveEvent(string message)
        {
            foreach (var animationEvent in events)
            {
                if (string.Equals(animationEvent.message, message))
                {
                    animationEvent.action.Invoke();
                }
            }

            OnMessageReceived?.Invoke(message);
        }

        [Serializable]
        private struct AnimationEvent
        {
            public string message;
            public UnityEvent action;
        }
    }
}
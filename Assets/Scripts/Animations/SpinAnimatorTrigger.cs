using Components;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public sealed class SpinAnimatorTrigger : AnimatorTriggerBase
    {
        private static readonly int Spine = Animator.StringToHash("Spine");
        public override void SetTrigger()
        {
            _animator.SetTrigger(Spine);
        }

    }
}


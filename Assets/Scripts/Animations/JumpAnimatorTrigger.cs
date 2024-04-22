using Components;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public sealed class JumpAnimatorTrigger : AnimatorTriggerBase
    {

        private static readonly int Jump = Animator.StringToHash("Jump");
        public override void SetTrigger()
        {
            _animator.SetTrigger(Jump);
        }

    }
}

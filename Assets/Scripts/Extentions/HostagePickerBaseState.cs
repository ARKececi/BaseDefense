using Controllers.HostagePickerController;
using UnityEngine;

namespace Extentions
{
    public abstract class HostagePickerBaseState
    {
        public abstract void EnterState(HostagePickerAnimationController playerState);
        public abstract void UpdateState(HostagePickerAnimationController playerState);
        public abstract void OnCollisionEnter(HostagePickerAnimationController playerState);
    }
}
using Controllers.HostageController;
using UnityEngine;

namespace Extentions
{
    public abstract class HostageBaseState
    {
        public abstract void EnterState(HostageAnimationController playerState);
        public abstract void UpdateState(HostageAnimationController playerState);
        public abstract void OnCollisionEnter(HostageAnimationController playerState);
    }
}
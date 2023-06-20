using Controllers.HostageController;
using UnityEngine;

namespace Extentions
{
    public abstract class HostageMinerBaseState
    {
        public abstract void EnterState(HostageMinnerAnimationController playerState);
        public abstract void UpdateState(HostageMinnerAnimationController playerState);
        public abstract void OnCollisionEnter(HostageMinnerAnimationController playerState);
    }
}
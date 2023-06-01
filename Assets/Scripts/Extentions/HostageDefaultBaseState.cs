using Controllers.HostageController;
using Controllers.HostageDefaultController;
using UnityEngine;

namespace Extentions
{
    public abstract class HostageDefaultBaseState
    {
        public abstract void EnterState(HostageDefaultAnimationController playerState);
        public abstract void UpdateState(HostageDefaultAnimationController playerState);
        public abstract void OnCollisionEnter(HostageDefaultAnimationController playerState);
    }
}
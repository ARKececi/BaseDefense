using Controllers.TransporterManController;
using UnityEngine;

namespace Extentions
{
    public abstract class TransporterManBaseState
    {
        public abstract void EnterState(TransporterManAnimationController playerState);
        public abstract void UpdateState(TransporterManAnimationController playerState);
        public abstract void OnCollisionEnter(TransporterManAnimationController playerState);
    }
}
using Controllers.HostageController;
using Extentions;

namespace HostageStates
{
    public class HostageAnimationWalkingState : HostageBaseState
    {
        public override void EnterState(HostageMinnerAnimationController hostageMinnerState)
        {
            hostageMinnerState.GetAnimator().SetBool("Walking", true);
            hostageMinnerState.GetAnimator().SetBool("Idle", false);
            hostageMinnerState.GetAnimator().SetBool("Hostage", false);
        }

        public override void UpdateState(HostageMinnerAnimationController hostageMinnerState)
        {
            
        }
        
        public override void OnCollisionEnter(HostageMinnerAnimationController hostageMinnerState)
        {
            
        }
    }
}